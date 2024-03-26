using Prescription.DAL.Entities;
using Prescription.DAL.Repos;


namespace Prescription.Test
{
    public class UnitTest1
    {        
        
        [Fact]
        public void TestInsuranceGetOne()
        {            
            InsuranceRepo repo = new InsuranceRepo();
            Assert.Equal("AOK", repo.GetOne(2).Name);
        }
        [Fact]
        public void TestInsuranceGetAll()
        {
            InsuranceRepo repo = new InsuranceRepo();
            Assert.Equal(4, repo.GetAll().Count());
        }
        [Fact]
        public void TestInsuranceInsertDelete()
        {
            InsuranceRepo repo = new InsuranceRepo();
            Insurance newInsurance = new Insurance 
            {
                Name = "Techniker"
            };
            long id = repo.Insert(newInsurance);
            Assert.Equal(5, repo.GetAll().Count());
            Assert.Equal("Techniker", repo.GetOne(id)?.Name);
            repo.Delete(newInsurance);
            Assert.Equal(4, repo.GetAll().Count());
        }
        [Fact]
        public void TestInsuranceUpdate()
        {
            InsuranceRepo repo = new InsuranceRepo();
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