using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class AccountCreateDto
    {
        public string Name { get; set; } // ex: "Nubank Crédito"
        public decimal InitialBalance { get; set; }
        public AccountType Type { get; set; } // Enum: CreditCard, Bank, Wallet, etc.

        public Guid UserId { get; set; }

    }
}
