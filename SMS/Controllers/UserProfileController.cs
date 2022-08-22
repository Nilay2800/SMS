using SMS.Helper;
using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class UserProfileController : BaseController
    {
        public readonly UserProfileService userProfileService;
        public UserProfileController()
        {
            userProfileService = new UserProfileService();
        }
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditUserProfile()
        {
            
            UserProfileModel userProfileModel = userProfileService.GetUserProfileById();
            return View(userProfileModel);
        }


        [HttpPost]
        public ActionResult EditUserProfile(UserProfileModel userProfileModel)
        {
            //UserProfileModel userProfileModel1 = userProfileService.UpdateUserProfile(userProfileModel);
            userProfileService.UpdateUserProfile(userProfileModel);
           
            return RedirectToAction("Index","Home");

        }
    }
}