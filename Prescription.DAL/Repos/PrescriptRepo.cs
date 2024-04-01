using Prescription.DAL.Entities;


namespace Prescription.DAL.Repos
{
    public class PrescriptRepo: RepoBase<Prescript>
    {
        PatientRepo patient = new PatientRepo();
        DoctorRepo doctor = new DoctorRepo();
        InsuranceRepo insurance = new();
        ServiceRepo service = new ServiceRepo();
        ServiceCathegoryRepo cathegory = new ServiceCathegoryRepo();

        public PrescriptRepo()
        {
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }
        public override Prescript? GetOne(long id)
        {
            Prescript prescript= base.GetOne(id);
            if (prescript == null) { throw new ArgumentOutOfRangeException("There isn't this prescription"); }            
            prescript.Patient = patient.GetOne(prescript.PatientId);            
            prescript.Doctor = doctor.GetOne(prescript.DoctorId);            
            prescript.Insurance = insurance.GetOne(prescript.InsuranceId);
            prescript.Services = base.GetDepend<Service>(prescript.Id, "ParentId")
                .Where(service => service.ParentType==(int)ServiceParentType.Prescript)
                .ToList();
            return prescript;
        }
        public override List<Prescript> GetAll()
        {
            List<Prescript> prescripts = base.GetAll();
            foreach (Prescript p in prescripts)
            {                
                p.Patient = patient.GetOne(p.PatientId);                
                p.Doctor = doctor.GetOne(p.DoctorId);                
                p.Insurance = insurance.GetOne(p.InsuranceId);
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
