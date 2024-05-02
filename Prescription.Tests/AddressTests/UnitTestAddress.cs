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
            DbAddressRepo repo = new DbAddressRepo(connection);
            DbAddress newAddress = new DbAddress
            {
                City = "Leverkusen",
                ZIP = "53456",
                Street = "Am Papa",
                Haus = "154",
                OwnerId = 2,
                OwnerType = (int)AddressOwner.Doctor,
                Current = true
            };
            long id = repo.Insert(newAddress);
            DbAddress retrivedAddress = repo.GetOne(id);
            Assert.Equal("154", retrivedAddress.Haus);
            repo.Delete(retrivedAddress);
            retrivedAddress = repo.GetOne(id);
            Assert.Null(retrivedAddress);
        }
        [Fact]
        public void TestUpdateAddress() 
        {
            DbAddressRepo repo = new DbAddressRepo(connection);
            DbAddress newAddress = new DbAddress
            {
                City = "Leverkusen",
                ZIP = "53456",
                Street = "Am Papa",
                Haus = "154",
                OwnerId = 2,
                OwnerType = (int)AddressOwner.Doctor,
                Current = true
            };
            long id = repo.Insert(newAddress);
            DbAddress retrivedAddress = repo.GetOne(id);
            Assert.Equal("154", retrivedAddress.Haus);

            retrivedAddress.City = "Köln";
            repo.Update(retrivedAddress);
            
            DbAddress updatedAddress = repo.GetOne(id);
            Assert.Equal("Köln", updatedAddress.City);

            repo.Delete(updatedAddress);
            updatedAddress = repo.GetOne(id);
            Assert.Null(updatedAddress);
        }
        [Fact] public void TestInsertEmptyAddress()
        {
            DbAddress insertedAddress = new DbAddress();
            DbAddressRepo repo = new DbAddressRepo(connection);

            long id = repo.Insert(insertedAddress);

            DbAddress emptyAddress = repo.GetOne(id);
            Assert.NotNull(emptyAddress);
        }
    }
}
