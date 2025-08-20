using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AIBudgetRecommendation
    {
        public string Summary { get; set; } = string.Empty;
        public List<CategoryBudget> RecommendedBudgets { get; set; } = new();
        public List<BudgetAlert> Alerts { get; set; } = new();
        public decimal TotalRecommendedBudget { get; set; }
        public decimal CurrentSpending { get; set; }
        public decimal RemainingBudget { get; set; }
    }

    public class CategoryBudget
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal CurrentSpending { get; set; }
        public decimal RecommendedBudget { get; set; }
        public decimal RemainingBudget { get; set; }
        public string Status { get; set; } = "normal"; // normal, warning, overbudget
        public string Recommendation { get; set; } = string.Empty;
    }

    public class BudgetAlert
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // warning, alert, critical
        public string CategoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
