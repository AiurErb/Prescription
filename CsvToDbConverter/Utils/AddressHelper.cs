
using CsvToDbConverter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsvToDbConverter.Utils
{
    public class AddressHelper
    {
        public Address Parse(string addressString, long idOwnwer)
        {
            Address address = new Address();

            // Define the regular expression pattern to match the address components
            string pattern = @"^(?<Street>.+) (?<Haus>\S+)(?: - (?<ZIP>\d{5}))? (?<City>.+)$";

            // Match the pattern against the address string
            Match match = Regex.Match(addressString, pattern);

            if (match.Success)
            {
                // Populate the address properties from the matched groups
                address.Street = match.Groups["Street"].Value;
                address.Number = match.Groups["Haus"].Value;
                address.Zip = match.Groups["ZIP"].Value;
                address.City = match.Groups["City"].Value;
                address.idOwner = idOwnwer;
            }
            else
            {
                // Handle the case where the address string does not match the pattern
                throw new ArgumentException("Invalid address format");
            }
            return address;
        }
    }
}
