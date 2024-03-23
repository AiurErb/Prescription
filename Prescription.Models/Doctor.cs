namespace Prescription.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LANR { get; set; }
        public Address Address { get; set; }
    }
}
