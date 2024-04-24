using BaseSeed.Classes;
using Microsoft.Data.SqlClient;

string connectionString =
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
string path =
    "D:\\repos\\Prescription\\BaseSeed\\PdfFiles\\";
string fileName = "TestVerordnung.pdf";

SqlConnection connection = new SqlConnection(connectionString);

PrescriptPdfBuilder builder = new PrescriptPdfBuilder(connection);

builder.SetName(fileName);
builder.SetPath(path);
builder.SetPatient(1);
builder.SetDoctor(1);
builder.SetInsurance(1);
builder.SaveFile();
