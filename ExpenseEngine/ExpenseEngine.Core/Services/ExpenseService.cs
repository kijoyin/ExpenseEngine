using ExpenseEngine.Core.Models;
using ExpenseEngine.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.SqlTypes;
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
            
            var expenseEntities = await _context.Expenses
                                                .Include(e => e.Tags)
                                                .ToListAsync();
            var expenses = MapExpenseEntitiesToModel(expenseEntities);
            return expenses;
        }

        private static List<Expense> MapExpenseEntitiesToModel(List<ExpenseEntity> expenseEntities)
        {
            var expenses = new List<Expense>();
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

        public async Task<List<MonthlyExpense>> GetMonthlyExpenses()
        {

            var today = DateTime.Now;
            var sixMonthsFromToday = DateTime.Now.AddMonths(-6);
            var endOfCurrentMonth = DateOnly.FromDateTime(new DateTime(today.Year, today.Month,
                                    DateTime.DaysInMonth(today.Year, today.Month)));
            var sixMonthsInPast = DateOnly.FromDateTime(new DateTime(sixMonthsFromToday.Year, sixMonthsFromToday.Month,1));

            var monthlyExpenses = new List<MonthlyExpense>();
            var groupedExpenses = (await _context.Expenses.Where(e=>e.SpendOn >= sixMonthsInPast && e.SpendOn <= endOfCurrentMonth && !e.Tags.Any(t=>t.Tag=="Internal"))
                                                .Include(e => e.Tags).ToListAsync())
                                                .GroupBy(x => new { x.SpendOn.Year, x.SpendOn.Month });
                                                //.GroupBy(x => SqlFunctions.DateAdd("month", SqlFunctions.DateDiff("month", sqlMinDate, new DateTime(x.SpendOn.Year, x.SpendOn.Month, x.SpendOn.Day)), sqlMinDate))
                                               
            foreach(var monthlyExpense in groupedExpenses)
            {
                var monthly = new MonthlyExpense();
                monthly.Year = monthlyExpense.Key.Year;
                monthly.Month = monthlyExpense.Key.Month;
                monthly.TotalAmount = monthlyExpense.Sum(e => e.Amount);
                monthly.Expenses = MapExpenseEntitiesToModel(monthlyExpense.ToList());
                monthlyExpenses.Add(monthly);
            }
            return monthlyExpenses;
        }
    }
}
