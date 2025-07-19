using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Budget
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public decimal LimitAmount { get; set; }
    }

}
