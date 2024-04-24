using Prescription.DAL.Entities;


namespace BaseSeed.Classes
{
    public class PrescriptPdf
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor{ get; set; }
        public Insurance Insurance { get; set; }
    }
}
