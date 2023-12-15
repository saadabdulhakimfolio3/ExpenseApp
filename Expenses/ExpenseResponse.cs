namespace ExpenseApp.Expenses
{

    // Used to store our return data for Get request.
    public record ExpenseResponse
    (
        string ID,
        string Description,
        string Category,
        DateTime Date,
        DateTime LastModified,
        int Ammount
    );
}
