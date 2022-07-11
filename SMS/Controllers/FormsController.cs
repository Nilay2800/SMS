using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class FormsController : Controller
    {
        private readonly FormsService _formsService;

        public FormsController()
        {
            _formsService = new FormsService(); 
        }
        public ActionResult Index()
        {
            List<FormModel> formlist = _formsService.GetAllForms();
            return View(formlist);
        }
        public ActionResult Create(int? Id)
        {
            FormModel form = new FormModel();
            if (Id.HasValue)
            {
                var formdetail = _formsService.GetFormsById(Id.Value);
                if (formdetail != null)
                {
                    form.Id = Id.Value;
                    form.Id = formdetail.Id;
                    form.Name = formdetail.Name;
                    form.FormAcessCode = formdetail.FormAcessCode;
                    form.ParentForm = formdetail.ParentForm;
                    form.NavigateURL = formdetail.NavigateURL;
                    form.DisplayOrder = formdetail.DisplayOrder;
                    form.IsDisplayMenu = formdetail.IsDisplayMenu;
                    form.IsActive = formdetail.IsActive;

                }
            }
            BindDropdown(ref form); 
            return View(form);
        }
        [HttpPost]
        public ActionResult Create(FormModel form)
        {
            
            _formsService.SaveUpdateForm(form);
            TempData["Message"] = "Data Saved Successfully!!";
            return RedirectToAction("Index");

        }
        private void BindDropdown(ref FormModel model)
        {
            BindParentForm(ref model);
        }
        public FormModel BindParentForm(ref FormModel model)
        {
            int formid = model.Id;
            var getparentform = _formsService.GetAllForms().Where(f => f.Id != formid).Select(a => new FormMst { Id = a.Id, Name = a.Name }).OrderBy(a => a.Name);
            model._parentFormList.Add(new SelectListItem() { Text = "select text", Value = "" });
            foreach (var item in getparentform)
            {
                model._parentFormList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }
            return model;
        }

    }
}