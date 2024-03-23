using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string InsuranceNumber {  get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
    }
}
