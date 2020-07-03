using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReconClassLibrary.Model;
using ReconClassLibrary.Database;
using System.Data.Entity;

namespace ReconClassLibrary.DataAccessLayer
{
   public class ClientMaster_DAL
    {
        DbModel dbModel = new DbModel();
        public ClientMaster Create(ClientMaster client, Int64 UserID)
        {
            client.CreatedBy = UserID;
            client.CreatedDtTm = DateTime.Now;
            dbModel.ClientMasters.Add(client);
            dbModel.SaveChanges();
            return client;
        }

        public ClientMaster Edit(ClientMaster client, Int64 UserID)
        {
            var ClientInfo = dbModel.ClientMasters.Where(w => w.ClientID == client.ClientID).FirstOrDefault();
            ClientInfo.Address = client.Address;
            ClientInfo.ClientName = client.ClientName;
            ClientInfo.Country = client.Country;
            ClientInfo.EmailID = client.EmailID;
            ClientInfo.IsActive = client.IsActive;
            ClientInfo.MobileNo = client.MobileNo;
            ClientInfo.ModifiedBy = UserID;
            ClientInfo.ModifiedDtTm = DateTime.Now;
            ClientInfo.Remarks = client.Remarks;
            ClientInfo.State = client.State;
            dbModel.Entry(ClientInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return client;
        }

        public ClientMaster Delete(Int64 ClientID, Int64 UserID, bool Status)
        {
            var ClientInfo = dbModel.ClientMasters.Where(w => w.ClientID == ClientID).FirstOrDefault();
            ClientInfo.IsActive = Status;
            ClientInfo.ModifiedBy = UserID;
            ClientInfo.ModifiedDtTm = DateTime.Now;
            dbModel.Entry(ClientInfo).State = EntityState.Modified;
            dbModel.SaveChanges();
            return ClientInfo;
        }
    }
}
