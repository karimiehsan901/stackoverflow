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
    public class HomeController : Controller
    {
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        private TagDAO _tagDao = TagDAO.Instance();
        private TagQuestionDAO _tagQuestionDao = TagQuestionDAO.Instance();
        private AnswerDAO _answerDao = AnswerDAO.Instance();
        public IActionResult Index()
        {
            var questions = _questionDao.GetLastQuestions();
            var ans = new List<Dictionary<string, object>>();
            foreach (var question in questions)
            {
                var tags = new List<Tag>();
                var tagQuestions = _tagQuestionDao.GetTagsOfQuestion(question.Id);
                foreach (var tagQuestion in tagQuestions)
                {
                    var tag = _tagDao.GetTagById(tagQuestion.TagId);
                    tags.Add(tag);
                }
                var dic = new Dictionary<string, object>
                {
                    ["title"] = question.Title, ["answerCount"] = _answerDao.GetAnswerCount(question.Id)
                    ,["tags"] = tags
                };
                
                ans.Add(dic);
            }

            ViewData["ans"] = ans;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
