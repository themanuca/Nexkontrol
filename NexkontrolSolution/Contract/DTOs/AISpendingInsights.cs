using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AISpendingInsights
    {
        public string Summary { get; set; } = string.Empty;
        public List<SpendingPattern> Patterns { get; set; } = new();
        public List<SpendingAnomaly> Anomalies { get; set; } = new();
        public List<SpendingTrend> Trends { get; set; } = new();
        public SpendingComparison Comparison { get; set; } = new();
    }

    public class SpendingPattern
    {
        public string Pattern { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Frequency { get; set; }
        public decimal AverageAmount { get; set; }
        public string Impact { get; set; } = string.Empty;
    }

    public class SpendingAnomaly
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal ExpectedAmount { get; set; }
        public decimal Deviation { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }

    public class SpendingTrend
    {
        public string Trend { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Change { get; set; }
        public string Direction { get; set; } = string.Empty; // increasing, decreasing, stable
        public string CategoryName { get; set; } = string.Empty;
    }

    public class SpendingComparison
    {
        public decimal CurrentPeriod { get; set; }
        public decimal PreviousPeriod { get; set; }
        public decimal Change { get; set; }
        public decimal PercentageChange { get; set; }
        public string Period { get; set; } = string.Empty; // month, quarter, year
    }
}
