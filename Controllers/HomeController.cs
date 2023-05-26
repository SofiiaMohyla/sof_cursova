using Microsoft.AspNetCore.Mvc;
using sof_curs.Entity;
using sof_curs.Models;
using System.Diagnostics;

namespace sof_curs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookATable(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(model.ToOrder());
                _context.SaveChanges();

                ViewBag.ShowMessage = true;
                return View("~/Views/Home/Index.cshtml");
            }
            return View("~/Views/Home/Index.cshtml",model);

        }

        public IActionResult SignUp()
        {
            ViewBag.DeleteFooter = "True";
            return View("~/Views/SignUp/SignUp.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}