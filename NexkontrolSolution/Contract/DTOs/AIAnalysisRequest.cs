using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AIAnalysisRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AnalysisType { get; set; } = "general"; // general, spending, budget, goals
        public List<string> Categories { get; set; } = new();
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}
