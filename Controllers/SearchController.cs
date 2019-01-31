using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return Json("a");
        }
    }
}