using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DTOs
{
    public class TransactionUpdateDto : TransactionCreateDto
    {
        public Guid Id { get; set; }
    }
}
