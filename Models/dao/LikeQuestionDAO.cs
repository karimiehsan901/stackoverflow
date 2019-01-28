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
            var idFinder = new MySqlCommand("select * from main_question where user_id=" + questionId + " order by id desc",
                DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            int count = 0;
            while (rd.Read())
            {
                var userId = (int)rd["userId"];
                var id = (int)rd["id"];
                var isLike = (bool)rd["isLike"];
                var answer = new LikeQuestion(id, questionId, userId, isLike);
                if (isLike)
                    count++;
            }
            rd.Close();
            return count;
        }
    }
}