using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Prescription.DAL.Entities
{
    [Table("PatientsAddress")]
    public class PatientsAddress : IAddress
    {
        [Key]
        public long Id { get; set; }
        public string Street { get; set; }
        public string Haus { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public long PatientId { get; set; }
        public bool Current { get; set; }
        [Computed]
        public Patient Patient { get; set; }

    }
}
