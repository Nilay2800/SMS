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
    public class AccountController : Controller
    {
        private readonly FormRoleMappingService formRoleMappingService;
        public AccountController()
        {
            formRoleMappingService = new FormRoleMappingService();
        }
       
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
        public ActionResult Signup(Signups model)
        {
            StudentEntites smsContext = new StudentEntites();
            var check = smsContext.signups.FirstOrDefault(s => s.Email == model.Email);
            if (check == null)
            {
                smsContext.signups.Add(model);
                smsContext.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }
        }
          
    
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                using (StudentEntites smsContext = new StudentEntites())
                {
                    var v = smsContext.signups.Where(a => a.Email == model.EmailId && a.Password==model.Password).FirstOrDefault();
                    if (v != null)
                    {
                        SessionHelper.EmailId = model.EmailId;
                        string returnUrl = Request.QueryString["ReturnUrl"];
                        var p = smsContext.signups.Where(a => a.Password == model.Password ).FirstOrDefault();
                        //if (p != null)
                        //{
                            int timeout = model.RememberMe ? 525600 : 60; // 525600 min = 1 year
                            var ticket = new FormsAuthenticationTicket(model.EmailId, model.RememberMe, timeout);
                            string encrypted = FormsAuthentication.Encrypt(ticket);
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                            cookie.HttpOnly = true;
                            Response.Cookies.Add(cookie);

                            if (returnUrl == null)
                            {

                                var userId = WebSecurity.GetUserId(model.EmailId);
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
                            ModelState.AddModelError("Password", " Email id or Password is invalid.");
                        }
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("EmailId", "EmailId is not registered.");
                    //}

                    return View(model);
                }
            }
            else
            {
                return View(model);
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