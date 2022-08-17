﻿using System;
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
             
            public const string PASSWORDRESETLINKEXPIRED = "Password link has expired";
            public const string PASSWORDCHANGESUCCESS = "Password changes successful";
            public const string PASSWORDERRORMESSAGE = "Something went wrong";

            public const string PASSWORDRESETEMAILSENT = "PasswordReset link sent succesfull";
            public const string STUDENTADDED = "Student added successfully!!";
            public const string TeacherAdded = "Teacher added successfully!!";
            public const string StudentEdit = "Detail updated successfully!!";
            public const string TeacherEdit = "Detail updated successfully!!";
            public const string AnnouncementAdded = "Announcement added successfully!!!";
            public const string AnnouncementEdit = "Detail updated successfully!!";
            public const string Useralreadyexist = "UserName is already exists";




        }
        public enum Codes
        {
            FORGOTPASSWORD

        }
    }
        
    }

