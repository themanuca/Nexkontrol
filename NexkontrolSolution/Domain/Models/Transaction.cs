using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? Notes { get; set; }
        public TransactionType Type { get; set; } // Enum: Income / Expense
        public TransactionStatus Status { get; set; } // Enum: Paid / Pending
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrenceInterval? RecurrenceInterval { get; set; } // Enum: Monthly, Weekly, etc.
    }

}
