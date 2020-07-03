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
    public class SearchTypeMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public SearchTypeMaster Create(SearchTypeMaster searchtype, Int64 UserID)
        {
            searchtype.CreatedBy = UserID;
            searchtype.CreatedDtTm = DateTime.Now;
            dbModel.SearchTypeMasters.Add(searchtype);
            dbModel.SaveChanges();
            return searchtype;
        }

        public SearchTypeMaster Edit(SearchTypeMaster searchtype, Int64 UserID)
        {
            var searchtypeinfo = dbModel.SearchTypeMasters.Where(w => w.SearchTypeID == searchtype.SearchTypeID).FirstOrDefault();
            searchtypeinfo.SearchName = searchtype.SearchName;
            searchtypeinfo.Remarks = searchtype.Remarks;
            searchtypeinfo.IsActive = searchtype.IsActive;
            searchtypeinfo.ModifiedBy = UserID;
            searchtypeinfo.ModifiedDtTm = DateTime.Now;
            searchtypeinfo.Remarks = searchtype.Remarks;
            dbModel.Entry(searchtypeinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchtype;
        }

        public SearchTypeMaster Delete(Int64 SearchTypeID, Int64 UserID, bool Status)
        {
            var searchtypeinfo = dbModel.SearchTypeMasters.Where(w => w.SearchTypeID == SearchTypeID).FirstOrDefault();
            searchtypeinfo.IsActive = Status;
            searchtypeinfo.ModifiedBy = UserID;
            searchtypeinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(searchtypeinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchtypeinfo;
        }
    }
}
