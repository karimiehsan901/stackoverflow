using System;
using stackoverflow.Logic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using stackoverflow.Models.dao;
using stackoverflow.Models.db;
using System.Collections.Generic;

namespace stackoverflow.Controllers
{
    public class QuestionController : Controller
    {
        private SessionDAO _sessionDao = SessionDAO.Instance();
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        private LikeQuestionDAO _likequestionDao = LikeQuestionDAO.Instance();
        private LikeAnswerDAO _likeanswerDao = LikeAnswerDAO.Instance();
        private TagDAO _tagDao = TagDAO.Instance();
        private TagQuestionDAO _tagquestionDao = TagQuestionDAO.Instance();
        private AnswerDAO _answerDao = AnswerDAO.Instance();
        private AnswerCommentDAO _answercommentDao = AnswerCommentDAO.Instance();
        private QuestionCommentDAO _questioncommentDao = QuestionCommentDAO.Instance();
        private UserDAO _userDao = UserDAO.Instance();
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetString("init", "0");
//            HttpContext.Session.SetString("test", "test session");
            var sid = HttpContext.Session.Id;

            //my code
            var question = (Question)_questionDao.GetQuestionById(id);
            var questionLikeCount = (int)_likequestionDao.GetLikeCount(id);
            var tagQuestion = (List<TagQuestion>)_tagquestionDao.GetTagsOfQuestion(id);
            var tags = new List<Tag>();
            var answers = (List<Answer>)_answerDao.GetAnswers(question.Id);
            var answerCount = (int)_answerDao.GetAnswerCount(question.Id);
            var questionComments = (List<QuestionComment>)_questioncommentDao.GetCommentsOfQuestion(id);

            foreach (var tq in tagQuestion)
            {
                var tag = _tagDao.GetTagById(tq.TagId);
                tags.Add(tag);
            }

            ViewData["questionTitle"] = question.Title;
            ViewData["questionContent"] = question.Content;
            ViewData["questionDay"] = question.Day;
            ViewData["questionHour"] = question.Hour;
            ViewData["questionUserId"] = question.UserId;
            ViewData["questionLikeCount"] = questionLikeCount;
            ViewData["tags"] = tags;
            ViewData["answers"] = answers;
            ViewData["answer_count"] = answerCount;
            ViewData["question_comments"] = questionComments;
            var ans = new List<Dictionary<string, object>>();
            if (answers != null)
            {
                foreach (var answer in answers)
                {
                    if (answer != null)
                    {
                        var answerComments = (List<AnswerComment>)_answercommentDao.GetCommentsOfanswer(answer.Id);
                        var answerLikeCount = (int)_likeanswerDao.GetLikeCountAnswer(answer.Id);

                        var dic = new Dictionary<string, object>
                        {
                            ["answerContent"] = answer.Content,
                            ["answerDay"] = answer.Day,
                            ["answerHour"] = answer.Hour,
                            ["answerUserId"] = answer.UserId,
                            ["answerquestionId"] = answer.QuestionId,
                            ["answerLikeCount"] = answerLikeCount,
                            ["answer_comments"] = answerComments
                        };
                        ans.Add(dic);
                    }
                }
                ViewData["ans"] = ans;
            }

            var sessionId = Logic.Logic.GetSessionId(Request);
            //var sessionId = HttpContext.Session.Id;
            var userName = (string)_sessionDao.GetUsername(sessionId);
            var user = (User)_userDao.GetUserByUsername(userName);
            ViewData["user"] = user;
            var content = Logic.Logic.GetValue(Request, "content");
            if(content != null)
            {
                var title = Logic.Logic.GetValue(Request, "title");
                var createdanswer = (int)_answerDao.CreateAnswer(title, content, user.Id, question.Id); 
            }
            ViewData["id"] = sid;
            return View();
        }
        
    }
}