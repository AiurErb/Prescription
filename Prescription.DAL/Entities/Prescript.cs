using Dapper.Contrib.Extensions;


namespace Prescription.DAL.Entities
{
    [Table("Prescript")]
    public class Prescript
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long PatientId { get; set; }
        [Computed]
        public Patient? Patient { get; set; }
        public long DoctorId { get; set; }
        [Computed]
        public Doctor? Doctor { get; set; }
        public long InsuranceId { get; set; }
        [Computed]
        public Insurance? Insurance { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long DocumtntId { get; set; }
        
    }
}
