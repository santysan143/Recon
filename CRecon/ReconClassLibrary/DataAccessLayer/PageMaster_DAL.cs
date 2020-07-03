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
    public class PageMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public PageMaster Create(PageMaster page, Int64 UserID)
        {
            page.CreatedBy = UserID;
            page.CreatedDtTm = DateTime.Now;
            dbModel.PageMasters.Add(page);
            dbModel.SaveChanges();
            return page;
        }

        public PageMaster Edit(PageMaster page, Int64 UserID)
        {
            var pageInfo = dbModel.PageMasters.Where(w => w.PageID == page.PageID).FirstOrDefault();
            pageInfo.ActionName = page.ActionName;
            pageInfo.ControllerName = page.ControllerName;
            pageInfo.PageName = page.PageName;
            pageInfo.PageType = page.PageType;
            pageInfo.Remarks = page.Remarks;
            pageInfo.IsActive = page.IsActive;
            pageInfo.ModifiedBy = UserID;
            pageInfo.ModifiedDtTm = DateTime.Now;
            pageInfo.Remarks = page.Remarks;
            dbModel.Entry(pageInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return page;
        }

        public PageMaster Delete(Int64 pageID, Int64 UserID, bool Status)
        {
            var pageInfo = dbModel.PageMasters.Where(w => w.PageID == pageID).FirstOrDefault();
            pageInfo.IsActive = Status;
            pageInfo.ModifiedBy = UserID;
            pageInfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(pageInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return pageInfo;
        }
    }
}
