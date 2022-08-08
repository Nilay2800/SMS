﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
    public class AnnoucementController : BaseController
    {
        public readonly AnnoucementService annoucementService;


        public AnnoucementController()
        {
            annoucementService = new AnnoucementService();
        }
        // GET: Annoucement
        public ActionResult Index(string msg)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            ViewBag.Permission = GetPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString());
            
            return View();
        }

        [HttpGet]
        public ActionResult AddAnnoucement()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            
            ViewBag.RoleList = annoucementService.BindRole();
            return View();
        }


        [HttpPost]
        public ActionResult AddAnnoucement(AnnoucementModel annoucementModel)
        {
            
            annoucementService.CreateAnnoucement(annoucementModel);
            TempData["Message"] = Constants.EmailCodes.AnnouncementAdded;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAnnoucement(int Id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            AnnoucementModel annoucementModel = annoucementService.GetAnnocementById(Id);
            ViewBag.RoleList = annoucementService.BindRole();
            return View(annoucementModel);
        }


        [HttpPost]
        public ActionResult EditAnnoucement(AnnoucementModel annoucementModel)
        {
            AnnoucementModel annoucementModel1= annoucementService.UpdateAnnoucement(annoucementModel);
            TempData["Message"] = Constants.EmailCodes.AnnouncementEdit;
            return RedirectToAction("Index");

        }

        //public ActionResult Delete(int Id)
        //{
        //    if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsDelete))
        //    {
        //        return RedirectToAction("AccessDenied", "Base");
        //    }
        //    annoucementService.DeleteAnnoucement(Id);
        //    return RedirectToAction("Index");
        //}
        public ActionResult GetGridData([DataSourceRequest] DataSourceRequest request)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            List<AnnoucementModel> annoucements = annoucementService.GetAllAnnoucement();
            return Json(annoucements.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       // [HttpGet]
        public ActionResult AnnoucementDetails(int Id)
        {
            
            AnnoucementModel model = new AnnoucementModel();
            var annoucementDetails = annoucementService.GetAnnocementById(Id);
            return Json(RenderPartialViewToString(this, "_ErrorLogPopUp", annoucementDetails), JsonRequestBehavior.AllowGet);
        }
    }
}