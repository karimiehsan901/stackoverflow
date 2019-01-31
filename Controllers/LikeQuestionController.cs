using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;
using System.Collections.Generic;

namespace stackoverflow.Controllers
{
    public class LikeQuestionController : Controller
    {
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        private LikeQuestionDAO _likequestionDao = LikeQuestionDAO.Instance();
        private UserDAO _userDao = UserDAO.Instance();
        private SessionDAO _sessionDao = SessionDAO.Instance();
        public IActionResult Index()
        {
            var query = Logic.Logic.GetValue(Request, "islike", "");
            var questionId = int.Parse(Logic.Logic.GetValue(Request, "uestionId", ""));
            LikeQuestion likeQuestions = null;
            var _sessionId = Logic.Logic.GetSessionId(Request);
            var userName = (string)_sessionDao.GetUsername(_sessionId);
            var user = (User)_userDao.GetUserByUsername(userName);
            if (query == "1")
            {
                likeQuestions = _likequestionDao.likeTheQuestion(questionId, user.Id);
            }
            else if(query == "0")
            {
                likeQuestions = _likequestionDao.disLikeTheQuestion(questionId, user.Id);
            }
            var result = new Dictionary<string, object> {["id"] = questionId, ["islike"] = query, ["userId"] = user.Id};
            return Json(result);
        }
    }
}