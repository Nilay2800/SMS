using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Model
{
   public  class FormModel
    {
        public FormModel()
        {

            _parentFormList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string  Name { get; set; }
        public string NavigateURL { get; set; }
        public string FormAcessCode { get; set; }

        public int? DisplayOrder { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

       public DateTime? UpdatedOn { get; set; }
        public int? ParentForm { get; set; }
        public bool  IsActive { get; set; }
        public bool IsDisplayMenu { get; set; }
        public List<SelectListItem> _parentFormList { get; set; }




    }
}
