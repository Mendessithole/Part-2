using CMCSProjectPART1.Models; // Ensure you have this namespace for your models
using Microsoft.AspNetCore.Hosting; // For accessing IWebHostEnvironment
using Microsoft.AspNetCore.Http; // For handling file uploads
using Microsoft.AspNetCore.Mvc; // For MVC features
using System.Collections.Generic; // For using List<T>
using System.IO; // For file handling
using System.Linq; // For LINQ queries

namespace CMCSProjectPART1.Controllers
{
    public class LectureController : Controller
    {
        private readonly IWebHostEnvironment _env; // Field to hold environment information

        // Simulated data storage for classes
        private static List<ClassModel> classes = new List<ClassModel>
        {
            new ClassModel { Id = 1, ClassName = "Math 101", ClassCode = "MTH101", Description = "Basic Mathematics" },
            new ClassModel { Id = 2, ClassName = "Physics 201", ClassCode = "PHY201", Description = "Introduction to Physics" }
        };

        // Simulated data for monthly claims
        private static List<MonthlyClaimModel> claims = new List<MonthlyClaimModel>();

        // Constructor to inject the hosting environment
        public LectureController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET: /Lecture
        public IActionResult Index()
        {
            return View(); // Ensure there's a corresponding Index view
        }

        // GET: /Lecture/ClassList
        public IActionResult ClassList()
        {
            return View(classes); // Return the view with the list of classes
        }

        // GET: /Lecture/AddClass
        [HttpGet]
        public IActionResult AddClass()
        {
            return View(); // Return the view for adding a new class
        }

        // POST: /Lecture/AddClass
        [HttpPost]
        public IActionResult AddClass(ClassModel classModel)
        {
            if (ModelState.IsValid) // Check if the model is valid
            {
                classModel.Id = classes.Max(c => c.Id) + 1; // Assign new ID
                classes.Add(classModel); // Add the class to the list
                return RedirectToAction("ClassList"); // Redirect to the class list
            }
            return View(classModel); // Return the view with the model if there are validation errors
        }

        // GET: /Lecture/EditClass/{id}
        [HttpGet]
        public IActionResult EditClass(int id)
        {
            var classToEdit = classes.FirstOrDefault(c => c.Id == id);
            if (classToEdit == null)
            {
                return NotFound(); // Return a 404 if not found
            }
            return View(classToEdit); // Return the view for editing a class
        }

        // POST: /Lecture/EditClass
        [HttpPost]
        public IActionResult EditClass(ClassModel classModel)
        {
            var existingClass = classes.FirstOrDefault(c => c.Id == classModel.Id);
            if (existingClass != null)
            {
                existingClass.ClassName = classModel.ClassName;
                existingClass.ClassCode = classModel.ClassCode;
                existingClass.Description = classModel.Description;
            }
            return RedirectToAction("ClassList"); // Redirect to the class list
        }

        // POST: /Lecture/DeleteClass/{id}
        [HttpPost]
        public IActionResult DeleteClass(int id)
        {
            var classToDelete = classes.FirstOrDefault(c => c.Id == id);
            if (classToDelete != null)
            {
                classes.Remove(classToDelete); // Remove the class
            }
            return RedirectToAction("ClassList"); // Redirect to the class list
        }

        // GET: /Lecture/SubmitClaim
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View(); // Return the claim submission form
        }

        // POST: /Lecture/SubmitClaim
        [HttpPost]
        public IActionResult SubmitClaim(SubmitClaimModel model)
        {
            if (ModelState.IsValid) // Check if the model is valid
            {
                // Save the uploaded file if it exists
                if (model.ClaimDocument != null && model.ClaimDocument.Length > 0)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "uploads", model.ClaimDocument.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ClaimDocument.CopyTo(stream); // Save the file
                    }
                }

                // Create a new claim and add it to the list
                var newClaim = new MonthlyClaimModel
                {
                    Id = claims.Count + 1,
                    ClaimDate = model.ClaimDate,
                    Amount = model.Amount,
                    Status = "Pending",
                    DocumentPath = model.ClaimDocument?.FileName // Store the document name
                };
                claims.Add(newClaim); // Add the claim to the list
                return RedirectToAction("MonthlyClaims"); // Redirect to the claims list
            }
            return View(model); // Return the view with the model if there are validation errors
        }

        // GET: /Lecture/MonthlyClaims
        public IActionResult MonthlyClaims()
        {
            return View(claims); // Return the view with the list of claims
        }
    }
}
