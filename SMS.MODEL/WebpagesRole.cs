using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class WebpagesRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        [Display(Name = "Role Name")]
        [Required]
        public bool IsActive { get; set; }
        [Display(Name = "Role Code")]
        [Required]
        public string RoleCode { get; set; }
        
    }
}
