using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace stackoverflow.Controllers
{
    public class LoginController : Controller
    {
        private SessionDAO _sessionDao = SessionDAO.Instance();
        private UserDAO _userDao = UserDAO.Instance();
        public IActionResult Index()
        {
            var username = Logic.Logic.GetValue(Request, "username");
            var password = Logic.Logic.GetValue(Request, "password");
            var usr = (User)   _userDao.GetUserByUsernameAndPassword(username, password);
            if(usr != null)
            {
                _sessionDao.Login(Logic.Logic.GetSessionId(Request), username);
                return RedirectToAction("Index", "Home");
            }
            else if(Request.Method=="POST")
            {
                ViewData["error"] = "your password or username is incorrect";
            }

            return View();

        }
        
    }
}