using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class CategorySummaryDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public decimal TotalSpent { get; set; }
    }

}
