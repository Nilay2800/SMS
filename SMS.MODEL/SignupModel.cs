﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Model
{
    public class SignupModel
    {
        public SignupModel()
        {
            _RoleList = new List<SelectListItem>();
            _DefaultFormList = new List<SelectListItem>();
        }
        [Key]
        public int Userid { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName{ get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public List<SelectListItem> _RoleList { get; set; }
        public List<SelectListItem> _DefaultFormList { get; set; }
    }
}
