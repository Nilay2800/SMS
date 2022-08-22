using SMS.Data;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    
    public class UserProfileService
    {
        public readonly UserProfileProvider userProfileProvider;
        public UserProfileService()
        {
            userProfileProvider = new UserProfileProvider();
        }
        public int UpdateUserProfile(UserProfileModel userProfileModel)
        {
            return userProfileProvider.UpdateUserProfile(userProfileModel);
        }
        public UserProfileModel GetUserProfileById()
        {
            var userid = SessionHelper.UserId;
            var data = userProfileProvider.GetUserProfileById(userid);
            
            var username = SessionHelper.UserName;
            UserProfileModel userProfileModel = new UserProfileModel()
            {
                id=data.id,
                userId = userid,
                userName = username,
                Email = data.Email,
                mobileNumber = data.mobileNumber,
                gender=data.gender,
                DOB=data.DOB,
                profileImage=data.profileImage

            };
            return userProfileModel;
           
        }

    }
    
}
