namespace SMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public  class User
    {
        [Key]
        public int Userid { get; set; }

        [Required]
        [StringLength(56)]

        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
      
        [NotMapped]
        [Display(Name = "Role Name")]
        public int RoleId { get; set; }
    }
}
