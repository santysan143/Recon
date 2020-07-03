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
    public class SearchTransactionStatusLogs_DAL
    {
        DbModel dbModel = new DbModel();
        public SearchTransactionStatusLogs Create(SearchTransactionStatusLogs searchtransactionstatuslog, Int64 UserID)
        {
            searchtransactionstatuslog.CreatedBy = UserID;
            searchtransactionstatuslog.CreatedDtTm = DateTime.Now;
            dbModel.SearchTransactionStatusLogs.Add(searchtransactionstatuslog);
            dbModel.SaveChanges();
            return searchtransactionstatuslog;
        }

        //public SearchTransactionStatusLogs UpdateStatus(SearchTransactionStatusLogs searchtransactionstatuslog, Int64 UserID)
        //{
        //    var searchtransactionstatusloginfo = dbModel.SearchTransactionStatusLogs.Where(w => w.TransactionStatusID == searchtransactionstatuslog.TransactionStatusID).FirstOrDefault();
        //    searchtransactionstatusloginfo.SearchStatusID = searchtransactionstatuslog.SearchStatusID;
        //    searchtransactionstatusloginfo.Remarks = searchtransactionstatuslog.Remarks;
        //    searchtransactionstatusloginfo.IsActive = searchtransactionstatuslog.IsActive;
        //    searchtransactionstatusloginfo.ModifiedBy = UserID;
        //    searchtransactionstatusloginfo.ModifiedDtTm = DateTime.Now;
        //    searchtransactionstatusloginfo.Remarks = searchtransactionstatuslog.Remarks;
        //    dbModel.Entry(searchtransactionstatusloginfo).State = EntityState.Modified;
        //    dbModel.SaveChanges();
        //    return searchtransactionstatuslog;
        //}

        //public SearchTransactionStatusLogs Delete(Int64 TransactionID, Int64 UserID, bool Status)
        //{
        //    var searchtransactionstatusloginfo = dbModel.SearchTransactionStatusLogs.Where(w => w.TransactionID == TransactionID).FirstOrDefault();
        //    searchtransactionstatusloginfo.IsActive = Status;
        //    searchtransactionstatusloginfo.ModifiedBy = UserID;
        //    searchtransactionstatusloginfo.ModifiedDtTm = DateTime.Now;
        //    dbModel.Entry(searchtransactionstatusloginfo).State = EntityState.Modified;
        //    dbModel.SaveChanges();
        //    return searchtransactionstatusloginfo;
        //}
    }
}
