using Prescription.DAL.Interfaces;

namespace Prescriptions.MVC.Models.Insurance
{
    public class OneInsuranceView: IInsurance
    {
        public long Id { get; set; }
        public string Name { get; set; }        
    }
}
