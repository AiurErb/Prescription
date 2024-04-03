using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestPrescript
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
        SqlConnection connection;

        [Fact]
        public void GetOnePrescript()
        {
            connection = new SqlConnection(connectionString);
            PrescriptRepo prescript = new(connection);
            Prescript onePrescript = prescript.GetOne(1);
            Assert.NotNull(onePrescript);
            Assert.NotNull(onePrescript.Doctor);
            Assert.NotNull(onePrescript.Patient);
        }
        [Fact]
        public void GetOnePrescriptWithServices()
        {
            connection = new SqlConnection(connectionString);
            PrescriptRepo prescript = new(connection);
            Prescript onePrescript = prescript.GetOne(1);
            Assert.Equal(2, onePrescript.Services.Count());
        }
    }
}
