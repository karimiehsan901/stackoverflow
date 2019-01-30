using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;

namespace stackoverflow.Controllers
{
    public class LogoutController : Controller
    {
        private SessionDAO _sessionDao = SessionDAO.Instance();
        public IActionResult Index()
        {
            _sessionDao.Logout(Logic.Logic.GetSessionId(Request));
            return RedirectToAction("Index", "Home");
        }
    }
}