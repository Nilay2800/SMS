using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Model
{
    public class Annoucement
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string AnnoucementDetail { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool Status { get; set; } = true;
        public int RoleId { get; set; }
    }
}
