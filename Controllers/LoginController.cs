using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}