using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public  string PasswordHash { get; set; }
        public decimal? MonthlyLimit { get; set; }

        public List<Account> Accounts { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
    }

}
