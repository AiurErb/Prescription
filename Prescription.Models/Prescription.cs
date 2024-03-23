using System;
using System.Collections.Generic;
using System.IO;

namespace Prescription.Models
{
    public class Prescription
    {
        public int Id {  get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Insurance Insurance { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<PrescribedService> Services { get; set; }
        public FileInfo File { get; set; }
    }
}
