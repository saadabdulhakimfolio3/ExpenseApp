using Amazon.Runtime.Internal;
using ExpenseApp.Config;
using ExpenseApp.Data.Contracts;
using ExpenseApp.Models;
using MongoDB.Driver;

namespace ExpenseApp.Data;

public class MongoDataProvider : IDataProvider
{
    private readonly IMongoClient _client;
    private readonly ExpenseStoreDatabaseSettings _settings;
    private readonly IMongoCollection<Expense> _expenses;

    public MongoDataProvider(IMongoClient mongoClient,ExpenseStoreDatabaseSettings dbSettings)
    {
        Console.WriteLine(dbSettings.ConnectionString);
        Console.WriteLine(dbSettings.DatabaseName);
        _client = mongoClient;
        _settings = dbSettings;
        IMongoDatabase database = _client.GetDatabase(dbSettings.DatabaseName);
        _expenses = database.GetCollection<Expense>(dbSettings.ExpenseCollectionName);
    }
    public bool CreateExpense(Expense request)
    {
        Console.WriteLine(request.Description);
        _expenses.InsertOne(request);
        return true;
    }

    // Getting expense from database.
    public List<Expense> GetExpenses()
    {
        return _expenses.Find(expense => true).ToList();
    }
    public Expense GetExpense(string id)
    {
        Console.WriteLine(id);
        Expense expense = _expenses.Find(expense => expense.Id == id).First();
        return expense;
    }

    public bool DeleteExpense(string id)
    {
        Console.WriteLine(id);
        _expenses.DeleteOne(expense => expense.Id == id);
        return true;
    }

    public bool UpsertExpense(string id, Expense expense)
    {
        Console.WriteLine(id);
        _expenses.ReplaceOne(expense => expense.Id == id, expense);
        return true;
    }

}
