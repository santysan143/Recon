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
    public class SearchDetailTransactions_DAL
    {
        DbModel dbModel = new DbModel();
        public SearchDetailTransactions Create(SearchDetailTransactions searchdetailtransaction, Int64 UserID)
        {
            searchdetailtransaction.CreatedBy = UserID;
            searchdetailtransaction.CreatedDtTm = DateTime.Now;
            dbModel.SearchDetailTransactions.Add(searchdetailtransaction);
            dbModel.SaveChanges();
            return searchdetailtransaction;
        }

        public SearchDetailTransactions UpdateStatus(SearchDetailTransactions searchdetailtransaction, Int64 UserID)
        {
            var searchdetailtransactioninfo = dbModel.SearchDetailTransactions.Where(w => w.TransactionID == searchdetailtransaction.TransactionID).FirstOrDefault();
            searchdetailtransactioninfo.SearchStatusID = searchdetailtransaction.SearchStatusID;
            searchdetailtransactioninfo.Remarks = searchdetailtransaction.Remarks;
            searchdetailtransactioninfo.IsActive = searchdetailtransaction.IsActive;
            searchdetailtransactioninfo.ModifiedBy = UserID;
            searchdetailtransactioninfo.ModifiedDtTm = DateTime.Now;
            searchdetailtransactioninfo.Remarks = searchdetailtransaction.Remarks;
            dbModel.Entry(searchdetailtransactioninfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchdetailtransaction;
        }

        public SearchDetailTransactions Delete(Int64 TransactionID, Int64 UserID, bool Status)
        {
            var searchdetailtransactioninfo = dbModel.SearchDetailTransactions.Where(w => w.TransactionID == TransactionID).FirstOrDefault();
            searchdetailtransactioninfo.IsActive = Status;
            searchdetailtransactioninfo.ModifiedBy = UserID;
            searchdetailtransactioninfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(searchdetailtransactioninfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return searchdetailtransactioninfo;
        }
    }
}
