using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Prescription.DAL.Entities
{
    [Table("DoctorsAddress")]
    public class DoctorsAddress : AddressBase
    {
        [Key]
        public long Id { get; set; }        
        public long DoctorId { get; set; }
        public bool Current { get; set; }

    }
}
