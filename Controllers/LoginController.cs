using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;

namespace stackoverflow.Controllers
{
    public class LoginController : Controller
    {
        private SessionDAO _sessionDao = SessionDAO.Instance();
        public IActionResult Index()
        {
            var username = Logic.Logic.GetValue(Request, "username");
            var password = Logic.Logic.GetValue(Request, "password");
            _sessionDao.Login(HttpContext.Session.Id, username);
            return View();
        }
        
    }
}