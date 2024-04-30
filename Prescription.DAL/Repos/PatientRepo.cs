using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class PatientRepo: RepoBase<Patient>
    {        
        public PatientRepo(IDbConnection connection) : base(connection) 
        { 
        }
        
        
        
       
    }
}
