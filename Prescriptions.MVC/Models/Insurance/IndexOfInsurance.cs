using Prescription.DAL.Interfaces;

namespace Prescriptions.MVC.Models.Insurance
{
    public class IndexOfInsurance
    {
        public List<IInsurance> Insurances { get; set; } = new();
    }
}
