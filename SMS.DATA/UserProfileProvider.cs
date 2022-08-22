using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class UserProfileProvider:BaseProvider
    {
        public UserProfileProvider()
        {

        }
        public UserProfile GetUserProfileById(int id)
        {
            return _db.profile.Find(id);
        }
        public int UpdateUserProfile(UserProfileModel userProfileModel)
        {
            var userid = SessionHelper.UserId;
            
            UserProfile obj = new UserProfile()
            {
                userId = userid,
                userName = userProfileModel.userName,
                Email = userProfileModel.Email,
                mobileNumber = userProfileModel.mobileNumber,
                gender = userProfileModel.gender,
                DOB = userProfileModel.DOB,
                profileImage = userProfileModel.profileImage
            };
            _db.profile.Add(obj);
            _db.SaveChanges();
            return userProfileModel.id;
        }
    }
}
