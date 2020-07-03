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
    public class SearchStatusMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public SearchStatusMaster Create(SearchStatusMaster searchstatus, Int64 UserID)
        {
            searchstatus.CreatedBy = UserID;
            searchstatus.CreatedDtTm = DateTime.Now;
            dbModel.SearchStatusMasters.Add(searchstatus);
            dbModel.SaveChanges();
            return searchstatus;
        }

        public SearchStatusMaster Edit(SearchStatusMaster searchstatus, Int64 UserID)
        {
            var searchstatusinfo = dbModel.SearchStatusMasters.Where(w => w.SearchStatusID == searchstatus.SearchStatusID).FirstOrDefault();
            searchstatusinfo.SearchStatusName = searchstatus.SearchStatusName;
            searchstatusinfo.Remarks = searchstatus.Remarks;
            searchstatusinfo.IsActive = searchstatus.IsActive;
            searchstatusinfo.ModifiedBy = UserID;
            searchstatusinfo.ModifiedDtTm = DateTime.Now;
            searchstatusinfo.Remarks = searchstatus.Remarks;
            dbModel.Entry(searchstatusinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchstatus;
        }

        public SearchStatusMaster Delete(Int64 searchstatusID, Int64 UserID, bool Status)
        {
            var searchstatusinfo = dbModel.SearchStatusMasters.Where(w => w.SearchStatusID == searchstatusID).FirstOrDefault();
            searchstatusinfo.IsActive = Status;
            searchstatusinfo.ModifiedBy = UserID;
            searchstatusinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(searchstatusinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchstatusinfo;
        }
    }
}
