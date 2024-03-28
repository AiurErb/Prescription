using Dapper.Contrib.Extensions;

namespace Prescription.DAL.Entities
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime Birthday { get; set; }
        [Computed]
        public List<PatientsAddress> Addresses { get; set; }

    }
}
