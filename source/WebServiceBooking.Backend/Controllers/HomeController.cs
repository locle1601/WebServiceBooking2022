using Microsoft.AspNetCore.Mvc;

namespace WebServiceBooking.Backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
