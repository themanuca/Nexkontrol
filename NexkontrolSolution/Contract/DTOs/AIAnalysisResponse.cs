using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AIAnalysisResponse
    {
        public string Summary { get; set; } = string.Empty;
        public List<AIInsight> Insights { get; set; } = new();
        public List<AIRecommendation> Recommendations { get; set; } = new();
        public AIAnalysisMetrics Metrics { get; set; } = new();
        public DateTime AnalysisDate { get; set; }
    }

    public class AIInsight
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // spending, saving, trend, alert
        public decimal? Impact { get; set; }
        public string Severity { get; set; } = "info"; // info, warning, critical
    }

    public class AIRecommendation
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public decimal? PotentialSavings { get; set; }
        public string Priority { get; set; } = "medium"; // low, medium, high
    }

    public class AIAnalysisMetrics
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetSavings { get; set; }
        public decimal SavingsRate { get; set; }
        public List<CategorySpending> TopSpendingCategories { get; set; } = new();
        public List<MonthlyTrend> MonthlyTrends { get; set; } = new();
    }

    public class CategorySpending
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }

    public class MonthlyTrend
    {
        public string Month { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Savings { get; set; }
    }
}
