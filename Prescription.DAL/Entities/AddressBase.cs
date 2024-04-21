using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace Prescription.DAL.Entities
{    
    public class AddressBase
    {
        [DisplayName("Straße")]        
        public string Street { get; set; }
        [DisplayName("Hausnummer")]
        public string Haus { get; set; }
        [DisplayName("Postleitzahl")]
        public string ZIP { get; set; }
        [DisplayName("Ort")]
        public string City { get; set; }
        public override string ToString()
        {
            return $"{Street} {Haus}, {ZIP} {City}";
        }
    }
}