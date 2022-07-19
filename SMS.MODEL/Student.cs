using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMS.Model
{
   public  class Student
    {
        public Guid StudentId { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        [Display(Name ="First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "LastName is required.")]
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Standard is required.")]
        public int Standard { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
       
    }
}
