using Microsoft.AspNetCore.Mvc;
using sof_curs.Entity;
using sof_curs.Models;
using System.Diagnostics;

namespace sof_curs.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ILogger<SignUpController> _logger;
        private readonly DBContext _context;

        public SignUpController(ILogger<SignUpController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            ViewBag.DeleteFooter = "True";
            
            if (ModelState.IsValid)
            {
                // Check if user with the same email already exists
                bool userExists = _context.Users.Any(u => u.Email == model.Email);

                if (userExists)
                {
                    ModelState.AddModelError("Email", "User with the same email already exists.");
                    return View(model);
                }

                _context.Users.Add(model.ToUser());
                
                _context.SaveChanges();

                return View("~/Views/SignUp/Confirm.cshtml");
            }

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}