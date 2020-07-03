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
    public class RolePageMapping_DAL
    {
        DbModel dbModel = new DbModel();
        public RolePageMapping Create(RolePageMapping rolepage, Int64 UserID)
        {
            rolepage.CreatedBy = UserID;
            rolepage.CreatedDtTm = DateTime.Now;
            dbModel.RolePageMappings.Add(rolepage);
            dbModel.SaveChanges();
            return rolepage;
        }

        public RolePageMapping Edit(RolePageMapping rolepage, Int64 UserID)
        {
            var pageInfo = dbModel.RolePageMappings.Where(w => w.RolePageID == rolepage.RolePageID).FirstOrDefault();
            pageInfo.PageID = rolepage.PageID;
            pageInfo.RoleID = rolepage.RoleID;
            pageInfo.Remarks = rolepage.Remarks;
            pageInfo.IsActive = rolepage.IsActive;
            pageInfo.ModifiedBy = UserID;
            pageInfo.ModifiedDtTm = DateTime.Now;
            pageInfo.Remarks = rolepage.Remarks;
            dbModel.Entry(pageInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return rolepage;
        }

        public RolePageMapping Delete(Int64 pageID, Int64 UserID, bool Status)
        {
            var pageInfo = dbModel.RolePageMappings.Where(w => w.PageID == pageID).FirstOrDefault();
            pageInfo.IsActive = Status;
            pageInfo.ModifiedBy = UserID;
            pageInfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(pageInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return pageInfo;
        }
    }
}
