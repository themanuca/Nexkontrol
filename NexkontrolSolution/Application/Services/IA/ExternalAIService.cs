using Application.Interfaces;
using Domain.Models.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services.IA
{
    public class ExternalAIService : IExternalAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IConfiguration _configuration;
        private readonly ITransactionService _serviceTransaction;
        public ExternalAIService(HttpClient httpClient, IConfiguration configuration, ITransactionService transactionService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _apiKey = configuration["ExternalAI:APIKEY"];
            _serviceTransaction = transactionService;
        }

        public async Task<string> PerguntarIAAsync(string pergunta, Guid userId)
        {
            var transactions = await _serviceTransaction.GetAllAsync(userId);

            var ultimos30Dias = transactions
            .Where(t => t.Date >= DateTime.UtcNow.AddDays(-30))
            .ToList();

            var totalIncome = ultimos30Dias
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var totalExpense = ultimos30Dias
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            var saldo = totalIncome - totalExpense;

            // Top 3 despesas
            var maioresDespesas = ultimos30Dias
                .Where(t => t.Type == TransactionType.Expense)
                .OrderByDescending(t => t.Amount)
                .Take(3)
                .Select(t => $"{t.Description} ({t.CategoryName}): R${t.Amount}")
                .ToList();

            // Gastos por categoria
            var gastosPorCategoria = ultimos30Dias
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.CategoryName)
                .Select(g => $"{g.Key}: R${g.Sum(x => x.Amount)}")
                .ToList();

            // Montar um resumo em string
            var resumoFinanceiro = $@"
                    Resumo dos últimos 30 dias:
                    - Receitas: R${totalIncome}
                    - Despesas: R${totalExpense}
                    - Saldo líquido: R${saldo}

                    Maiores despesas:
                    {string.Join("\n", maioresDespesas)}

                    Gastos por categoria:
                    {string.Join("\n", gastosPorCategoria)}
                    ";
            var requestBody = new
            {
                model = "gpt-4o-mini", // modelo mais barato e rápido para testes
                messages = new[]
                {
                    new { role = "system", content = "Você é um assistente financeiro que responde em português de forma clara e prática." },
                    new { role = "assistant", content = resumoFinanceiro },
                    new { role = "user", content = pergunta }
                },
                max_tokens = 300
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseBody);
            var resposta = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return resposta ?? string.Empty;
        }
    }
}
