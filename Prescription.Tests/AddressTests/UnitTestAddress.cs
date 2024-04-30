using Prescription.DAL.Entities;
using Prescription.DAL.Repos;
using Microsoft.Data.SqlClient;

namespace Prescription.Tests.AddressTests

{
    public class UnitTestAddress
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        [Fact]
        public void TestAddAddressInDb()
        {
            DbAddress address = new DbAddress
            {
                Id = 8,
                City = "Köln",
                ZIP = "51107",
                Street = "Mehrheimerweg",
                Haus = "5b",
                OwnerId = 1,
                OwnerType = (int)AddressOwner.Doctor,
                Current = true
            };
            DbAddressRepo repo = new DbAddressRepo(connection);
            long id = repo.Insert(address);
            DbAddress insertedAddres = repo.GetOne(id);
            Assert.NotNull(insertedAddres);
        }
        [Fact]
        public void TestSetCurrentAddress()
        {
            DbAddressRepo repo = new DbAddressRepo(connection);
            repo.SetCurrentAddress(5, 1, AddressOwner.Doctor);
            var address = repo.GetOne(5);
            Assert.Equal(true, address.Current);
            address = repo.GetOne(4);
            Assert.Equal(false, address.Current);
        }
        [Fact]
        public void TestInsertAndDeleteAddress()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void TestUpdateAddress() { throw new NotImplementedException();}
        [Fact] public void TestInsertEmptyAddress()
        {
            throw new NotImplementedException();
        }
    }
}
