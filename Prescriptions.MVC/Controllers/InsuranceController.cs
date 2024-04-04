using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Repos;

namespace Prescriptions.MVC.Controllers
{
    public class InsuranceController : Controller
    {
        private string? _connectionString;

        public InsuranceController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerLocal");
        }
        public IActionResult Index()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            InsuranceRepo repo = new InsuranceRepo(connection);
            return View(repo.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
