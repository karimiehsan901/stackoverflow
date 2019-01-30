using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace stackoverflow.Controllers
{
    public class AddQuestionController : Controller
    {
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        private SessionDAO _sessionDao = SessionDAO.Instance();
        private UserDAO _userDao = UserDAO.Instance();
        private TagDAO _tagDao = TagDAO.Instance();
        private TagQuestionDAO _tagQuestionDao = TagQuestionDAO.Instance();

        public IActionResult Index()
        {
            var sessionId = Logic.Logic.GetSessionId(Request);
            var title = Logic.Logic.GetValue(Request, "title");
            var content = Logic.Logic.GetValue(Request, "body");
            var tags = Logic.Logic.GetValue(Request, "tags");
            
            var username = _sessionDao.GetUsername(sessionId);
            var user = (User)  _userDao.GetUserByUsername(username);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (title != null && content != null && tags != null)
            {
                var ts = tags.Split(' ');
                var questionId = _questionDao.CreateQuestion(title, content,user.Id);
                

                foreach (string tagtmp in ts)
                {

                    if (_tagDao.GetTag(tagtmp) == null)
                    {
                        //create tag
                         _tagDao.CreatTag(tagtmp);
                        
                    }
                    //get tagId
                    var tag =  (Tag) _tagDao.GetTag(tagtmp);
                    var tagId = tag.Id;

                    //create question tag
                    _tagQuestionDao.CreateTagQuestion(questionId, tagId);

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