using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AIFinancialGoals
    {
        public string Summary { get; set; } = string.Empty;
        public List<GoalRecommendation> GoalRecommendations { get; set; } = new();
        public List<GoalProgress> CurrentGoals { get; set; } = new();
        public List<GoalMilestone> Milestones { get; set; } = new();
        public GoalMetrics Metrics { get; set; } = new();
    }

    public class GoalRecommendation
    {
        public string GoalName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public string Timeframe { get; set; } = string.Empty;
        public decimal MonthlyContribution { get; set; }
        public string Priority { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class GoalProgress
    {
        public string GoalName { get; set; } = string.Empty;
        public decimal CurrentAmount { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal ProgressPercentage { get; set; }
        public string Status { get; set; } = string.Empty; // on-track, behind, ahead
        public string Recommendation { get; set; } = string.Empty;
    }

    public class GoalMilestone
    {
        public string MilestoneName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public class GoalMetrics
    {
        public decimal TotalSavings { get; set; }
        public decimal MonthlySavings { get; set; }
        public decimal SavingsRate { get; set; }
        public int ActiveGoals { get; set; }
        public int CompletedGoals { get; set; }
    }
}
