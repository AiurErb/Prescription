using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;

namespace Prescription.DAL.Entities
{
    [Table("Address")]
    public class DbAddress: Address
    {
        [Key]
        public override long Id { get; set; }
        public long OwnerId { get; set; }
        public int OwnerType { get; set; }
        public bool Current { get; set; }
        
    }
    public enum AddressOwner { Patient,Doctor}
}
