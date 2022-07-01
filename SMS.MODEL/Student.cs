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
        [Key]
       

        public Guid StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Standard { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
       
    }
}
