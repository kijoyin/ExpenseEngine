using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Models
{
    public class MonthlyExpense
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Expense> Expenses { get; set; }

        public string ToMonthString()
        {
            string monthName = new DateTime(2010,Month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            return $"{monthName} {Year}";
        }
    }
}
