using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enum
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public enum AccountType
    {
        Bank,
        CreditCard,
        Cash,
        Pix
    }

    public enum TransactionStatus
    {
        Paid,
        Pending
    }

    public enum RecurrenceInterval
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

}
