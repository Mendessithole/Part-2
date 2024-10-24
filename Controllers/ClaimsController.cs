using CMCSProjectPART1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCSProjectPART1.Controllers
{
    public class ClaimsController : Controller
    {
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                // Handle form submission
                return RedirectToAction("Index", "Home");
            }
            return View(claim);
        }
    }
}
