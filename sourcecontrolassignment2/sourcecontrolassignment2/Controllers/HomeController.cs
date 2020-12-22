using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sourcecontrolassignment2.Models;
using System.Security.Cryptography;
using log4net;

namespace sourcecontrolassignment2.Controllers
{
    public class HomeController : Controller
    {

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        private DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            Logger.Info("Testing information log");
            Logger.Debug("Testing Debug log");
            Logger.Fatal("Testing Fatal log");
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    Logger.Info("Testing information log");
                    Logger.Debug("Testing Debug log");
                    Logger.Fatal("Testing Fatal log");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var data = _db.Users.Where(s => s.Email.Equals(login.Email) && s.Password.Equals(login.Password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Age"] = data.FirstOrDefault().Age;
                    Session["Phone"] = data.FirstOrDefault().Phone;
                    Session["Id"] = data.FirstOrDefault().Id;
                    Logger.Info("Testing information log");
                    Logger.Debug("Testing Debug log");
                    Logger.Fatal("Testing Fatal log");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View();
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            Logger.Info("Testing information log");
            Logger.Debug("Testing Debug log");
            Logger.Fatal("Testing Fatal log");
            return RedirectToAction("Login");
        }

    }
}