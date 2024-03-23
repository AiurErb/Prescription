using Prescription.DAL;

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
            Assert.Equal("AOK", testCon.Test(sql));
        }
    }
}