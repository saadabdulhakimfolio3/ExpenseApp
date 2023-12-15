using ExpenseApp.Contracts;
using ExpenseApp.Expenses;
using ExpenseApp.Models;
using ExpenseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [ApiController]
    //Base route
    [Route("expenses")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        // Dependency Injection for database service.
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // All http requests will be added after base route.
        // Requests is the json data sent with the API.
        // {id} is the parameter inside the http request.
        // Posting a new expense.
        [HttpPost]
        public IActionResult CreateExpense(CreateExpenseRequest request)
        {
            // Creating a new expense to add to database based on request.
            // We map the data.
            var expense = new Expense(  request.Description,
                                        request.Category,
                                        request.Date,
                                        DateTime.UtcNow,
                                        request.Ammount);

            // Saving data to database.
            _expenseService.CreateExpense(expense);

            // Getting a response of new expense entry from the database.
            var response = new ExpenseResponse(
                expense.Id,
                expense.Description,
                expense.Category,
                expense.Date,
                expense.LastModified,
                expense.Ammount);

            // Indicating action was a success.
            return CreatedAtAction(actionName : nameof(GetExpense), routeValues: new {id = expense.Id}, value: response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetExpense(string id)
        {
            // Getting expense from our database.
            Expense expense = _expenseService.GetExpense(id);

            // Converting entry into response.
            ExpenseResponse response = new ExpenseResponse(
                expense.Id,
                expense.Description,
                expense.Category,
                expense.Date,
                expense.LastModified,
                expense.Ammount);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertExpenses(string id, UpsertExpenseRequest request)
        {
            // Creating new expense.
            var expense = new Expense(id,
                request.Description,
                request.Category,
                request.Date,
                DateTime.UtcNow,
                request.Ammount
                );

            // Updating existing expense.
            _expenseService.UpsertExpense(id, expense);
            
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult UpsertExpenses(string id)
        {
            // Deleting expense from database.
            _expenseService.DeleteExpense(id);
            return NoContent();
        }

    }
}
