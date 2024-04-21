using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Prescription.DAL.Entities
{
    [Table("PatientsAddress")]
    public class PatientsAddress : AddressBase
    {
        [Key]
        public long Id { get; set; }
        public long PatientId { get; set; }
        //[Computed]
        //public Patient? Patient { get; set; }
        public bool Current { get; set; }

    }
}
