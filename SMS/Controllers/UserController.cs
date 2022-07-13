using SMS.Data;
using SMS.Data.Database;
using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SMS.Controllers
{
    public class UserController : Controller
    {
        private readonly FormRoleMappingService formRoleMappingService;
        public UserController()
        {
            formRoleMappingService = new FormRoleMappingService();
        }
        StudentEntites smsContext = new StudentEntites();
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
            Signups s = new Signups();
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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SignupModel model, string ReturnUrl = "")
        {
            //Signups s = smsContext.signups.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).SingleOrDefault();
            //if (s != null)
            //{
            //    Session["UserId"] = s.Userid.ToString();
            //    Session["UserName"] = s.UserName.ToString();
            //    Session["Email"] = s.Email.ToString();
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewBag.msg = "Invalid Email or Password";
            //}
            //return View();
           
         
                using (StudentEntites dc = new StudentEntites())
                {
                    var v = dc.signups.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();
                if (v != null)
                {
                    SessionHelper.EmailId = model.Email;
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (returnUrl == null)
                    {

                        var userId = WebSecurity.GetUserId(model.Email);
                        Session["UserName"] = v.UserName.ToString();
                        Session["Email"] = v.Email.ToString();
                        Session["Menu"] = formRoleMappingService.GetMenu(userId);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }
                }

                else
                {
                    ViewBag.msg = "Invalid Email or Password";
                }
                        return View();
                }
          
        }
    
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}