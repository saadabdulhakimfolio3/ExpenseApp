using ExpenseApp.Models;

namespace ExpenseApp.Contracts
{
    public interface IExpenseService
    {
        bool CreateExpense(Expense expense);
        Expense GetExpense(string id);
        bool UpsertExpense(string id, Expense expense);
        bool DeleteExpense(string id);
    }
}
