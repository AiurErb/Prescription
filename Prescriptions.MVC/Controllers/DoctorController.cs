using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prescription.DAL.Entities;
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
        [HttpGet]
        public IActionResult NewDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDoctor([FromForm] Doctor doctor)
        {
            if (!ModelState.IsValid) return View();
            long id = GetRepo().Insert(doctor);
            return RedirectToAction(nameof(Details),new{id=id});
        }
        public IActionResult Details(int id)
        {
            Doctor model = GetRepo().GetOne(id);
            return View(model);
        }
        public DoctorRepo GetRepo() => new DoctorRepo(new SqlConnection(_connectionString));
    }
}
