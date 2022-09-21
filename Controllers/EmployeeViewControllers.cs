using Microsoft.AspNetCore.Mvc;

namespace Training_Task.Controllers
{
    public class EmployeeViewControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
