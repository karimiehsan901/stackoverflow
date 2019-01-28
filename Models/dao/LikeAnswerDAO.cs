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
        
    }
}