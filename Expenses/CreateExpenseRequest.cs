namespace ExpenseApp.Expenses
{

    // Used to store our JSON data for Get request.
    public record CreateExpenseRequest
    (
        string Description,
        string Category,
        int Ammount,
        DateTime Date
    );
}
