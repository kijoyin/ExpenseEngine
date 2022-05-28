using ExpenseEngine.Core.Models;
using ExpenseEngine.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseContext _context;
        public ExpenseService(ExpenseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            var expenses = new List<Expense>();
            var expenseEntities = await _context.Expenses.Include(e=>e.Tags)
                                                .ToListAsync();
            foreach (var expense in expenseEntities)
            {
                expenses.Add(new Expense()
                {
                    Amount = expense.Amount,
                    Description = expense.Description,
                    SpendOn = new DateTime(expense.SpendOn.Year, expense.SpendOn.Month, expense.SpendOn.Day),
                    Tags = expense.Tags.Select(t => t.Tag).ToList()
                });
            }
            return expenses;
        }
    }
}
