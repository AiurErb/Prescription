using System;

namespace Prescription.Models
{
    public class PrescribedService
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public string Frequency { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
