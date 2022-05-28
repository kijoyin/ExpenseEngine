using ExpenseEngine.Core.Models;

namespace ExpenseEngine.Core.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetExpenses();
    }
}