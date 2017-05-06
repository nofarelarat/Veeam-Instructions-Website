using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Restore()
        {
            ViewBag.Message = "Restore Veeam page.";

            return View();
        }
        public ActionResult Backup()
        {
            ViewBag.Message = "Backup Veeam page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Registration WebSite page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Login WebSite page.";

            return View();
        }


        [HttpPost]
        public ActionResult Reg_user()
        {
            string name = Request.Form["name"];
            /*int id = Convert.ToInt32(Request.Form["id"]);*/
            int id = int.Parse(Request.Form["id"]);
            string password = Request.Form["pass1"];

            UserInfo user = new UserInfo(id,name,password);
            if(user.AddUser() == false)
            {
                Console.WriteLine ("cant c");
                return View("Register");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Log_user()
        {
            int id = int.Parse(Request.Form["id"]);
            string password = Request.Form["pass1"];
            try
            {
                UserInfo user=new UserInfo(0, null, null);
                user.GetUser(id);
                if (user.getpass() != null) {
                    if (!user.getpass().Equals(password))
                    {
                        Console.WriteLine("worng password");
                    }
                    else
                    {
                        Console.WriteLine("success");
                        return View("Index");
                    }
                }
            }
            catch
            {
                Console.WriteLine("cant find user");
            }
            return View("Login");
        }
    }
}