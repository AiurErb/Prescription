using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDbConverter.Classes
{
    public class Doctor
    {
        public long id {  get; set; }
        public string Anrede {  get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phones { get; set; }
        public string Spec {  get; set; }

    }

    public class Address
    {
        public string City { get; set; }
        public string Zip { get; set;}
        public string Street { get; set; }
        public string Number { get; set; }
        public long idOwner { get; set; }
    }
}
