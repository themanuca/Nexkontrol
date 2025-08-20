using Application.Interfaces;
using Contract.DTOs;
using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IA
{
    public class AIService : IAIService
    {
        private readonly AppDbContext _context;

        public AIService(AppDbContext context)
        {
            _context = context;
        }

        public Task<AIAnalysisResponse> AnalyzeTransactionsAsync(Guid userId, AIAnalysisRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AIBudgetRecommendation> GetBudgetRecommendationsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<AIFinancialGoals> GetFinancialGoalsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<AISpendingInsights> GetSpendingInsightsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        //public async Task<AIAnalysisResponse> AnalyzeTransactionsAsync(Guid userId, AIAnalysisRequest request)
        //{
        //    var transactions = await GetTransactionsForAnalysis(userId, request);

        //    var analysis = new AIAnalysisResponse
        //    {
        //        AnalysisDate = DateTime.UtcNow,
        //        Summary = GenerateSummary(transactions, request),
        //        Insights = GenerateInsights(transactions, request),
        //        Recommendations = GenerateRecommendations(transactions, request),
        //        Metrics = CalculateMetrics(transactions, request)
        //    };

        //    return analysis;
        //}

        //public async Task<AIBudgetRecommendation> GetBudgetRecommendationsAsync(Guid userId)
        //{
        //    var currentMonth = DateTime.UtcNow;
        //    var startDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
        //    var endDate = startDate.AddMonths(1).AddDays(-1);

        //    var transactions = await _context.Transactions
        //        .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
        //        .Include(t => t.Category)
        //        .ToListAsync();

        //    var categories = await _context.Categories
        //        .Where(c => c.UserId == userId)
        //        .ToListAsync();

        //    var recommendations = new AIBudgetRecommendation
        //    {
        //        Summary = GenerateBudgetSummary(transactions),
        //        RecommendedBudgets = GenerateCategoryBudgets(transactions, categories),
        //        Alerts = GenerateBudgetAlerts(transactions, categories),
        //        CurrentSpending = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount),
        //        TotalRecommendedBudget = CalculateTotalRecommendedBudget(categories),
        //        RemainingBudget = CalculateRemainingBudget(transactions, categories)
        //    };

        //    return recommendations;
        //}

        //public async Task<AISpendingInsights> GetSpendingInsightsAsync(Guid userId)
        //{
        //    var currentMonth = DateTime.UtcNow;
        //    var previousMonth = currentMonth.AddMonths(-1);

        //    var currentTransactions = await GetTransactionsForMonth(userId, currentMonth);
        //    var previousTransactions = await GetTransactionsForMonth(userId, previousMonth);

        //    var insights = new AISpendingInsights
        //    {
        //        Summary = GenerateSpendingSummary(currentTransactions, previousTransactions),
        //        Patterns = AnalyzeSpendingPatterns(currentTransactions),
        //        Anomalies = DetectSpendingAnomalies(currentTransactions),
        //        Trends = AnalyzeSpendingTrends(currentTransactions, previousTransactions),
        //        Comparison = CompareSpendingPeriods(currentTransactions, previousTransactions)
        //    };

        //    return insights;
        //}

        //public async Task<AIFinancialGoals> GetFinancialGoalsAsync(Guid userId)
        //{
        //    var goals = await _context.Goals
        //        .Where(g => g.UserId == userId)
        //        .ToListAsync();

        //    var transactions = await _context.Transactions
        //        .Where(t => t.UserId == userId && t.Type == Domain.Enum.TransactionType.Income)
        //        .ToListAsync();

        //    var financialGoals = new AIFinancialGoals
        //    {
        //        Summary = GenerateGoalsSummary(goals, transactions),
        //        GoalRecommendations = GenerateGoalRecommendations(transactions),
        //        CurrentGoals = AnalyzeGoalProgress(goals, transactions),
        //        Milestones = GenerateGoalMilestones(goals),
        //        Metrics = CalculateGoalMetrics(goals, transactions)
        //    };

        //    return financialGoals;
        //}

        //// Métodos privados auxiliares
        //private async Task<List<Domain.Models.Transaction>> GetTransactionsForAnalysis(Guid userId, AIAnalysisRequest request)
        //{
        //    var query = _context.Transactions
        //        .Where(t => t.UserId == userId && t.Date >= request.StartDate && t.Date <= request.EndDate)
        //        .Include(t => t.Category)
        //        .Include(t => t.Account);

        //    if (request.Categories.Any())
        //        query = query.Where(t => request.Categories.Contains(t.Category.Name));

        //    if (request.MinAmount.HasValue)
        //        query = query.Where(t => t.Amount >= request.MinAmount.Value);

        //    if (request.MaxAmount.HasValue)
        //        query = query.Where(t => t.Amount <= request.MaxAmount.Value);

        //    return await query.ToListAsync();
        //}

        //private async Task<List<Domain.Models.Transaction>> GetTransactionsForMonth(Guid userId, DateTime month)
        //{
        //    var startDate = new DateTime(month.Year, month.Month, 1);
        //    var endDate = startDate.AddMonths(1).AddDays(-1);

        //    return await _context.Transactions
        //        .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
        //        .Include(t => t.Category)
        //        .ToListAsync();
        //}

        //private string GenerateSummary(List<Domain.Models.Transaction> transactions, AIAnalysisRequest request)
        //{
        //    var totalIncome = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount);
        //    var totalExpenses = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var netSavings = totalIncome - totalExpenses;

        //    return $"Análise do período {request.StartDate:dd/MM/yyyy} a {request.EndDate:dd/MM/yyyy}. " +
        //           $"Receitas: R$ {totalIncome:F2}, Despesas: R$ {totalExpenses:F2}, " +
        //           $"Saldo: R$ {netSavings:F2}.";
        //}

        //private List<AIInsight> GenerateInsights(List<Domain.Models.Transaction> transactions, AIAnalysisRequest request)
        //{
        //    var insights = new List<AIInsight>();

        //    // Análise de gastos por categoria
        //    var categorySpending = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .Select(g => new { Category = g.Key, Amount = g.Sum(t => t.Amount) })
        //        .OrderByDescending(x => x.Amount)
        //        .Take(3);

        //    foreach (var category in categorySpending)
        //    {
        //        insights.Add(new AIInsight
        //        {
        //            Title = $"Maior gasto em {category.Category}",
        //            Description = $"Você gastou R$ {category.Amount:F2} em {category.Category} neste período.",
        //            Type = "spending",
        //            Impact = category.Amount,
        //            Severity = category.Amount > 1000 ? "warning" : "info"
        //        });
        //    }

        //    // Análise de tendências
        //    var dailySpending = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Date.Date)
        //        .Select(g => new { Date = g.Key, Amount = g.Sum(t => t.Amount) })
        //        .OrderBy(x => x.Date)
        //        .ToList();

        //    if (dailySpending.Count > 1)
        //    {
        //        var averageDaily = dailySpending.Average(x => x.Amount);
        //        var highestDay = dailySpending.MaxBy(x => x.Amount);

        //        insights.Add(new AIInsight
        //        {
        //            Title = "Dia de maior gasto",
        //            Description = $"O dia {highestDay.Date:dd/MM} teve o maior gasto: R$ {highestDay.Amount:F2}. " +
        //                        $"Média diária: R$ {averageDaily:F2}.",
        //            Type = "trend",
        //            Impact = highestDay.Amount,
        //            Severity = "info"
        //        });
        //    }

        //    return insights;
        //}

        //private List<AIRecommendation> GenerateRecommendations(List<Domain.Models.Transaction> transactions, AIAnalysisRequest request)
        //{
        //    var recommendations = new List<AIRecommendation>();

        //    var totalExpenses = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var totalIncome = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount);

        //    if (totalExpenses > totalIncome * 0.8m)
        //    {
        //        recommendations.Add(new AIRecommendation
        //        {
        //            Title = "Controle de gastos",
        //            Description = "Seus gastos estão próximos de 80% da sua renda. Considere reduzir despesas não essenciais.",
        //            Action = "Revisar categorias de gastos e identificar oportunidades de economia",
        //            PotentialSavings = totalExpenses * 0.1m,
        //            Priority = "high"
        //        });
        //    }

        //    // Recomendação baseada em categorias
        //    var categorySpending = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .Select(g => new { Category = g.Key, Amount = g.Sum(t => t.Amount) })
        //        .OrderByDescending(x => x.Amount)
        //        .First();

        //    if (categorySpending.Amount > totalExpenses * 0.4m)
        //    {
        //        recommendations.Add(new AIRecommendation
        //        {
        //            Title = $"Foco em {categorySpending.Category}",
        //            Description = $"{categorySpending.Category} representa {categorySpending.Amount / totalExpenses * 100:F1}% dos seus gastos.",
        //            Action = "Analisar gastos nesta categoria e identificar oportunidades de redução",
        //            PotentialSavings = categorySpending.Amount * 0.15m,
        //            Priority = "medium"
        //        });
        //    }

        //    return recommendations;
        //}

        //private AIAnalysisMetrics CalculateMetrics(List<Domain.Models.Transaction> transactions, AIAnalysisRequest request)
        //{
        //    var totalIncome = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount);
        //    var totalExpenses = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var netSavings = totalIncome - totalExpenses;
        //    var savingsRate = totalIncome > 0 ? (netSavings / totalIncome) * 100 : 0;

        //    var topCategories = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .Select(g => new CategorySpending
        //        {
        //            CategoryName = g.Key,
        //            Amount = g.Sum(t => t.Amount),
        //            Percentage = totalExpenses > 0 ? (g.Sum(t => t.Amount) / totalExpenses) * 100 : 0
        //        })
        //        .OrderByDescending(x => x.Amount)
        //        .Take(5)
        //        .ToList();

        //    var monthlyTrends = transactions
        //        .GroupBy(t => new { t.Date.Year, t.Date.Month })
        //        .Select(g => new MonthlyTrend
        //        {
        //            Month = $"{g.Key.Year}/{g.Key.Month:D2}",
        //            Income = g.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount),
        //            Expenses = g.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount),
        //            Savings = g.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount) -
        //                     g.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount)
        //        })
        //        .OrderBy(x => x.Month)
        //        .ToList();

        //    return new AIAnalysisMetrics
        //    {
        //        TotalIncome = totalIncome,
        //        TotalExpenses = totalExpenses,
        //        NetSavings = netSavings,
        //        SavingsRate = savingsRate,
        //        TopSpendingCategories = topCategories,
        //        MonthlyTrends = monthlyTrends
        //    };
        //}

        //private string GenerateBudgetSummary(List<Domain.Models.Transaction> transactions)
        //{
        //    var totalExpenses = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var totalIncome = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Income).Sum(t => t.Amount);
        //    var savingsRate = totalIncome > 0 ? ((totalIncome - totalExpenses) / totalIncome) * 100 : 0;

        //    return $"Este mês você gastou R$ {totalExpenses:F2} de R$ {totalIncome:F2} disponíveis. " +
        //           $"Taxa de poupança: {savingsRate:F1}%.";
        //}

        //private List<CategoryBudget> GenerateCategoryBudgets(List<Domain.Models.Transaction> transactions, List<Domain.Models.Category> categories)
        //{
        //    var categoryBudgets = new List<CategoryBudget>();

        //    foreach (var category in categories)
        //    {
        //        var categoryTransactions = transactions.Where(t => t.CategoryId == category.Id).ToList();
        //        var currentSpending = categoryTransactions.Sum(t => t.Amount);
        //        var recommendedBudget = category.Budget ?? 0;
        //        var remainingBudget = recommendedBudget - currentSpending;

        //        var status = remainingBudget switch
        //        {
        //            < 0 => "overbudget",
        //            < recommendedBudget * 0.2m => "warning",
        //            _ => "normal"
        //        };

        //        var recommendation = status switch
        //        {
        //            "overbudget" => "Você ultrapassou o orçamento. Considere reduzir gastos nesta categoria.",
        //            "warning" => "Você está próximo do limite do orçamento. Monitore seus gastos.",
        //            _ => "Seus gastos estão dentro do orçamento planejado."
        //        };

        //        categoryBudgets.Add(new CategoryBudget
        //        {
        //            CategoryName = category.Name,
        //            CurrentSpending = currentSpending,
        //            RecommendedBudget = recommendedBudget,
        //            RemainingBudget = remainingBudget,
        //            Status = status,
        //            Recommendation = recommendation
        //        });
        //    }

        //    return categoryBudgets;
        //}

        //private List<BudgetAlert> GenerateBudgetAlerts(List<Domain.Models.Transaction> transactions, List<Domain.Models.Category> categories)
        //{
        //    var alerts = new List<BudgetAlert>();

        //    foreach (var category in categories)
        //    {
        //        if (category.Budget.HasValue)
        //        {
        //            var categoryTransactions = transactions.Where(t => t.CategoryId == category.Id).ToList();
        //            var currentSpending = categoryTransactions.Sum(t => t.Amount);
        //            var budgetUsage = (currentSpending / category.Budget.Value) * 100;

        //            if (budgetUsage > 100)
        //            {
        //                alerts.Add(new BudgetAlert
        //                {
        //                    Title = $"Orçamento excedido em {category.Name}",
        //                    Message = $"Você ultrapassou o orçamento de R$ {category.Budget:F2} em R$ {currentSpending - category.Budget.Value:F2}.",
        //                    Type = "critical",
        //                    CategoryName = category.Name,
        //                    Amount = currentSpending - category.Budget.Value
        //                });
        //            }
        //            else if (budgetUsage > 80)
        //            {
        //                alerts.Add(new BudgetAlert
        //                {
        //                    Title = $"Aproximando do limite em {category.Name}",
        //                    Message = $"Você já utilizou {budgetUsage:F1}% do orçamento de {category.Name}.",
        //                    Type = "warning",
        //                    CategoryName = category.Name,
        //                    Amount = category.Budget.Value - currentSpending
        //                });
        //            }
        //        }
        //    }

        //    return alerts;
        //}

        //private decimal CalculateTotalRecommendedBudget(List<Domain.Models.Category> categories)
        //{
        //    return categories.Where(c => c.Budget.HasValue).Sum(c => c.Budget.Value);
        //}

        //private decimal CalculateRemainingBudget(List<Domain.Models.Transaction> transactions, List<Domain.Models.Category> categories)
        //{
        //    var totalBudget = CalculateTotalRecommendedBudget(categories);
        //    var totalSpent = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    return totalBudget - totalSpent;
        //}

        //private string GenerateSpendingSummary(List<Domain.Models.Transaction> current, List<Domain.Models.Transaction> previous)
        //{
        //    var currentTotal = current.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var previousTotal = previous.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var change = currentTotal - previousTotal;
        //    var percentageChange = previousTotal > 0 ? (change / previousTotal) * 100 : 0;

        //    var trend = change switch
        //    {
        //        > 0 => "aumentou",
        //        < 0 => "diminuiu",
        //        _ => "manteve-se estável"
        //    };

        //    return $"Seus gastos {trend} {Math.Abs(percentageChange):F1}% em relação ao mês anterior. " +
        //           $"Mês atual: R$ {currentTotal:F2}, Mês anterior: R$ {previousTotal:F2}.";
        //}

        //private List<SpendingPattern> AnalyzeSpendingPatterns(List<Domain.Models.Transaction> transactions)
        //{
        //    var patterns = new List<SpendingPattern>();

        //    // Padrão por dia da semana
        //    var dayOfWeekSpending = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Date.DayOfWeek)
        //        .Select(g => new { Day = g.Key, Amount = g.Sum(t => t.Amount), Count = g.Count() })
        //        .OrderByDescending(x => x.Amount)
        //        .ToList();

        //    var highestDay = dayOfWeekSpending.First();
        //    patterns.Add(new SpendingPattern
        //    {
        //        Pattern = $"Maior gasto aos {highestDay.Day}s",
        //        Description = $"Você gasta em média R$ {highestDay.Amount / highestDay.Count:F2} aos {highestDay.Day}s.",
        //        Frequency = highestDay.Count,
        //        AverageAmount = highestDay.Amount / highestDay.Count,
        //        Impact = "Alto"
        //    });

        //    // Padrão por categoria
        //    var categoryPatterns = transactions
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .Select(g => new { Category = g.Key, Amount = g.Sum(t => t.Amount), Count = g.Count() })
        //        .OrderByDescending(x => x.Amount)
        //        .Take(3);

        //    foreach (var category in categoryPatterns)
        //    {
        //        patterns.Add(new SpendingPattern
        //        {
        //            Pattern = $"Gastos frequentes em {category.Category}",
        //            Description = $"Você fez {category.Count} transações em {category.Category} totalizando R$ {category.Amount:F2}.",
        //            Frequency = category.Count,
        //            AverageAmount = category.Amount / category.Count,
        //            Impact = "Médio"
        //        });
        //    }

        //    return patterns;
        //}

        //private List<SpendingAnomaly> DetectSpendingAnomalies(List<Domain.Models.Transaction> transactions)
        //{
        //    var anomalies = new List<SpendingAnomaly>();

        //    var expenses = transactions.Where(t => t.Type == Domain.Enum.TransactionType.Expense).ToList();
        //    var averageAmount = expenses.Any() ? expenses.Average(t => t.Amount) : 0;
        //    var standardDeviation = CalculateStandardDeviation(expenses.Select(t => t.Amount).ToList());

        //    foreach (var transaction in expenses)
        //    {
        //        var deviation = Math.Abs(transaction.Amount - averageAmount);
        //        if (deviation > standardDeviation * 2) // 2 desvios padrão
        //        {
        //            anomalies.Add(new SpendingAnomaly
        //            {
        //                Description = $"Transação anômala em {transaction.Category.Name}",
        //                Amount = transaction.Amount,
        //                ExpectedAmount = averageAmount,
        //                Deviation = deviation,
        //                CategoryName = transaction.Category.Name,
        //                Date = transaction.Date
        //            });
        //        }
        //    }

        //    return anomalies;
        //}

        //private List<SpendingTrend> AnalyzeSpendingTrends(List<Domain.Models.Transaction> current, List<Domain.Models.Transaction> previous)
        //{
        //    var trends = new List<SpendingTrend>();

        //    var currentByCategory = current
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

        //    var previousByCategory = previous
        //        .Where(t => t.Type == Domain.Enum.TransactionType.Expense)
        //        .GroupBy(t => t.Category.Name)
        //        .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

        //    foreach (var category in currentByCategory.Keys.Union(previousByCategory.Keys))
        //    {
        //        var currentAmount = currentByCategory.GetValueOrDefault(category, 0);
        //        var previousAmount = previousByCategory.GetValueOrDefault(category, 0);
        //        var change = currentAmount - previousAmount;
        //        var percentageChange = previousAmount > 0 ? (change / previousAmount) * 100 : 0;

        //        var direction = change switch
        //        {
        //            > 0 => "increasing",
        //            < 0 => "decreasing",
        //            _ => "stable"
        //        };

        //        trends.Add(new SpendingTrend
        //        {
        //            Trend = $"Gastos em {category}",
        //            Description = $"Seus gastos em {category} {direction} {Math.Abs(percentageChange):F1}% em relação ao mês anterior.",
        //            Change = change,
        //            Direction = direction,
        //            CategoryName = category
        //        });
        //    }

        //    return trends;
        //}

        //private SpendingComparison CompareSpendingPeriods(List<Domain.Models.Transaction> current, List<Domain.Models.Transaction> previous)
        //{
        //    var currentTotal = current.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var previousTotal = previous.Where(t => t.Type == Domain.Enum.TransactionType.Expense).Sum(t => t.Amount);
        //    var change = currentTotal - previousTotal;
        //    var percentageChange = previousTotal > 0 ? (change / previousTotal) * 100 : 0;

        //    return new SpendingComparison
        //    {
        //        CurrentPeriod = currentTotal,
        //        PreviousPeriod = previousTotal,
        //        Change = change,
        //        PercentageChange = percentageChange,
        //        Period = "month"
        //    };
        //}

        //private string GenerateGoalsSummary(List<Domain.Models.Goal> goals, List<Domain.Models.Transaction> transactions)
        //{
        //    var totalIncome = transactions.Sum(t => t.Amount);
        //    var totalGoals = goals.Sum(g => g.TargetAmount);
        //    var completedGoals = goals.Count(g => g.CurrentAmount >= g.TargetAmount);

        //    return $"Você tem {goals.Count} metas financeiras com valor total de R$ {totalGoals:F2}. " +
        //           $"Meta de renda mensal: R$ {totalIncome:F2}. Metas concluídas: {completedGoals}.";
        //}

        //private List<GoalRecommendation> GenerateGoalRecommendations(List<Domain.Models.Transaction> transactions)
        //{
        //    var recommendations = new List<GoalRecommendation>();
        //    var monthlyIncome = transactions.Sum(t => t.Amount);

        //    // Recomendação de meta de emergência
        //    var emergencyFund = monthlyIncome * 6;
        //    recommendations.Add(new GoalRecommendation
        //    {
        //        GoalName = "Fundo de Emergência",
        //        Description = "Reserva para 6 meses de despesas essenciais",
        //        TargetAmount = emergencyFund,
        //        Timeframe = "6 meses",
        //        MonthlyContribution = emergencyFund / 6,
        //        Priority = "high",
        //        Category = "Segurança"
        //    });

        //    // Recomendação de poupança
        //    var savingsGoal = monthlyIncome * 0.2m;
        //    recommendations.Add(new GoalRecommendation
        //    {
        //        GoalName = "Poupança Mensal",
        //        Description = "20% da renda para objetivos futuros",
        //        TargetAmount = savingsGoal * 12,
        //        Timeframe = "1 ano",
        //        MonthlyContribution = savingsGoal,
        //        Priority = "medium",
        //        Category = "Poupança"
        //    });

        //    return recommendations;
        //}

        //private List<GoalProgress> AnalyzeGoalProgress(List<Domain.Models.Goal> goals, List<Domain.Models.Transaction> transactions)
        //{
        //    var progress = new List<GoalProgress>();

        //    foreach (var goal in goals)
        //    {
        //        var progressPercentage = goal.TargetAmount > 0 ? (goal.CurrentAmount / goal.TargetAmount) * 100 : 0;
        //        var status = progressPercentage switch
        //        {
        //            >= 100 => "completed",
        //            >= 75 => "ahead",
        //            >= 50 => "on-track",
        //            >= 25 => "behind",
        //            _ => "behind"
        //        };

        //        var recommendation = status switch
        //        {
        //            "completed" => "Parabéns! Meta concluída. Considere estabelecer uma nova meta.",
        //            "ahead" => "Excelente progresso! Continue assim.",
        //            "on-track" => "Você está no caminho certo. Mantenha o foco.",
        //            "behind" => "Considere aumentar suas contribuições mensais para alcançar a meta.",
        //            _ => "Meta em risco. Revisão urgente necessária."
        //        };

        //        progress.Add(new GoalProgress
        //        {
        //            GoalName = goal.Name,
        //            CurrentAmount = goal.CurrentAmount,
        //            TargetAmount = goal.TargetAmount,
        //            ProgressPercentage = progressPercentage,
        //            Status = status,
        //            Recommendation = recommendation
        //        });
        //    }

        //    return progress;
        //}

        //private List<GoalMilestone> GenerateGoalMilestones(List<Domain.Models.Goal> goals)
        //{
        //    var milestones = new List<GoalMilestone>();

        //    foreach (var goal in goals)
        //    {
        //        var quarterMilestone = goal.TargetAmount * 0.25m;
        //        var halfMilestone = goal.TargetAmount * 0.5m;
        //        var threeQuarterMilestone = goal.TargetAmount * 0.75m;

        //        milestones.AddRange(new[]
        //        {
        //            new GoalMilestone
        //            {
        //                MilestoneName = $"25% de {goal.Name}",
        //                Amount = quarterMilestone,
        //                TargetDate = DateTime.UtcNow.AddMonths(3),
        //                IsCompleted = goal.CurrentAmount >= quarterMilestone,
        //                Category = goal.Category
        //            },
        //            new GoalMilestone
        //            {
        //                MilestoneName = $"50% de {goal.Name}",
        //                Amount = halfMilestone,
        //                TargetDate = DateTime.UtcNow.AddMonths(6),
        //                IsCompleted = goal.CurrentAmount >= halfMilestone,
        //                Category = goal.Category
        //            },
        //            new GoalMilestone
        //            {
        //                MilestoneName = $"75% de {goal.Name}",
        //                Amount = threeQuarterMilestone,
        //                TargetDate = DateTime.UtcNow.AddMonths(9),
        //                IsCompleted = goal.CurrentAmount >= threeQuarterMilestone,
        //                Category = goal.Category
        //            }
        //        });
        //    }

        //    return milestones;
        //}

        private GoalMetrics CalculateGoalMetrics(List<Domain.Models.Goal> goals, List<Domain.Models.Transaction> transactions)
        {
            var totalSavings = goals.Sum(g => g.CurrentAmount);
            var monthlySavings = transactions.Sum(t => t.Amount) * 0.2m; // Assumindo 20% de poupança
            var savingsRate = transactions.Sum(t => t.Amount) > 0 ? (monthlySavings / transactions.Sum(t => t.Amount)) * 100 : 0;
            var activeGoals = goals.Count(g => g.CurrentAmount < g.TargetAmount);
            var completedGoals = goals.Count(g => g.CurrentAmount >= g.TargetAmount);

            return new GoalMetrics
            {
                TotalSavings = totalSavings,
                MonthlySavings = monthlySavings,
                SavingsRate = savingsRate,
                ActiveGoals = activeGoals,
                CompletedGoals = completedGoals
            };
        }

        private decimal CalculateStandardDeviation(List<decimal> values)
        {
            if (!values.Any()) return 0;

            var average = values.Average();
            var sumOfSquares = values.Sum(x => (x - average) * (x - average));
            var variance = sumOfSquares / values.Count;
            return (decimal)Math.Sqrt((double)variance);
        }
    }
}
