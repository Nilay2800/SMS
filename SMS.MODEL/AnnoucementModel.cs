using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class AnnoucementModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [Display(Name = "Annoucement")]
        public string AnnoucementDetail { get; set; }
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
    }
}
