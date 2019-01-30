using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;

namespace stackoverflow.Controllers
{
    public class ProfileController : Controller
    {
        private UserDAO _userDAO = UserDAO.Instance();
        private SessionDAO _sessionDAO = SessionDAO.Instance();
        private QuestionDAO _questionDAO = QuestionDAO.Instance();
        private AnswerDAO _answerDAO = AnswerDAO.Instance();
        private TagQuestionDAO _tagQuestionDAO = TagQuestionDAO.Instance();
        private TagDAO _tagDAO = TagDAO.Instance();
        private LikeQuestionDAO likeQuestionDAO = LikeQuestionDAO.Instance();

        public IActionResult Index()
        {
            var sessionId = Logic.Logic.GetSessionId(Request);
            var username = _sessionDAO.GetUsername(sessionId);
            if (username != null)
            {
                var user = _userDAO.GetUserByUsername(username);
                if (user != null)
                {
                    var questions = _questionDAO.GetQuestionsOfUser(user.Id);
                    var answers = _answerDAO.GetAnswersOfUser(user.Id);
                    var dic = new Dictionary<string, object>
                    {
                        ["id"] = user.Id,
                        ["name"] = user.Name,
                        ["password"] = user.Password,
                        ["username"] = user.Username,
                        ["email"] = user.Email
                    };
                    if (questions != null)
                    {
                        dic["questions"] = questions;
                    }
                    if (answers != null)
                    {
                        dic["answers"] = answers;
                    }
                    ViewData["dataOfUser"] = dic;
                }
                else
                {
                    return RedirectToAction("index", "Login");
                }
            }
            else
            {
                return RedirectToAction("index", "Login");
            }
            return View();
        }
        
    }
}