namespace ExpenseApp.Expenses
{
    // Used to store JSON data for Post request.
    public record UpsertExpenseRequest
    (
        string Description,
        string Category,
        int Ammount,
        DateTime Date,
        DateTime LastModified
    );
}
