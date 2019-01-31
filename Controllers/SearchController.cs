using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using stackoverflow.Models.dao;

namespace stackoverflow.Controllers
{
    public class SearchController : Controller
    {
        private QuestionDAO _questionDao = QuestionDAO.Instance();
        public IActionResult Index()
        {
            var query = Logic.Logic.GetValue(Request, "query", "");
            var questions = _questionDao.Search(query);
            var ans = new List<Dictionary<string, object>>();
            foreach (var question in questions)
            {
                var dic = new Dictionary<string, object> {["id"] = question.Id, ["title"] = question.Title};
                ans.Add(dic);
            }
            return Json(ans);
        }
    }
}