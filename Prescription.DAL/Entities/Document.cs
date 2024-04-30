using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;

namespace Prescription.DAL.Entities
{
    [Table("Document")]
    public class Document : ISoftDeleted
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; } = 1;
        public string? Link { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modifed { get; set; }
        public bool Deleted {get;set;} 
    }
}
