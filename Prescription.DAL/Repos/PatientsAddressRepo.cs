using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prescription.DAL.Repos
{
    public class PatientsAddressRepo: RepoBase<PatientsAddress>
    {
        public PatientsAddressRepo() 
        {
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }        
    }
}
