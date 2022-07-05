using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class AnnoucementController : Controller
    {
        public readonly AnnoucementService annoucementService;

        public AnnoucementController()
        {
            annoucementService = new AnnoucementService();
        }
        // GET: Annoucement
        public ActionResult Index()
        {
            List<AnnoucementModel> annoucements = annoucementService.GetAllAnnoucement();
            return View(annoucements);
        }

        [HttpGet]
        public ActionResult AddAnnoucement()
        {

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

            annoucementService.DeleteAnnoucement(Id);
            return RedirectToAction("Index");
        }
    }
}