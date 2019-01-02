using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}