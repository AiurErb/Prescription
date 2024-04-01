using Prescription.DAL.Entities;

namespace Prescription.DAL.Repos
{
    public enum ServiceParentType { Prescript = 1, Permit = 2 }
    public class ServiceRepo: RepoBase<Service>
    {
        public ServiceRepo()
        {
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }        
    }
}
