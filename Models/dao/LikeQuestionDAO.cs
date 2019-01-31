using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class LikeQuestionDAO : DAO
    {
        private static LikeQuestionDAO instance;

        public static LikeQuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new LikeQuestionDAO();
            }

            return instance;
        }

        private LikeQuestionDAO()
        {
        }

        public int GetLikeCount(int questionId)
        {
            var idFinder = new MySqlCommand("select * from main_likequestion where question_id=" + questionId + " order by id desc",
                DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            int count = 0;
            while (rd.Read())
            {
                var userId = (int)rd["user_id"];
                var id = (int)rd["id"];
                var isLike = (bool)rd["is_like"];
                var answer = new LikeQuestion(id, questionId, userId, isLike);
                if (isLike)
                    count++;
                else count--;
            }
            rd.Close();
            return count;
        }

        public LikeQuestion likeTheQuestion(int questionId, int userId)
        {
            var idFinder = new MySqlCommand("select id from main_question where question_id=" + questionId + " order by id desc limit 1", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            LikeQuestion likeQuestion = null;
            while (rd.Read())
            {
                var id = (int)rd["id"];
                likeQuestion = new LikeQuestion(id, questionId, userId, true);
            }
            rd.Close();
            return likeQuestion;
        }

        public LikeQuestion disLikeTheQuestion(int questionId, int userId)
        {
            var idFinder = new MySqlCommand("select id from main_question where question_id=" + questionId + " order by id desc limit 1", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            LikeQuestion likeQuestion = null;
            while (rd.Read())
            {
                var id = (int)rd["id"];
                likeQuestion = new LikeQuestion(id, questionId, userId, false);
            }
            rd.Close();
            return likeQuestion;
        }
    }
}