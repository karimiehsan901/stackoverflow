using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;

namespace stackoverflow.Controllers
{
    public class SignUpController : Controller
    {
        private UserDAO _userDao = UserDAO.Instance();
        private SessionDAO _sessionDao = SessionDAO.Instance();
        public IActionResult Index()
        {
            var name = Logic.Logic.GetValue(Request, "name");
            var username = Logic.Logic.GetValue(Request, "username");
            var password = Logic.Logic.GetValue(Request, "password");
            var email = Logic.Logic.GetValue(Request, "email");
            if (Logic.Logic.IsValidName(name) && Logic.Logic.IsValidUsername(username)
                && Logic.Logic.IsValidPassword(password) && Logic.Logic.IsValidEmail(email))
            {
                if (!_userDao.Exists(email, username))
                {
                    _userDao.CreateUser(username, password, email, name);
                    _sessionDao.Login(HttpContext.Session.Id, username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["error"] = "username or email is duplicated";
                }
            }
            else if (Request.Method == "POST")
            {
                ViewData["error"] = "a field is invalid";
            }
            return View();
        }
        
    }
}