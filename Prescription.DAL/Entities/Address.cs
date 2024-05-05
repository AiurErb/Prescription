using Prescription.DAL.Interfaces;

namespace Prescription.DAL.Entities
{
    public class Address: IAddress, ISoftDeleted
    {
        public virtual long Id { get; set; }
        public string? City { get; set; }
        public string? ZIP { get; set; }
        public string? Street { get; set; }  
        public string? Haus { get; set; }
        public bool Deleted { get ; set; }

        public override string ToString()
        {
            return $"{Street} {Haus}, {ZIP} {City}" ?? "Unbekannt";
        }
    }
}
