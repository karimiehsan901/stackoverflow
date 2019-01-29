using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

namespace stackoverflow.Models.dao
{
    public class TagDAO : DAO
    {
        private static TagDAO instance;

        public static TagDAO Instance()
        {
            if (instance == null)
            {
                instance = new TagDAO();
            }

            return instance;
        }

        private TagDAO()
        {
        }


        public int CreatTag(string title)
        {
            var idFinder = new MySqlCommand("select * from main_tag where title=" + title, DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            if (rd.Read())
            {
                var id = (int)rd["id"];
                rd.Close();
                return id;
            }
            else
            {
                var cmd = new MySqlCommand("insert into main_tag (title) values (\'" + title + ")", DBConnection.Instance().MySqlConnection);
                cmd.ExecuteNonQuery();
                return 0;
            }

        }

        public int GetTag(string title)
        {
    
            var idFinder = new MySqlCommand("select * from main_tag where title=" + title, DBConnection.Instance().MySqlConnection);
            var rd = idFinder.ExecuteReader();
            if (rd.Read())
            {
                var id = (int)rd["id"];
                rd.Close();
                return id;
            }

            return 0;
        }
    }
}