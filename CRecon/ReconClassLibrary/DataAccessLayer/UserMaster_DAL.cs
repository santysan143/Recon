using ReconClassLibrary.Database;
using ReconClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconClassLibrary.DataAccessLayer
{
    public class UserMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public UserMaster Create(UserMaster user, Int64 UserID)
        {
            user.CreatedBy = UserID;
            user.CreatedDtTm = DateTime.Now;
            dbModel.UserMasters.Add(user);
            dbModel.SaveChanges();
            return user;
        }

        public UserMaster Edit(UserMaster user, Int64 UserID)
        {
            var userInfo = dbModel.UserMasters.Where(w => w.UserID == user.UserID).FirstOrDefault();
            userInfo.UserName = user.UserName;
            userInfo.EmailID = user.EmailID;
            userInfo.FullName = user.FullName;
            userInfo.ManagerID = user.ManagerID;
            userInfo.MobileNo = user.MobileNo;
            userInfo.Password = user.Password;
            userInfo.Remarks = user.Remarks;
            userInfo.RoleID = user.RoleID;
            userInfo.ClientID = user.ClientID;
            userInfo.IsActive = user.IsActive;
            userInfo.ModifiedBy = UserID;
            userInfo.ModifiedDtTm = DateTime.Now;
            userInfo.Remarks = user.Remarks;
            dbModel.Entry(userInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return user;
        }

        public UserMaster Delete(Int64 userID, Int64 UserID, bool Status)
        {
            var userInfo = dbModel.UserMasters.Where(w => w.UserID == userID).FirstOrDefault();
            userInfo.IsActive = Status;
            userInfo.ModifiedBy = UserID;
            userInfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(userInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return userInfo;
        }
    }
}
