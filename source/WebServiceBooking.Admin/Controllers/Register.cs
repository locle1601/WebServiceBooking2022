using Microsoft.AspNetCore.Mvc;

namespace WebServiceBooking.Admin.Controllers
{
    public class Register : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
