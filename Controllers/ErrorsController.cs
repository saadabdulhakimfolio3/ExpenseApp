using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
