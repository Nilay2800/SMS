using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Model
{
    public class AnnoucementModel
    {
        public AnnoucementModel()
        {
            _RoleList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        [Display(Name = "Annoucement")]
        public string AnnoucementDetail { get; set; }
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        public int RoleId { get; set; }
        public List<SelectListItem> _RoleList { get; set; }
    }
}
