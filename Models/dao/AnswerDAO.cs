using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class AnswerDAO : DAO
    {
        private static AnswerDAO instance;
    
        public static AnswerDAO Instance()
        {
            if (instance == null)
            {
                instance = new AnswerDAO();
            }

            return instance;
        }

        private AnswerDAO()
        {
        }

        public List<Answer> GetAnswersOfUser(int userId)
        {
            var ans = new List<Answer>();
            var idFinder = new MySqlCommand("select * from main_answer where user_id=" + userId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var questionId = (int)rd["question_id"];
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var answer = new Answer(id, content, day, hour, questionId, userId);
                ans.Add(answer);
            }
            rd.Close();
            return ans;
        }

        public int GetAnswerCount(int questionId)
        {
            int count = 0;
            var ans = new List<Answer>();
            ans = GetAnswers(questionId);
            count = ans.Count;
            return count;
        }

        public List<Answer> GetAnswers(int questionId)
        {
            var ans = new List<Answer>();
            var idFinder = new MySqlCommand("select * from main_answer where question_id=" + questionId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var userId = (int)rd["user_id"];
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var answer = new Answer(id, content, day, hour, questionId, userId);
                ans.Add(answer);
            }
            rd.Close();
            return ans;
        }

        public int CreateAnswer(string content, int userId, int questionId)
        {
            var hour = DateTime.Now.ToString("HH:m:s tt zzz");
            var day = DateTime.Now.ToString("yyyy MMMM dd");
            var cmd = new MySqlCommand("insert into main_answer (content, day, hour, user_id, question_id) values (\'" + content
                                       + "\', \'" + day + "\', \'" + hour + "\', \'" + userId + "\'," + questionId + ")", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();

            var idFinder = new MySqlCommand("select id from main_user where user_id=" + userId + " order by id desc limit 1", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                rd.Close();
                return id;
            }

            return 0;
        }
    }
}