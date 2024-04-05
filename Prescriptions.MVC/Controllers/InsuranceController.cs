using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
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
        public async Task<IActionResult> Index()
        {
            var model = await GetRepo().GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Insurance newInsurance)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            newInsurance.Id = 0;
            GetRepo().Insert(newInsurance);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(GetRepo().GetOne(id));
        }
        [HttpPost]
        public IActionResult EditAsync(Insurance editedInsurance)
        {
            if (!ModelState.IsValid)
            {
                return View(editedInsurance);
            }
            GetRepo().Update(editedInsurance);
            return RedirectToAction(nameof(Index));
        }

        private InsuranceRepo GetRepo()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return new InsuranceRepo(connection);
        }
    }
}
