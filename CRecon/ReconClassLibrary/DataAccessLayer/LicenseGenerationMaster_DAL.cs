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
    public class LicenseGenerationMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public LicenseGenerationMaster Create(LicenseGenerationMaster license, Int64 UserID)
        {
            license.CreatedBy = UserID;
            license.CreatedDtTm = DateTime.Now;
            dbModel.LicenseGenerationMasters.Add(license);
            dbModel.SaveChanges();
            return license;
        }

        public LicenseGenerationMaster Edit(LicenseGenerationMaster license, Int64 UserID)
        {
            var licenseinfo = dbModel.LicenseGenerationMasters.Where(w => w.LicenseGenerationID == license.LicenseGenerationID).FirstOrDefault();
            licenseinfo.ClientID = license.ClientID;
            licenseinfo.LicenseDuration = license.LicenseDuration;
            licenseinfo.LicenseFromDtTm = license.LicenseFromDtTm;
            licenseinfo.LicenseToDtTm = license.LicenseToDtTm;
            licenseinfo.Remarks = license.Remarks;
            licenseinfo.IsActive = license.IsActive;
            licenseinfo.ModifiedBy = UserID;
            licenseinfo.ModifiedDtTm = DateTime.Now;
            licenseinfo.Remarks = license.Remarks;
            dbModel.Entry(licenseinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return license;
        }

        public LicenseGenerationMaster Delete(Int64 LicenseGenerationID, Int64 UserID, bool Status)
        {
            var licenseinfo = dbModel.LicenseGenerationMasters.Where(w => w.LicenseGenerationID == LicenseGenerationID).FirstOrDefault();
            licenseinfo.IsActive = Status;
            licenseinfo.ModifiedBy = UserID;
            licenseinfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(licenseinfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return licenseinfo;
        }
    }
}
