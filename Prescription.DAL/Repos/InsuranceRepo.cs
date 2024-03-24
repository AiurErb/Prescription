using Prescription.DAL.Repos.Base;
using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Prescription.DAL.Repos
{
    public class InsuranceRepo: BaseRepo<Insurance>
    {
        public InsuranceRepo(SqlConnection conn) : base(conn) { }
    }
}
