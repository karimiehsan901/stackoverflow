using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class LikeAnswerDAO : DAO
    {
        private static LikeAnswerDAO instance;

        public static LikeAnswerDAO Instance()
        {
            if (instance == null)
            {
                instance = new LikeAnswerDAO();
            }

            return instance;
    
        }

        private LikeAnswerDAO()
        {

        }



        public int PlusLikesAnswer(int answerId,int userId)
        {
            int count = 0;
            var cmd = new MySqlCommand("select * from main_likeanswer where answer_id=" + answerId + "and user_id=" + userId , DBConnection.Instance().MySqlConnection);
            
            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                var cmd2 = new MySqlCommand("update main_likeanswer where answer_id=" + answerId + "and user_id=" + userId + "set is_like=true", DBConnection.Instance().MySqlConnection);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                var cmd2 = new MySqlCommand("insert into main_likeanswer (answer_id, user_id, is_like) values (\'" + answerId + "\', \'" + userId
                                     + "\', \'true)", DBConnection.Instance().MySqlConnection);
                cmd2.ExecuteNonQuery();

            }
            rd.Close();

            var cmd3 = new MySqlCommand("select * from main_likeanswer where answer_id=" + answerId + "and is_like=true", DBConnection.Instance().MySqlConnection);
            var rd2 = cmd3.ExecuteReader();

            while (rd2.Read())
            {
                count++;
            }
            rd2.Close();

            return count;
        }

        public bool beforeLikedByThisUser(int answerId, int userId)
        {
            var idFinder = new MySqlCommand
                ("select id from main_likeanswer where answer_id=" + answerId + " order by id desc limit 1",
                DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                if ((int)rd["user_id"] == userId)
                    return true;
            }
            rd.Close();
            return false;
        }

        public int likeTheAnswer(int answerId, int userId, bool isLike)
        {
            var cmd = new MySqlCommand("insert into main_likeanswer (answer_id, user_id, is_like) values (\'" + answerId + "\', \'" + userId
                                       + "\'," + isLike + ")", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();

            var idFinder = new MySqlCommand("select id from main_likeanswer where answer_id=" + answerId + " order by id desc limit 1", DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            while (rd.Read())
            {
                var id = (int)rd["id"];
                rd.Close();
                return id;
            }
            return 0;
        }


        public int DisLikesAnswer(int answerId, int userId)
        {
            int count = 0;
            var cmd = new MySqlCommand("select * from main_likeanswer where answer_id=" + answerId + "and user_id=" + userId, DBConnection.Instance().MySqlConnection);

            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                var cmd2 = new MySqlCommand("update main_likeanswer where answer_id=" + answerId + "and user_id=" + userId + "set is_like=false", DBConnection.Instance().MySqlConnection);
                cmd2.ExecuteNonQuery();
            }
          

            var cmd3 = new MySqlCommand("select * from main_likeanswer where answer_id=" + answerId + "and is_like=true", DBConnection.Instance().MySqlConnection);
            var rd2 = cmd3.ExecuteReader();

            while (rd2.Read())
            {
                count++;
            }
            rd2.Close();

            return count;
        }

        public int GetLikeCountAnswer(int answerId)
        {
            var idFinder = new MySqlCommand("select * from main_likeanswer where answer_id=" + answerId,
                DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            int count = 0;
            while (rd.Read())
            {
                
                var isLike = (bool)rd["is_like"];
                
                if (isLike)
                    count++;
            }
            rd.Close();
            return count;
        }


    }
}