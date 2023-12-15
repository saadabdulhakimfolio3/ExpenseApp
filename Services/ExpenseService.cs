using ExpenseApp.Contracts;
using ExpenseApp.Data.Contracts;
using ExpenseApp.Models;
using MongoDB.Driver;
namespace ExpenseApp.Services
{
    public class ExpenseService: IExpenseService
    {
        // storing reference to our expenses collection in mongodb database.
        private readonly IDataProvider _dataProvider;
        
        public ExpenseService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }


        // Mongodb
        // Adding expense to database.
        public bool CreateExpense(Expense expense)
        {
            return _dataProvider.CreateExpense(expense);
        }

        // Getting expense from database.
        public List<Expense> Get()
        {
            return _dataProvider.Get();
        }
        public Expense GetExpense(Guid id)
        {
            return _dataProvider.GetExpense(id);
        }

        public bool DeleteExpense(Guid id)
        {
            return _dataProvider.DeleteExpense(id);
        }

        public bool UpsertExpense(Guid id, Expense expense)
        {
            return _dataProvider.UpsertExpense(id, expense); 
        }

        // Dictionary Implementation
        /*        // Used to store all our expenses.
                // Acts as local database.
                // Shoudl only be created only once.
                private static readonly Dictionary<Guid, Expense> _expenses = new();

                // Adding expense to database.
                public void CreateExpense(Expense expense) 
                {
                    _expenses.Add(expense.Id, expense);
                }

                // Getting expense from database.
                public Expense GetExpense(Guid id)
                {
                    return _expenses[id];
                }

                public void UpsertExpense(Expense expense)
                {
                    _expenses[expense.Id] = expense;
                }

                public void DeleteExpense(Expense expense)
                {
                    _expenses.Remove(expense.Id);
                }*/
    }
}
