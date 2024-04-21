using Prescription.DAL.Entities;
using System.Data;

namespace Prescription.DAL.Repos
{
    public enum ServiceParentType { Prescript = 1, Permit = 2 }
    public class ServiceRepo: RepoBase<Service>
    {
        public ServiceRepo(IDbConnection connection) : base(connection)
        {
        }        
    }
}
