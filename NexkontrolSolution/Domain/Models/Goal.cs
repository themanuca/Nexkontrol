using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; } // Ex: "Viagem para o Rio"
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime? Deadline { get; set; }
    }

}
