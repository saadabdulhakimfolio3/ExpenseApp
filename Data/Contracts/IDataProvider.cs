using ExpenseApp.Models;

namespace ExpenseApp.Data.Contracts;

public interface IDataProvider
{
    bool CreateExpense(Expense request);
    public List<Expense> Get();
    public Expense GetExpense(string id);
    public bool DeleteExpense(string id);
    public bool UpsertExpense(string id, Expense expense);
}
