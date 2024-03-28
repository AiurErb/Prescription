using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class PatientRepo: RepoBase<Patient>
    {        
        public PatientRepo() 
        { 
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }
        public override Patient GetOne(long id)
        {
            Patient patient = base.GetOne(id);
            string sql = "SELECT * FROM dbo.PatientsAddress WHERE id=@id";
            patient.Addresses = 
                _connection.Query<PatientsAddress>(sql, new {id=id}).AsList();
            return patient;
        }
        public override long Insert(Patient patient)
        {
            long id = base.Insert(patient);
            foreach(PatientsAddress address in patient.Addresses)
            {
                address.PatientId = id;
                _connection.Insert<PatientsAddress>(address);
            }
            return id;
        }
    }
}
