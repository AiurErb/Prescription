using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescriptions.MVC.Controllers
{
    public class PatientController : Controller
    {
        private string _connectionString;
        public PatientController(IConfiguration config) 
        {
            _connectionString = config.GetConnectionString("SqlServerLocal")??string.Empty;
            if (_connectionString == string.Empty )
            {
                throw new ArgumentOutOfRangeException("There isn't valid connection string");
            }
        }
        public async Task<IActionResult> Index()
        {
            var model = await GetRepo().GetAll();
            return View(model);
        }
        public IActionResult Details([FromRoute] long id)
        {
            return View(GetRepo().GetOne(id));
        }
        [HttpGet]
        public IActionResult NewAddress([FromRoute] long id)
        {
            PatientsAddress model = new PatientsAddress()
            {
                Id = 0,
                PatientId = id,
                Current=true
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult NewAddress([FromForm] DbAddress model)
        {
            if (!ModelState.IsValid) return View(model);
            DbAddressRepo addressRepo = new DbAddressRepo(
                new SqlConnection(_connectionString));
            long current = addressRepo.Insert(model);
            return RedirectToAction(nameof(Details), new { id = model.OwnerId });
            
            
        }
        private PatientRepo GetRepo()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return new PatientRepo(connection);
        }
    }
}
