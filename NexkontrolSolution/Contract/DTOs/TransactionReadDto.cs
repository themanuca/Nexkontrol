using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class TransactionReadDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? Notes { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public string AccountName { get; set; }
        public string CategoryName { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrenceInterval? RecurrenceInterval { get; set; }
    }
}
