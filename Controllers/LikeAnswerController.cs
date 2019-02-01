using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;
using System.Collections.Generic;

namespace stackoverflow.Controllers
{
    public class LikeAnswerController : Controller
    {
        private AnswerDAO _answerDAO = AnswerDAO.Instance();
        private LikeAnswerDAO _likeAnswerDAO = LikeAnswerDAO.Instance();
        private UserDAO _userDAO = UserDAO.Instance();
        private SessionDAO _sessionDAO = SessionDAO.Instance();
        public IActionResult Index()
        {
            string error = null;
            string message = null;
            var query = Logic.Logic.GetValue(Request, "islike", "");
            var answerId = int.Parse(Logic.Logic.GetValue(Request, "answerId", ""));
            var sessionId = Logic.Logic.GetSessionId(Request);

            var answer = (Answer)_answerDAO.GetAnswerById(answerId);
            int id = 0;
            var userName = (string)_sessionDAO.GetUsername(sessionId);
            var user = (User)_userDAO.GetUserByUsername(userName);
            if (user != null)
            {
                if ((answer.UserId != user.Id) && !(_likeAnswerDAO.beforeLikedByThisUser(answerId, user.Id)))
                {
                    if (query == "1")
                    {
                        message = "liked";
                        id = _likeAnswerDAO.likeTheAnswer(answerId, user.Id, true);
                    }
                    else if (query == "0")
                    {
                        message = "disliked";
                        id = _likeAnswerDAO.likeTheAnswer(answerId, user.Id, false);
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

            var result = new Dictionary<string, object> { ["message"] = message, ["error"] = error};
            return Json(result);
        }
    }
}