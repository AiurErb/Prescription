using Dapper.Contrib.Extensions;

namespace Prescription.DAL.Entities
{
    [Table("ServiceCathegory")]
    public class ServiceCathegory
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
    [Table("Service")]
    public class Service
    {
        [Key]
        public long Id { set; get; }
        public long CathegoryId { get; set; }
        [Computed]
        public ServiceCathegory Cathegory { get; set; }
        public string Frequence { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long ParentId { get; set; }
        public long PatentType { get; set; }
    }
}
