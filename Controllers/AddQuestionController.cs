using Microsoft.AspNetCore.Mvc;

namespace stackoverflow.Controllers
{
    public class AddQuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}