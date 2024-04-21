using Prescription.DAL.Entities;
using Prescription.DAL.Repos;
using Microsoft.Data.SqlClient;


namespace Prescription.Test
{
    public class UnitTest1
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
        static SqlConnection connection = new SqlConnection(connectionString);

        [Fact]
        public void TestInsuranceGetOne()
        {            
            
            InsuranceRepo repo = new InsuranceRepo(connection);
            Assert.Equal("AOK", repo.GetOne(2).Name);
        }
        [Fact]
        public async Task TestInsuranceGetAll()
        {
            InsuranceRepo repo = new InsuranceRepo(connection);
            var count = await repo.GetAll();
            Assert.Equal(2, count.Count());
        }
        [Fact]
        public async void TestInsuranceInsertDelete()
        {
            InsuranceRepo repo = new InsuranceRepo(connection);
            Insurance newInsurance = new Insurance 
            {
                Name = "Techniker"
            };
            long id = repo.Insert(newInsurance);
            var list = await repo.GetAll();
            Assert.Equal(3, list.Count());
            Assert.Equal("Techniker", repo.GetOne(id)?.Name);

            repo.Delete(newInsurance);
            list = await repo.GetAll();
            Assert.Equal(2, list.Count());
        }
        [Fact]
        public void TestInsuranceUpdate()
        {
            InsuranceRepo repo = new InsuranceRepo(connection);
            Insurance editedInsurance = new Insurance
            {
                Id = 1,
                Name = "DAK+Edit"
            };
            repo.Update(editedInsurance);
            Assert.Equal("DAK+Edit", repo.GetOne(1)?.Name);
            editedInsurance = new Insurance
            {
                Id = 1,
                Name = "DAK"
            };
            repo.Update(editedInsurance);
            Assert.Equal("DAK", repo.GetOne(1)?.Name);
        }
    }
}