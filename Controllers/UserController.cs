using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
