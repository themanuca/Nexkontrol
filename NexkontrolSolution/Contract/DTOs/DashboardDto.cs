using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class DashboardDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance => TotalIncome - TotalExpenses;

        public List<CategorySummaryDto> ExpensesByCategory { get; set; } = new();
        public List<PendingTransactionDto> PendingTransactions { get; set; } = new();
    }

}
