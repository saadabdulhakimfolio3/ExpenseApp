using ExpenseApp.Models;

namespace ExpenseApp.Data.Contracts;

public interface IDataProvider
{
    bool CreateExpense(Expense request);
    public List<Expense> Get();
    public Expense GetExpense(Guid id);
    public bool DeleteExpense(Guid id);
    public bool UpsertExpense(Guid id, Expense expense);
}
