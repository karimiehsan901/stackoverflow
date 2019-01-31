using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class LikeAnswerController : Controller
    {
        public IActionResult Index()
        {
            return Json("a");
        }
    }
}