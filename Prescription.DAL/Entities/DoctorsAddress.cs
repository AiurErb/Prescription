using Dapper.Contrib.Extensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Prescription.DAL.Entities
{
    [Table("DoctorsAddress")]
    public class DoctorsAddress
    {
        [Key]
        public long Id { get; set; }
        public string Street {  get; set; }
        public string Haus {  get; set; }
        public string ZIP {  get; set; }
        public string City {  get; set; }
        public long DoctorId { get; set; }
        public bool Current {  get; set; }
        
    }
}
