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
    public class SearchDetailMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public SearchDetailMaster Create(SearchDetailMaster searchdetail, Int64 UserID)
        {
            searchdetail.CreatedBy = UserID;
            searchdetail.CreatedDtTm = DateTime.Now;
            dbModel.SearchDetailMasters.Add(searchdetail);
            dbModel.SaveChanges();
            return searchdetail;
        }

        public SearchDetailMaster Edit(SearchDetailMaster searchdetail, Int64 UserID)
        {
            var searchdetailinfo = dbModel.SearchDetailMasters.Where(w => w.SearchDetailID == searchdetail.SearchDetailID).FirstOrDefault();
            searchdetailinfo.DesktopName = searchdetail.DesktopName;
            searchdetailinfo.IPAddress = searchdetail.IPAddress;
            searchdetailinfo.MacAddress = searchdetail.MacAddress;
            searchdetailinfo.Remarks = searchdetail.Remarks;
            searchdetailinfo.IsActive = searchdetail.IsActive;
            searchdetailinfo.ModifiedBy = UserID;
            searchdetailinfo.ModifiedDtTm = DateTime.Now;
            searchdetailinfo.Remarks = searchdetail.Remarks;
            dbModel.Entry(searchdetailinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchdetail;
        }

        public SearchDetailMaster Delete(Int64 searchdetailID, Int64 UserID, bool Status)
        {
            var searchdetailinfo = dbModel.SearchDetailMasters.Where(w => w.SearchDetailID == searchdetailID).FirstOrDefault();
            searchdetailinfo.IsActive = Status;
            searchdetailinfo.ModifiedBy = UserID;
            searchdetailinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(searchdetailinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchdetailinfo;
        }
    }
}
