using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class TagQuestionDAO
    {
        private static TagQuestionDAO instance;

        public static TagQuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new TagQuestionDAO();
            }

            return instance;
        }

        private TagQuestionDAO()
        {
        }

        public List<Tag> GetTagsOfQuestion(int questionId)
        {
            var ans = new List<Tag>();
            var idFinder = new MySqlCommand("select * from main_question where user_id=" + questionId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var title = (string)rd["title"];
                var id = (int)rd["id"];
                var tag = new Tag(id, title);
                ans.Add(tag);
            }
            rd.Close();
            return ans;
        }
    }
}