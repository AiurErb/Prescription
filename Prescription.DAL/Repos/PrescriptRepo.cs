using Prescription.DAL.Entities;
using System.Data;


namespace Prescription.DAL.Repos
{
    public class PrescriptRepo: RepoBase<Prescript>
    {
        PatientRepo patient ;
        DoctorRepo doctor;
        InsuranceRepo insurance;
        ServiceRepo service;
        ServiceCathegoryRepo cathegory;
        DocumentRepo document;

        public PrescriptRepo(IDbConnection connection) : base(connection) 
        {            
            insurance = new(_connection);
            patient = new(_connection);
            doctor = new(_connection);
            service = new(_connection);
            cathegory = new(_connection);
            document = new(_connection);
        }
        public override Prescript? GetOne(long id)
        {
            Prescript? prescript= base.GetOne(id);
            if (prescript == null) { throw new ArgumentOutOfRangeException("There isn't this prescription"); }            
            prescript.Patient = patient.GetOne(prescript.PatientId);            
            prescript.Doctor = doctor.GetOne(prescript.DoctorId);            
            prescript.Insurance = insurance.GetOne(prescript.InsuranceId);
            prescript.Document = document.GetOne(prescript.DocumentId);
            prescript.Services = base.GetDepend<Service>(prescript.Id, "ParentId")
                .Where(service => service.ParentType==(int)ServiceParentType.Prescript)
                .ToList();
            return prescript;
        }
        public override async Task<List<Prescript>> GetAll(bool filter = true)
        {
            List<Prescript> prescripts = await base.GetAll(filter);
            foreach (Prescript p in prescripts)
            {                
                p.Patient = patient.GetOne(p.PatientId);                
                p.Doctor = doctor.GetOne(p.DoctorId);                
                p.Insurance = insurance.GetOne(p.InsuranceId);
                p.Document = document.GetOne(p.DocumentId);
                p.Services = base.GetDepend<Service>(p.Id, "ParentId")
                .Where(service => service.ParentType == (int)ServiceParentType.Prescript)                
                .ToList();
                foreach (Service s in p.Services)
                {
                    s.Cathegory = cathegory.GetOne(s.CathegoryId);
                }
            }

            return prescripts;
        }
    }
}
