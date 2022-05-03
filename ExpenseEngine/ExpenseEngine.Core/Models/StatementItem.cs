using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Models
{
    public class StatementItem
    {
        public string Description { get; set; }
        public double Debit { get; set; }
        public DateTime Date { get; set; }
    }
}
