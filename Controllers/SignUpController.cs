using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace stackoverflow.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            var name = Logic.Logic.GetValue(Request, "name");
            var username = Logic.Logic.GetValue(Request, "username");
            var password = Logic.Logic.GetValue(Request, "password");
            var email = Logic.Logic.GetValue(Request, "email");
            if (Logic.Logic.IsValidName(name) && Logic.Logic.IsValidUsername(username)
                && Logic.Logic.IsValidPassword(password) && Logic.Logic.IsValidEmail(email))
            {
                var connectionString = "Server=localhost; database=stack_overflow; UID=root; password=13771998;SslMode=none";
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var checkExist = new MySqlCommand("select id from main_user where username=\'" + username + "\'" + "or email=\'" + email + "\'", conn);
                    MySqlDataReader dr = checkExist.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        var cmd = new MySqlCommand("insert into main_user (name, username, password, email) values (\'" + name + "\',\'" + username + "\',\'" + password + "\',\'" + email + "\')", conn);
                        cmd.ExecuteNonQuery();
                        var sessionid = HttpContext.Session.Id;
                        cmd = new MySqlCommand("insert into main_session (session_id, session_key, value) values (\'" + sessionid + "\',\'username\',\'" + username + "\')", conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Logic.Logic.Log("exists");
                    }
                }

            }
            else
            {
                Logic.Logic.Log("invalid");
            }
            return View();
        }
        
    }
}