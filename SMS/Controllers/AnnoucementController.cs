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
        public ActionResult Index()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            ViewBag.Permission = GetPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString());
            List<AnnoucementModel> annoucements = annoucementService.GetAllAnnoucement();
            return View(annoucements);
        }

        [HttpGet]
        public ActionResult AddAnnoucement()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            return View();
        }


        [HttpPost]
        public ActionResult AddAnnoucement(AnnoucementModel annoucementModel)
        {
            annoucementService.CreateAnnoucement(annoucementModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAnnoucement(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            AnnoucementModel annoucementModel = annoucementService.GetAnnocementById(id);
            return View(annoucementModel);
        }


        [HttpPost]
        public ActionResult EditAnnoucement(AnnoucementModel annoucementModel)
        {
            AnnoucementModel annoucementModel1= annoucementService.UpdateAnnoucement(annoucementModel);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Annoucement.ToString(), AcessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            annoucementService.DeleteAnnoucement(Id);
            return RedirectToAction("Index");
        }
    }
}