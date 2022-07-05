using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class TeacherModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "required")]
        [MinLength(10,ErrorMessage ="mobile no should be 11")]
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
