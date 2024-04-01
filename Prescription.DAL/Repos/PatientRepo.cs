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
            Patient? patient = base.GetOne(id);

            if (patient == null) { throw new ArgumentOutOfRangeException("There isn't this patient"); }

            patient.Addresses = GetDepend<PatientsAddress>(
                patient.Id, "PatientId");
            
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
