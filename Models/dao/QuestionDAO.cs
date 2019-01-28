using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class QuestionDAO : DAO
    {
        private static QuestionDAO instance;

        public static QuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new QuestionDAO();
            }

            return instance;
        }

        private QuestionDAO()
        {
        }

        public List<Question> GetLastQuestions()
        {
            var ans = new List<Question>();
            var cmd = new MySqlCommand("select * from main_question order by id desc limit 10", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var title = (string)rd["title"];
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var userId = (int)rd["user_id"];
                var question = new Question(id, content, day, hour, title, userId);
                ans.Add(question);
            }
            rd.Close();
            return ans;
        }

        public int CreateQuestion(string title, string content, int userId)
        {
            var hour = DateTime.Now.ToString("HH:m:s tt zzz");
            var day = DateTime.Now.ToString("yyyy MMMM dd");
            var cmd = new MySqlCommand("insert into main_question (title, content, day, hour, user_id) values (\'" + title+"\', \'" + content
                                       + "\', \'" + day + "\', \'" + hour + "\'," + userId + ")", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();
            
            var idFinder = new MySqlCommand("select id from main_question where user_id=" + userId + " order by id desc limit 1", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                rd.Close();
                return id;
            }

            return 0;
        }

        public List<Question> GetQuestionsOfUser(int userId)
        {
            var ans = new List<Question>();
            var idFinder = new MySqlCommand("select * from main_question where user_id=" + userId + " order by id desc", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var title = (string)rd["title"];
                var id = (int)rd["id"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var question = new Question(id, content, day, hour, title, userId);
                ans.Add(question);
            }
            rd.Close();
            return ans;
        }

        public Question GetQuestionById(int id)
        {
            var cmd = new MySqlCommand("select * from main_question where id=" + id, DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                var title = (string)rd["title"];
                var content = (string)rd["content"];
                var day = (string)rd["day"];
                var hour = (string)rd["hour"];
                var userId = (int)rd["user_id"];
                var question = new Question(id, content, day, hour, title, userId);
                return question;
            }

            return null;
        }
    }
}