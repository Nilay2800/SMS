using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class AnnoucementModel
    {
        public int Id { get; set; }
        public string AnnoucementDetail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
