using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class DadosUserIAAnalyzeDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public Guid AccountId { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrenceInterval? RecurrenceInterval { get; set; }

    }
}
