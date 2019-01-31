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
            var questionId = int.Parse(Logic.Logic.GetValue(Request, "questionId", ""));
            var question = (Question)_questionDao.GetQuestionById(questionId);
            int id = 0;
            var _sessionId = Logic.Logic.GetSessionId(Request);
            var userName = (string)_sessionDao.GetUsername(_sessionId);
            var user = (User)_userDao.GetUserByUsername(userName);
            if ((question.UserId != user.Id) && !(_likequestionDao.beforeLikedByThisUser(questionId, user.Id)))
            {
                if (query == "1")
                {
                    id = _likequestionDao.likeTheQuestion(questionId, user.Id, true);
                }
                else if (query == "0")
                {
                    id = _likequestionDao.likeTheQuestion(questionId, user.Id, false);
                }
            }
            var result = new Dictionary<string, object> {["id"] = id, ["questionId"] = questionId, ["islike"] = query, ["userId"] = user.Id};
            return Json(result);
        }
    }
}