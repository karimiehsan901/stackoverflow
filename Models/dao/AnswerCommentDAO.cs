using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class AnswerCommentDAO : DAO
    {
        private static AnswerCommentDAO instance;

        public static AnswerCommentDAO Instance()
        {
            if (instance == null)
            {
                instance = new AnswerCommentDAO();
            }

            return instance;
        }

        private AnswerCommentDAO()
        {
        }

        public List<AnswerComment> GetCommentsOfanswer(int answerId)
        {
            var ans = new List<AnswerComment>();
            var cmd = new MySqlCommand("select * from main_answercomment where answer_id=" + answerId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var userId = (int)rd["user_id"];
                var answerComment = new AnswerComment(id, content, day, hour, answerId,userId);
                ans.Add(answerComment);
            }
            rd.Close();
            return ans;
        }
    }
}