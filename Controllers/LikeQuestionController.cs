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
            string error = null;
            string message = null;
            var query = Logic.Logic.GetValue(Request, "islike", "");
            var questionId = int.Parse(Logic.Logic.GetValue(Request, "questionId", ""));
            var question = (Question)_questionDao.GetQuestionById(questionId);
            int id = 0;
            var sessionId = Logic.Logic.GetSessionId(Request);
            var userName = (string)_sessionDao.GetUsername(sessionId);
            var user = (User)_userDao.GetUserByUsername(userName);
            if (user != null)
            {
                if ((question.UserId != user.Id) && !(_likequestionDao.beforeLikedByThisUser(questionId, user.Id)))
                {
                    if (query == "1")
                    {
                        id = _likequestionDao.likeTheQuestion(questionId, user.Id, true);
                        message = "liked";
                    }
                    else if (query == "0")
                    {
                        message = "disliked";
                        id = _likequestionDao.likeTheQuestion(questionId, user.Id, false);
                    }
                    else
                    {
                        error = "query is wrong";
                    }
                }
                else
                {
                    error = "you cannot like this";
                }
            }
            else
            {
                error = "you are not login";
            }
            var result = new Dictionary<string, object> {["error"] = error, ["message"] = message};
            return Json(result);
        }
    }
}