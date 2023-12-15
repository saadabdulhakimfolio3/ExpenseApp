namespace ExpenseApp.Config;

public class ExpenseStoreDatabaseSettings
{
    public string ExpenseCollectionName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
