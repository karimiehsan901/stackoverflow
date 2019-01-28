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

        public List<TagQuestion> GetTagsOfQuestion(int questionId)
        {
            var ans = new List<TagQuestion>();
            var idFinder = new MySqlCommand("select * from main_question where user_id=" + questionId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                var tagId = (int)rd["tag_id"];
                var tagQuestion = new TagQuestion(id, questionId, tagId);
                ans.Add(tagQuestion);
            }
            rd.Close();
            return ans;
        }
    }
}