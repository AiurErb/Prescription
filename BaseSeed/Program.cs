using BaseSeed.Classes;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

string connectionString =
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
string path =
    "D:\\repos\\Prescription\\BaseSeed\\PdfFiles\\";
string fileName = "TestVerordnung.pdf";

SqlConnection connection = new SqlConnection(connectionString);
DoctorRepo repo = new(connection);

for (int i = 0; i<20; i++)
{
    Doctor doctor = new Doctor()
    {
        Name = "Doctor" + i.ToString(),
        LANR = i.ToString() + i + i + i
    };
    repo.Insert(doctor);
}

//PrescriptPdfBuilder builder = new PrescriptPdfBuilder(connection);

//builder.SetName(fileName);
//builder.SetPath(path);
//builder.SetPatient(1);
//builder.SetDoctor(1);
//builder.SetInsurance(1);
//builder.SaveFile();
