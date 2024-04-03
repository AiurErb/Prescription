using Prescription.DAL.Entities;
using System.Data;


namespace Prescription.DAL.Repos
{
    public class InsuranceRepo : RepoBase<Insurance>
    {
        public InsuranceRepo(IDbConnection connection) : base(connection)
        {
        }
    }
}
