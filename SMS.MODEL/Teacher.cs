using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class Teacher
    {
        public int Id { get; set; }
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
