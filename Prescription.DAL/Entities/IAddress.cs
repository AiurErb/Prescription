namespace Prescription.DAL.Entities
{
    public interface IAddress
    {
        string City { get; set; }
        bool Current { get; set; }        
        string Haus { get; set; }
        long Id { get; set; }
        string Street { get; set; }
        string ZIP { get; set; }
    }
}