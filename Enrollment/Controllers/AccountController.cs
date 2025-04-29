using Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enrollment.Controllers
{
    public class AccountController : Controller
    {
        private static List<UserInfo> users = new List<UserInfo>()
        {
            new UserInfo { userName = "admin", password = "admin", IsAdmin = true },
            new UserInfo { userName = "user", password = "user", IsAdmin = false }
        };
        
        // GET: Account
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Username = Session["Username"];
            return View();
        }
        public ActionResult Login()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Login (string userName , string password)
        {
            if (users.Any(a => a.userName == userName && a.password == password))
            {
                var currentUser = users.Where(u => u.userName == userName && u.password == password).FirstOrDefault();

                if (currentUser != null)
                {
                    Session["userName"] = currentUser.userName;
                    Session["IsAdmin"] = currentUser.IsAdmin;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View("Index");
                }
            }
            return View("Index");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string password)
        {
            if (users.Any(a => a.userName == userName))
            {
                ViewBag.ErrorMessage = "Username already exists";
                return View("Register");
            }
            else
            {
                users.Add(new UserInfo { userName = userName, password = password, IsAdmin = false });
                return RedirectToAction("Login");
            }
        }
        public ActionResult Dashboard()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Username = Session["Username"];
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}