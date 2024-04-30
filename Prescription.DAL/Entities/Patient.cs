using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace Prescription.DAL.Entities
{
    [Table("Patient")]
    public class Patient: IAddressOwner, ISoftDeleted
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        [Display(Name="Versicherung")]
        public string? InsuranceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name="Geburtstag")]
        public DateTime Birthday { get; set; }
        public bool Deleted { get; set; }
        [Computed]
        public IAddress? CurrentAddress { get; set; }

    }
}
