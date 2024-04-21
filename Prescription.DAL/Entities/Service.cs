using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Prescription.DAL.Entities
{
    [Table("Service")]
    public class Service
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { set; get; }
        public long CathegoryId { get; set; }
        [Computed]
        public ServiceCathegory Cathegory { get; set; }
        public string Frequence { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long ParentId { get; set; }
        public long ParentType { get; set; }
    }
}
