using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return new JsonResult("[{ \"Day\": \"16:50:00\", \"Goal\": 23581 }, { \"Day\": \"16:45:00\", \"Goal\": 21000 }]");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
