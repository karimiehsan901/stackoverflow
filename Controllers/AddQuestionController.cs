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
    public class AddQuestionController : Controller
    {
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        private SessionDAO _sessionDao = SessionDAO.Instance();
        private UserDAO _userDao = UserDAO.Instance();
        private TagDAO _tagDao = TagDAO.Instance();

        public IActionResult Index()
        {
            var sessionId = HttpContext.Session.Id;
            var title = Logic.Logic.GetValue(Request, "title");
            var content = Logic.Logic.GetValue(Request, "body");
            var tags = Logic.Logic.GetValue(Request, "tags");
            var ts = tags.Split(' ');
            var username = _sessionDao.GetUsername(sessionId);
            var user = (User)  _userDao.GetUserByUsername(username);

            if (title != null && content != null)
            {
                var usr = _questionDao.CreateQuestion(title, content,user.Id);
                //get questionid

                foreach(string tag in ts)
                {

                    if (_tagDao.GetTag(tag) == null)
                    {
                        _tagDao.CreatTag(tag);   
                    }

                    //get tagId
                    //crate question tag

                }
            }
            else if (Request.Method == "POST")
            {
                ViewData["errorAddQuestion"] = "title and body are requirement";
            }

            

            return View();
        }
        
    }
}