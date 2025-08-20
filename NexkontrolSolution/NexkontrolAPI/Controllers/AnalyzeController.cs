using Application.Interfaces;
using Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NexkontrolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AnalyzeController : ControllerBase
    {
        private readonly IAIService _aiService;
        private readonly IExternalAIService _externalAIService;

        public AnalyzeController(IAIService aiService, IExternalAIService externalAIService)
        {
            _aiService = aiService;
            _externalAIService = externalAIService;
        }

        /// <summary>
        /// Analisa transações do usuário usando IA
        /// </summary>
        [HttpPost("analyze")]
        public async Task<ActionResult<AIAnalysisResponse>> AnalyzeTransactions([FromBody] AIAnalysisRequest request)
        {
            try
            {
                var userId = GetUserIdFromToken();
                var analysis = await _aiService.AnalyzeTransactionsAsync(userId, request);
                return Ok(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém recomendações de orçamento baseadas em IA
        /// </summary>
        [HttpGet("budget-recommendations")]
        public async Task<ActionResult<AIBudgetRecommendation>> GetBudgetRecommendations()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var recommendations = await _aiService.GetBudgetRecommendationsAsync(userId);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém insights sobre gastos usando IA
        /// </summary>
        [HttpGet("spending-insights")]
        public async Task<ActionResult<AISpendingInsights>> GetSpendingInsights()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var insights = await _aiService.GetSpendingInsightsAsync(userId);
                return Ok(insights);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém análise de metas financeiras usando IA
        /// </summary>
        [HttpGet("financial-goals")]
        public async Task<ActionResult<AIFinancialGoals>> GetFinancialGoals()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var goals = await _aiService.GetFinancialGoalsAsync(userId);
                return Ok(goals);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Análise rápida do mês atual
        /// </summary>
        [HttpGet("quick-analysis")]
        public async Task<ActionResult<AIAnalysisResponse>> GetQuickAnalysis()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var currentMonth = DateTime.UtcNow;
                var startDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var request = new AIAnalysisRequest
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    AnalysisType = "general"
                };

                var analysis = await _aiService.AnalyzeTransactionsAsync(userId, request);
                return Ok(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Análise comparativa entre períodos
        /// </summary>
        [HttpPost("compare-periods")]
        public async Task<ActionResult<object>> ComparePeriods([FromBody] PeriodComparisonRequest request)
        {
            try
            {
                var userId = GetUserIdFromToken();

                var period1Analysis = await _aiService.AnalyzeTransactionsAsync(userId, new AIAnalysisRequest
                {
                    StartDate = request.Period1Start,
                    EndDate = request.Period1End,
                    AnalysisType = "comparison"
                });

                var period2Analysis = await _aiService.AnalyzeTransactionsAsync(userId, new AIAnalysisRequest
                {
                    StartDate = request.Period2Start,
                    EndDate = request.Period2End,
                    AnalysisType = "comparison"
                });

                var comparison = new
                {
                    Period1 = new { Start = request.Period1Start, End = request.Period1End, Analysis = period1Analysis },
                    Period2 = new { Start = request.Period2Start, End = request.Period2End, Analysis = period2Analysis },
                    Summary = GenerateComparisonSummary(period1Analysis, period2Analysis)
                };

                return Ok(comparison);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Perguntar à IA
        /// </summary>
        /// 
        [HttpPost("ask-ia")]
        public async Task<ActionResult<string>> AskIA([FromBody] SendMessageIADto pergunta)
        {
            try
            {
                var userId = GetUserId();
                var resposta = await _externalAIService.PerguntarIAAsync(pergunta.Pergunta, userId);
                return Ok(new { resposta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        private Guid GetUserIdFromToken()
        {
            // Implementar lógica para extrair userId do token JWT
            // Por enquanto, retornando um GUID vazio para demonstração
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (Guid.TryParse(userIdClaim, out var userId))
                return userId;

            throw new UnauthorizedAccessException("Usuário não autenticado");
        }
        private Guid GetUserId()
        {
            var sub = User.FindFirstValue("codeVerify")
                      ?? throw new UnauthorizedAccessException("Token JWT inválido ou não contém o claim 'sub'.");

            return Guid.Parse(sub);
        }

        private string GenerateComparisonSummary(AIAnalysisResponse period1, AIAnalysisResponse period2)
        {
            var period1Net = period1.Metrics.NetSavings;
            var period2Net = period2.Metrics.NetSavings;
            var change = period2Net - period1Net;
            var percentageChange = period1Net != 0 ? (change / Math.Abs(period1Net)) * 100 : 0;

            var trend = change switch
            {
                > 0 => "melhorou",
                < 0 => "piorou",
                _ => "manteve-se estável"
            };

            return $"Comparando os dois períodos, sua situação financeira {trend}. " +
                   $"Variação: R$ {change:F2} ({percentageChange:F1}%).";
        }
    }

    public class PeriodComparisonRequest
    {
        public DateTime Period1Start { get; set; }
        public DateTime Period1End { get; set; }
        public DateTime Period2Start { get; set; }
        public DateTime Period2End { get; set; }
    }
}

