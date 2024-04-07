using Dapper;
using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prescription.DAL.Repos
{
    public class PatientsAddressRepo: RepoBase<PatientsAddress>
    {
        public PatientsAddressRepo(IDbConnection connection) : base(connection) 
        {
        }
        public bool SetCurrent(long id, long PatientId)
        {
            string sql = "UPDATE dbo.PatientsAddress SET [Current]=0 WHERE PatientId=@PatientId;" +
                "UPDATE dbo.PatientsAddress SET [Current]=1 WHERE Id=@Id;";
            try
            {
                _connection.Execute(sql, new { Id = id, PatientId = PatientId });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
