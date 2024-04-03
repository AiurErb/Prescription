using Dapper.Contrib.Extensions;

namespace Prescription.DAL.Entities
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
        public DateTime Created {  get; set; }
        public DateTime Modifed { get; set; }
    }
}
