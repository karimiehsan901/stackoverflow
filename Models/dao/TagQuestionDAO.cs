using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class TagQuestionDAO : DAO
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
            var idFinder = new MySqlCommand("select * from main_tagquestion where question_id=" + questionId + " order by id desc", DBConnection.Instance().MySqlConnection);
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

        public void CreateTagQuestion(int questionId, int tagId)
        {
            var idFinder = new MySqlCommand("insert into main_tagquestion (tag_id, question_id) values (" + tagId + "," + questionId + ")", DBConnection.Instance().MySqlConnection);
            idFinder.ExecuteNonQuery();
        }
    }
}