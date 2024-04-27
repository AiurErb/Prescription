using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;

namespace Prescription.DAL.Entities
{
    [Table("Address")]
    public class DbAddress: Address
    {        
        public long OwnerId { get; set; }
        public int OwnerType { get; set; }
        public bool Current { get; set; } = true;
    }
    public enum AddressOwner { Patient,Doctor}
}
