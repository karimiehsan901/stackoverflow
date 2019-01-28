using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class QuestionCommentDAO : DAO
    {
        private static QuestionCommentDAO instance;

        public static QuestionCommentDAO Instance()
        {
            if (instance == null)
            {
                instance = new QuestionCommentDAO();
            }

            return instance;
        }

        private QuestionCommentDAO()
        {
        }

        public List<QuestionComment> GetCommentsOfQuestion(int questionId)
        {
            var ans = new List<QuestionComment>();
            var cmd = new MySqlCommand("select * from main_questioncomment where question_id=" + questionId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var userId = (int)rd["user_id"];
                var questionComment = new QuestionComment(id, content, day, hour, questionId, userId);
                ans.Add(questionComment);
            }
            rd.Close();
            return ans;
        }
    }
}