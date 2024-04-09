using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Repos;

namespace Prescriptions.MVC.Controllers
{
    public class DoctorController : Controller
    {
        private string _connectionString;
        public DoctorController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerLocal")??string.Empty;
            if (_connectionString==string.Empty)
                throw new Exception(message:"There isn't valid connection string");
        }
        public async Task<IActionResult> Index()
        {
            var model = await GetRepo().GetAll();
            return View(model);
        }
        public DoctorRepo GetRepo() => new DoctorRepo(new SqlConnection(_connectionString));
    }
}
