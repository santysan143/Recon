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
    public class LicenseKeys_DAL
    {
        DbModel dbModel = new DbModel();
        public LicenseKeys Create(LicenseKeys keys, Int64 UserID)
        {
            keys.CreatedBy = UserID;
            keys.CreatedDtTm = DateTime.Now;
            dbModel.LicenseKeys.Add(keys);
            dbModel.SaveChanges();
            return keys;
        }

        public LicenseKeys UpdateLicense(LicenseKeys keys, Int64 UserID)
        {
            var keyinfo = dbModel.LicenseKeys.Where(w => w.LicenseKeyID == keys.LicenseKeyID).FirstOrDefault();
            keyinfo.DesktopName = keys.DesktopName;
            keyinfo.MacAddress = keys.MacAddress;
            keyinfo.IpAddress = keys.IpAddress;
            keyinfo.Remarks = keys.Remarks;
            keyinfo.IsActive = keys.IsActive;
            keyinfo.ModifiedBy = UserID;
            keyinfo.ModifiedDtTm = DateTime.Now;
            keyinfo.Remarks = keys.Remarks;
            dbModel.Entry(keyinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return keys;
        }

        public LicenseKeys Delete(Int64 LicenseKeyID, Int64 UserID, bool Status)
        {
            var keyinfo = dbModel.LicenseKeys.Where(w => w.LicenseKeyID == LicenseKeyID).FirstOrDefault();
            keyinfo.IsActive = Status;
            keyinfo.ModifiedBy = UserID;
            keyinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(keyinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return keyinfo;
        }
    }
}
