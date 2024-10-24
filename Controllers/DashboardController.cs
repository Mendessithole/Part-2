using Microsoft.AspNetCore.Mvc;

namespace CMCSProjectPART1.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will render Views/Dashboard/Index.cshtml
        }
    }
}
