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
                PatientId = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult NewAddress([FromRoute] long patientId,[FromBody] PatientsAddress model)
        {
            if (!ModelState.IsValid) return View(model);
            PatientsAddressRepo addressRepo = new PatientsAddressRepo(
                new SqlConnection(_connectionString));
            long current = addressRepo.Insert(model);
            if (addressRepo.SetCurrent(current, model.PatientId))
            {
                return RedirectToAction(nameof(Details), model.PatientId);
            }
            else return View(model);
        }
        private PatientRepo GetRepo()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return new PatientRepo(connection);
        }
    }
}
