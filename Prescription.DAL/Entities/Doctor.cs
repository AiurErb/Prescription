
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities.Base;

namespace Prescription.DAL.Entities
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LANR { get; set; }
        [Computed]
        public List<DoctorsAddress> DoctorsAddresses { get; set;}
        [Computed]
        public DoctorsAddress CurrentAddress { get; set; }
    }

    
}
