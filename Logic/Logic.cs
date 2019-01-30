using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace stackoverflow.Logic
{
    public class Logic
    {
        public static string GetValue(HttpRequest request, string key, string defaultVal = null)
        {
            try
            {
                return request.Form[key];
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }

        public static void Log(string text)
        {
            File.AppendAllText("log.txt", text + Environment.NewLine);
        }

        public static bool IsValidName(string name)
        {
            return name != null && name.Length > 3;
        }

        public static bool IsValidUsername(string username)
        {
            if (username != null)
            {
                var regex = new Regex(@"^[a-z]([a-z0-9]|_[a-z0-9]|.[a-z0-9])+$");
                var m = regex.Match(username);
                return m.Success;
            }

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (email != null)
            {
                var reg = new Regex(@"^[a-z]([a-z0-9]|_[a-z0-9]|.[a-z0-9])+@[a-z0-9_]+([.][a-z0-9]+)+$");
                var match = reg.Match(email);
                return match.Success;
            }

            return false;
        }
       
        public static bool IsValidPassword(string password)
        {
            return password != null && password.Length > 5;
        }
        
        public static string GetSessionId(HttpRequest request)
        {
            return request.Cookies["session_id"];
        }
    }
}