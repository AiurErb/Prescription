using Prescription.DAL.Entities;


namespace Prescription.DAL.Repos
{
    public class InsuranceRepo : RepoBase<Insurance>
    {
        public InsuranceRepo()
        {
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }
    }
}
