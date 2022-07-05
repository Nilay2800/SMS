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

        public static int ContactNumber { get; set; }
        








        //    public static string Email
        //    {

        //        get { return GetSessionValue<string>}
        //    }
        //    public class BaseSessionHelper
        //    {
        //        public static T GetSessionValue<T>(string student, bool throwExceptionIfMissing = false)
        //        {
        //            if (HttpContext.Current == null)
        //                throw new ApplicationException("Invalid HTTP Context.");

        //            if (HttpContext.Current.Session == null)
        //                throw new ApplicationException("Session Expired.");

        //            if (HttpContext.Current.Session[student] == null)
        //            {
        //                if (throwExceptionIfMissing)
        //                {
        //                    throw new ApplicationException(String.Format("{0} is missing", student));
        //                }
        //                else
        //                {
        //                    return default(T);
        //                }
        //            }

        //            return (T)HttpContext.Current.Session[student];
        //        }

        //        public static bool HasSessionValue(string student)
        //        {
        //            if (HttpContext.Current == null)
        //                throw new ApplicationException("Invalid HTTP Context.");

        //            if (HttpContext.Current.Session == null)
        //                throw new ApplicationException("Session Expired.");

        //            return (HttpContext.Current.Session[student] != null);
        //        }

        //        public static void SetSessionValue<T>(string student, T Id)
        //        {
        //            if (!object.Equals(Id , default(T)))
        //                HttpContext.Current.Session[student] = Id;
        //            else
        //                NullSessionVar(student);
        //        }

        //        public static void NullSessionVar(string student)
        //        {
        //            HttpContext.Current.Session[student] = null;
        //        }
        //    }
    }
}
