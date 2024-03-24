using Dapper.Contrib.Extensions;

namespace Prescription.DAL.Entities.Base
{
    public abstract class DbEntity
    {
        [ExplicitKey]
        int Id { get; set; }
    }
}
