using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Prescription.DAL;
using Prescription.DAL.Repos;
using Prescription.Models;

namespace Prescription.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ConnectToDb testCon = new ConnectToDb();

            Assert.NotNull(testCon);
            string sql = "SELECT * FROM Insurance";
            Assert.Equal("DAK", testCon.Test(sql));
        }
        [Fact]
        public void TestInsuranseList()
        {
            string sql = "SELECT * FROM Insurance";
            ConnectToDb testCon = new ConnectToDb();
            List<Models.Insurance> ins = testCon.GetList<Models.Insurance>(sql);
            Assert.Equal(2, ins.Count);
            Assert.Equal("DAK", testCon.Test(sql));
        }
        [Fact]
        public void TestOneInsuranse()
        {
            ConnectToDb testCon = new ConnectToDb();
            SqlConnection con = testCon.GetConnection();
            DAL.Entities.Insurance repo = con.Get<DAL.Entities.Insurance>(1);
            Assert.Equal("DAK", repo.Name);
        }
        [Fact]
        public void TestInsert()
        {
            ConnectToDb testCon = new ConnectToDb();
            InsuranceRepo repo = new(testCon.GetConnection());
            Assert.Equal("AOK", repo.GetOne(1).Name);
        }
    }
}