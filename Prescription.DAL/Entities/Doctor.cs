
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities.Base;
using Prescription.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prescription.DAL.Entities
{
    [Dapper.Contrib.Extensions.Table("Doctor")]
    public class Doctor: IAddressOwner, ISoftDeleted
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LANR { get; set; }
        public bool Deleted { get; set; }        
        [Computed]
        public IAddress? CurrentAddress { get 
                { if (_address == null)
                    return UnknownAddress;
                else
                    return _address;
            } set { _address = value; } }
        [NotMapped]
        private IAddress _address;
        [NotMapped]
        private readonly Address UnknownAddress = new Address
        {
            City = "Unbekannt",
            ZIP = "00000",
            Street = "Unbekannt",
            Haus = "00"
        };
    }
    


}
