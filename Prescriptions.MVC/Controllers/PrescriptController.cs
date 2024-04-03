using Microsoft.AspNetCore.Mvc;
using Prescription.DAL.Repos;
using Prescription.DAL.Entities;
using Prescriptions.MVC.Models.Prescript;
using Microsoft.Data.SqlClient;

namespace Prescriptions.MVC.Controllers
{
    public class PrescriptController : Controller
    {
        private string _connectionString;
        public PrescriptController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerLocal")?? String.Empty ;
            if (_connectionString == String.Empty ) { throw new ArgumentNullException("There isn't connectionString"); }
        }

        public IActionResult Index()
        {
            SqlConnection connection = new SqlConnection( _connectionString );
            PrescriptRepo repo = new PrescriptRepo( connection );
            IndexOfPrescriptModel model = new IndexOfPrescriptModel();
            model.Prescripts = repo.GetAll().ToList();
            return View(model);
        }
    }
}
