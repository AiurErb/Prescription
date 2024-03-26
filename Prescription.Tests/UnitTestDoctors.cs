using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestDoctors
    {
        [Fact]
        public void GetOne()
        {
            DoctorRepo repo = new DoctorRepo();
            Assert.Equal("Dr. Horst", repo.GetOne(1)?.Name);
        }
        [Fact]
        public void GetAll()
        {
            var repo = new DoctorRepo();
            Assert.Equal(2, repo.GetAll().Count());
        }
        [Fact]
        public void AddAddress()
        {
            var repo = new DoctorRepo();
            var doctor = repo.GetOne(1);
            Assert.Single<DoctorsAddress>(repo.GetAddresses(doctor));
            var newAddress = new DoctorsAddress 
            {
                Street ="KalkHauptstaße",
                Haus="23",
                ZIP="51102",
                City="Köln",
                DoctorId=doctor.Id,
                Current=false
            };
            var addressRepo = new DoctorsAddressRepo();
            addressRepo.Insert(newAddress);
            Assert.Equal(2,repo.GetAddresses(doctor).Count());
            Assert.Equal("23a", repo.GetCurrentAddress(doctor)?.Haus.Trim());
            addressRepo.Delete(newAddress);

        }
    }
}
