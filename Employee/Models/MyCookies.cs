using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class MyCookies
    {
        public static void SaveUser(User user)
        {
            HttpContext.Current.Response.Cookies["UserData"].Value = JsonConvert.SerializeObject(user);
        }
        public static void Logout()
        {
            HttpContext.Current.Response.Cookies["UserData"].Expires = DateTime.Now.Date.AddDays(-1);
        }
        public static User UserDetails
        {
            get
            {
                User user;
                try
                {
                    string Ud = HttpContext.Current.Request.Cookies["UserData"].Value;
                    user = JsonConvert.DeserializeObject<User>(Ud);
                    return user;
                }
                catch(Exception ex)
                {
                    user = new User();
                    return user;
                }
            }
        }
        public static bool AuthUser
        {
            get
            {
                string Email = UserDetails.Email;
                string Pass = UserDetails.Password;
                Contxt db = new Contxt();
                var user = db.User.Where(b => b.Email == Email && b.Password == Pass && b.Status == true).FirstOrDefault();
                if (user != null)
                {
                    db.Dispose();
                    return true;
                }
                db.Dispose();
                return false;
            }
        } 
    }
}