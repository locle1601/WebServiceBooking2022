using Microsoft.AspNetCore.Mvc;

namespace WebServiceBooking.Admin.Controllers
{
    public class Forgotpassword : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
