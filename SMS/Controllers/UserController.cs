using SMS.Data;
using SMS.Data.Database;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMS.Controllers
{
    public class UserController : Controller
    {
        SMSContext smsContext = new SMSContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignupModel model)
        {
            Signup s = new Signup();
            s.Email = model.Email;
            s.UserName = model.UserName;
            s.Password = model.Password;
            s.ConfirmPassword = model.ConfirmPassword;
            smsContext.signups.Add(s);
            smsContext.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SignupModel model)
        {
            Signup s = smsContext.signups.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).SingleOrDefault();
            if (s != null)
            {
                Session["UserId"] = s.Userid.ToString();
                Session["UserName"] = s.UserName.ToString();
                Session["Email"] = s.Email.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Invalid Email or Password";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}