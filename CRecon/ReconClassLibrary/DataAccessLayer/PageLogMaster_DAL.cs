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
    class PageLogMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public PageLogMaster Create(PageLogMaster pagelogmaster, Int64 UserID)
        {
            pagelogmaster.CreatedBy = UserID;
            pagelogmaster.CreatedDtTm = DateTime.Now;
            dbModel.PageLogMasters.Add(pagelogmaster);
            dbModel.SaveChanges();
            return pagelogmaster;
        }

        public PageLogMaster UpdateStatus(PageLogMaster pagelogmaster, Int64 UserID)
        {
            var pagelogmasterinfo = dbModel.PageLogMasters.Where(w => w.LogID == pagelogmaster.LogID).FirstOrDefault();
            pagelogmasterinfo.PageLeftDtTm = pagelogmaster.PageLeftDtTm;
            pagelogmasterinfo.Remarks = pagelogmaster.Remarks;
            pagelogmasterinfo.IsActive = pagelogmaster.IsActive;
            pagelogmasterinfo.ModifiedBy = UserID;
            pagelogmasterinfo.ModifiedDtTm = DateTime.Now;
            pagelogmasterinfo.Remarks = pagelogmaster.Remarks;
            dbModel.Entry(pagelogmasterinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return pagelogmaster;
        }

        public PageLogMaster Delete(Int64 LogID, Int64 UserID, bool Status)
        {
            var pagelogmasterinfo = dbModel.PageLogMasters.Where(w => w.LogID == LogID).FirstOrDefault();
            pagelogmasterinfo.IsActive = Status;
            pagelogmasterinfo.ModifiedBy = UserID;
            pagelogmasterinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(pagelogmasterinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return pagelogmasterinfo;
        }
    }
}
