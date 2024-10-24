using Microsoft.AspNetCore.Mvc;
using CMCSProjectPART1.Models;
using System.Linq;
using System.Collections.Generic;

namespace CMCSProjectPART1.Controllers
{
    public class ProgramCoordinatorController : Controller
    {
        // In-memory data storage (Simulated)
        private static List<ClaimModel> claims = new List<ClaimModel>
        {
            new ClaimModel { Id = 1, Description = "Claim 1", Amount = 1000, Status = "Pending" },
            new ClaimModel { Id = 2, Description = "Claim 2", Amount = 2000, Status = "Pending" }
        };

        // GET: /ProgramCoordinator/Index
        public IActionResult Index()
        {
            // Pass all claims to the view
            return View(claims);
        }

        // POST: /ProgramCoordinator/Approve/{id}
        public IActionResult Approve(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved"; // Update claim status to Approved
            }
            return Redirect("/Lecture/MonthlyClaims"); // Redirect to /Lecture/MonthlyClaims
        }

        // POST: /ProgramCoordinator/Reject/{id}
        public IActionResult Reject(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected"; // Update claim status to Rejected
            }
            return Redirect("/Lecture/MonthlyClaims"); // Redirect to /Lecture/MonthlyClaims
        }
    }
}
