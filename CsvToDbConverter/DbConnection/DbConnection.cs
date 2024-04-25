using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDbConverter.DbConnection
{
    public static class DbConnection
    {
        private static string _connection =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";

        public static IDbConnection GetConnection() => new SqlConnection(_connection);
    }
}
