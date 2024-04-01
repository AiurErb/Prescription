using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestPatient
    {
        [Fact]
        public void GetOnePatient()
        {
            PatientRepo repo= new PatientRepo();
            Assert.Equal("Robert Höpgen", repo.GetOne(1)?.Name);
        }
        [Fact]
        public void GetAllPatients()
        {
            PatientRepo repo= new PatientRepo();
            Assert.Equal(2, repo.GetAll().Count());

        }
        [Fact]
        public void AddPatient()
        {
            PatientRepo repo = new PatientRepo();
            Patient newPatient = new Patient
            {
                Name = "Tunkay Dogu",
                InsuranceNumber = "17832164H",
                Birthday = new DateTime(1960, 10, 15),

            };
            long id = repo.Insert(newPatient);
            Assert.Equal(id, repo.GetAll().Count());
        }
        [Fact]
        public void UpdatePatient()
        {
            PatientRepo repo = new PatientRepo();
            Patient? updatedPatient = repo.GetOne(3);
            DateTime newBirthday = new DateTime(1958, 10, 15);
            updatedPatient.Birthday = newBirthday;
            repo.Update(updatedPatient);
            Assert.Equal(newBirthday, repo.GetOne(3).Birthday);

        }
        [Fact]
        public void DeletePatient()
        {
            PatientRepo repo = new PatientRepo();
            Patient? deletePatient = repo.GetOne(3);
            repo.Delete(deletePatient);
            Assert.Equal(2, repo.GetAll().Count());
        }
        [Fact]
        public void AddPatientWithAddress()
        {
            Patient newPatient = new Patient
            {
                Name = "Fatima Barzizuzoy",
                InsuranceNumber = "45R87691",
                Birthday = new DateTime(1948, 8, 15)
            };
            List<PatientsAddress> addresses = new List<PatientsAddress>
            {
                new PatientsAddress {Street="Ostheimer str.", Haus="12"},
                new PatientsAddress {Street="Hartenberg str.", Haus="54f",Current=true}
            };
            newPatient.Addresses=addresses;
            PatientRepo repo = new PatientRepo();
            long insert = repo.Insert(newPatient);
            Assert.Equal(2, repo.GetOne(insert).Addresses.Count);

        }
        [Fact]
        public void GetPatientWithAddress()
        {
            PatientRepo repo = new PatientRepo();
            Patient? patient = repo.GetOne(1);
            PatientsAddress address = patient.Addresses.First();
            Assert.Equal("Mülheimerstr.", address.Street);
        }
        [Fact] 
        public void GetAddresses()
        {
            PatientRepo repo = new PatientRepo();
            List<DoctorsAddress> addresses = repo.GetDepend<DoctorsAddress>
                (1, "DoctorId");
            Assert.NotEmpty(addresses);
        }

    }
}
