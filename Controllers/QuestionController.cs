using System;
using stackoverflow.Logic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace stackoverflow.Controllers
{
    public class QuestionController : Controller
    {
        
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetString("init", "0");
//            HttpContext.Session.SetString("test", "test session");
            var sid = HttpContext.Session.Id;
            
            ViewData["id"] = sid;
            return View();
        }
        
    }
}