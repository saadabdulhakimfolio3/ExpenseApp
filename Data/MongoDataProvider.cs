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
        _client = mongoClient;
        _settings = dbSettings;
        IMongoDatabase database = _client.GetDatabase(dbSettings.DatabaseName);
        _expenses = database.GetCollection<Expense>(dbSettings.ExpenseCollectionName);
    }
    public bool CreateExpense(Expense request)
    {
        _expenses.InsertOne(request);
        return true;
    }

    // Getting expense from database.
    public List<Expense> Get()
    {
        return _expenses.Find(expense => true).ToList();
    }
    public Expense GetExpense(string id)
    {
        return _expenses.Find(expense => expense.Id == id).FirstOrDefault();
    }

    public bool DeleteExpense(string id)
    {
        _expenses.DeleteOne(expense => expense.Id == id);
        return true;
    }

    public bool UpsertExpense(string id, Expense expense)
    {
        _expenses.ReplaceOne(expense => expense.Id == id, expense);
        return true;
    }

}
