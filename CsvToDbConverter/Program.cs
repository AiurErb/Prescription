using CsvToDbConverter.DbConnection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

class Program
{
    static void Main()
    {
        string filePath = "D:\\repos\\Prescription\\CsvToDbConverter\\RawData\\Patients.csv";

        string patientName;
        string insuranseNr;
        string stringBirsday;
        Patient patient;

        using (TextFieldParser parser = new TextFieldParser(filePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");

            parser.ReadLine();
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                patient = new Patient
                {
                    Name = fields[0],
                    InsuranceNumber = fields[4],
                    Birthday = ExtractDate(fields[3])
                };
                PatientRepo repo = new PatientRepo(DbConnection.GetConnection());
                try
                {
                    repo.Insert(patient);
                    Console.WriteLine($"{patient.Name} was inserted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        
    }

    private static DateTime ExtractDate(string stringDate)
    {
        int dayPosition;

        if (stringDate.Length == 8) 
        {
            dayPosition = 2; 
        }
        else if (stringDate.Length == 7)
        {
            dayPosition = 1;
        }
        else
        {
            throw new ArgumentException("String date is wrong");
        }
        string stringDay = stringDate.Substring(0, dayPosition);
        string stringMonth = stringDate.Substring(dayPosition, 2);
        string stringYear = stringDate.Substring(dayPosition + 2);
        return new DateTime(int.Parse(stringYear),int.Parse(stringMonth), int.Parse(stringDay));
        
    }
}