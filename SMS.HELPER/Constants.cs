using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Helper
{
   public static class Constants
    {
        public static class EmailCodes
        {
             
            public const string PASSWORDRESETLINKEXPIRED = "Password Link Has Expired";
            public const string PASSWORDCHANGESUCCESS = "Password changes Successful";
            public const string PASSWORDERRORMESSAGE = "Something Went Wrong";
           public const string PASSWORDRESETEMAILSENT = "PasswordReset Link Sent Succesfull";
        }
        public enum Codes
        {
           FORGOTPASSWORD,

        }
    }
}
