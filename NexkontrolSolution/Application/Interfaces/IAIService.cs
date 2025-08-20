using Contract.DTOs;

namespace Application.Interfaces
{
    public interface IAIService
    {
        Task<AIAnalysisResponse> AnalyzeTransactionsAsync(Guid userId, AIAnalysisRequest request);
        Task<AIBudgetRecommendation> GetBudgetRecommendationsAsync(Guid userId);
        Task<AISpendingInsights> GetSpendingInsightsAsync(Guid userId);
        Task<AIFinancialGoals> GetFinancialGoalsAsync(Guid userId);
    }
}