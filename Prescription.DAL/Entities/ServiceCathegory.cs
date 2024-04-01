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
}
