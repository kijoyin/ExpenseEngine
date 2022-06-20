using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Domain.Entities
{
    public class ExpenseMonthlyEntity: EntityBase
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
    }
}
