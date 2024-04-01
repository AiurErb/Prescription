using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestPrescript
    {
        [Fact]
        public void GetOnePrescript()
        {
            PrescriptRepo prescript = new();
            Prescript onePrescript = prescript.GetOne(1);
            Assert.NotNull(onePrescript);
            Assert.NotNull(onePrescript.Doctor);
            Assert.NotNull(onePrescript.Patient);
        }
        [Fact]
        public void GetOnePrescriptWithServices()
        {
            PrescriptRepo prescript = new();
            Prescript onePrescript = prescript.GetOne(1);
            Assert.Equal(2, onePrescript.Services.Count());
        }
    }
}
