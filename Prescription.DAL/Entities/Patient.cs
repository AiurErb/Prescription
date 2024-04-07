using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace Prescription.DAL.Entities
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Versicherung")]
        public string InsuranceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name="Geburtstag")]
        public DateTime Birthday { get; set; }
        [Computed]
        public List<PatientsAddress> Addresses { get; set; }
        [Computed]
        public PatientsAddress CurrentAddress { get; set; }

    }
}
