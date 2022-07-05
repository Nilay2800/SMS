using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace SMS.Model
{
    public class SessionHelper
    {
        public class Constants
        {
            public const string StudentId = "currentstudentId";
            public const string Firstname = "currentfirstname";
            public const string Lastname = "currentlastname";
            public const string Email = "Email";
            public const string Age = "age";
            public const string Gender = "Gender";
            public const string ContactNumber = "ContactNumber";
        }
        public static string Email { get; set; }
        public static string Firstname { get; set; }

        public static string Lastname { get; set; }

        public static int Age { get; set; }
        public static int StudentId { get; set; }

        public static string Gender { get; set; }

        public static string ContactNumber { get; set; }
     
    }
}
