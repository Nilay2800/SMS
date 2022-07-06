using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public  class FormProvider : BaseProvider
    {
        public FormProvider()
        {

        }
        public int CreateForms(FormModel form)
        {
            try
            {
                _db.formModel.Add(form);
                _db.SaveChanges();
                return form.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateForms(FormModel form)
        {
            try
            {
                _db.Entry(form).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return form.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }
        public FormModel GetFormsById(int Id)
        {
            return _db.formModel.Find(Id);
        }

        public FormMst GetFormsByCode(string formcode)
        {
            var Formcode = _db.formModel.Where(a => a.FormAcessCode == formcode).FirstOrDefault();
            FormMst formMst = new FormMst()
            {
                Id = Formcode.Id,
                Name = Formcode.Name,
                NavigateURL = Formcode.NavigateURL,
                FormAcessCode = Formcode.FormAcessCode,
                ParentForm = Formcode.ParentForm,
                IsActive = Formcode.IsActive,
                IsDisplayMenu = Formcode.IsDisplayMenu,
                DisplayOrder = Formcode.DisplayOrder,
            };
            return formMst;
        }
        public FormMst SaveUpdateForm(FormMst form)
        {
            FormModel obj = new FormModel();
            if (form.Id > 0)
            {
                obj = GetFormsById(form.Id);
            }
            {
                obj.Name = form.Name;
                obj.NavigateURL = form.NavigateURL;
                obj.DisplayOrder = form.DisplayOrder;
                obj.IsActive = form.IsActive;
                obj.IsDisplayMenu = form.IsDisplayMenu;
                obj.CreatedOn = form.CreatedOn;
                obj.ParentForm = form.ParentForm;
                obj.Id = form.Id;
                if (obj.Id == 0)
                {
                    obj.FormAcessCode = form.FormAcessCode;
                    obj.CreatedOn = form.CreatedOn;
                    obj.CreatedBy = form.CreatedBy;
                    form.Id = CreateForms(obj);
                }
                else
                {
                    obj.UpdatedBy = form.UpdatedBy;
                    obj.UpdatedOn = form.UpdatedOn;
                    UpdateForms(obj);
                }
                return form;
            }
           
        }
        public List<FormMst> GetAllForms()
        {
            var getallforms = (from p in _db.formModel
                               select new
                               {
                                   Id = p.Id,
                                   NavigateURL = p.NavigateURL,
                                   FormAcessCode = p.FormAcessCode,
                                   DisplayOrder = p.DisplayOrder,
                                   ParentForm = p.ParentForm,
                                   IsActive = p.IsActive,
                                   IsDisplayMenu = p.IsDisplayMenu,
                                   Name = ((p.ParentForm == null ? 0 : p.ParentForm) == 0 ? p.Name : ((from fc in _db.formModel where fc.Id == (p.ParentForm == null ? 0 : p.ParentForm) select fc).FirstOrDefault().Name) + " " + ">>" + " " + p.Name)

                               }).AsEnumerable().Select(x => new FormMst()
                               {
                                   Id = x.Id,
                                   NavigateURL = x.NavigateURL,
                                   FormAcessCode = x.FormAcessCode,
                                   DisplayOrder = x.DisplayOrder,
                                   ParentForm = x.ParentForm,
                                   IsActive = x.IsActive,
                                   IsDisplayMenu = x.IsDisplayMenu,
                                   Name = x.Name
                               }).OrderByDescending(a => a.Id).ToList();
            return getallforms;

                      }
    }
}
