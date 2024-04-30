
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities.Base;
using Prescription.DAL.Interfaces;

namespace Prescription.DAL.Entities
{
    [Table("Doctor")]
    public class Doctor: IAddressOwner, ISoftDeleted
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LANR { get; set; }
        public bool Deleted { get; set; }        
        [Computed]
        public IAddress? CurrentAddress { get; set; }
    }

    
}
