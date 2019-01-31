using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class LikeQuestionController : Controller
    {
        public IActionResult Index()
        {
            return Json("a");
        }
    }
}