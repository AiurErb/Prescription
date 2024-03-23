using Microsoft.Data.SqlClient;
using Dapper;


string connectionString = 
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
SqlConnection con = new SqlConnection(connectionString);
string sql = "SELECT * FROM Insurance";
List<Isurance> ins = con.Query<Isurance>(sql).ToList();
Console.WriteLine(ins.FirstOrDefault().Name);

public record class Isurance (int Id, string Name);
