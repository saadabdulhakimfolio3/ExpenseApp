using ExpenseApp.Models;

namespace ExpenseApp.Contracts
{
    public interface IExpenseService
    {
        bool CreateExpense(Expense expense);
        Expense GetExpense(Guid id);
        bool UpsertExpense(Guid id, Expense expense);
        bool DeleteExpense(Guid id);
    }
}
