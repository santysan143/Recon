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
    public class RoleMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public RoleMaster Create(RoleMaster role, Int64 UserID)
        {
            role.CreatedBy = UserID;
            role.CreatedDtTm = DateTime.Now;
            dbModel.RoleMasters.Add(role);
            dbModel.SaveChanges();
            return role;
        }

        public RoleMaster Edit(RoleMaster role, Int64 UserID)
        {
            var RoleInfo = dbModel.RoleMasters.Where(w => w.RoleID == role.RoleID).FirstOrDefault();
            RoleInfo.RoleName = role.RoleName;
            RoleInfo.ClientID = role.RoleID;
            RoleInfo.IsActive = role.IsActive;
            RoleInfo.ModifiedBy = UserID;
            RoleInfo.ModifiedDtTm = DateTime.Now;
            RoleInfo.Remarks = role.Remarks;
            dbModel.Entry(RoleInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return role;
        }

        public RoleMaster Delete(Int64 roleID, Int64 UserID, bool Status)
        {
            var RoleInfo = dbModel.RoleMasters.Where(w => w.RoleID == roleID).FirstOrDefault();
            RoleInfo.IsActive = Status;
            RoleInfo.ModifiedBy = UserID;
            RoleInfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(RoleInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return RoleInfo;
        }
    }
}
