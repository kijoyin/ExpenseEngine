using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Models
{
    public class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime SpendOn { get; set; }
    }
}
