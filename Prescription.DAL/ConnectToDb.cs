using Microsoft.Data.SqlClient;
using Dapper;
using Prescription.Models;

namespace Prescription.DAL
{
    public class ConnectToDb
    {
        private string _connectionString =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";

        public string Test(string sql)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Insurance> ins = conn.Query<Insurance>(sql).ToList();
            return ins.FirstOrDefault().Name;
        }
    }
}
