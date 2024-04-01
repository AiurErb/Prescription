using Microsoft.AspNetCore.Mvc;
using Prescription.DAL.Repos;
using Prescription.DAL.Entities;
using Prescriptions.MVC.Models.Prescript;

namespace Prescriptions.MVC.Controllers
{
    public class PrescriptController : Controller
    {
        private PrescriptRepo repo = new();
        public IActionResult Index()
        {
            IndexOfPrescriptModel model = new IndexOfPrescriptModel();
            model.Prescripts = repo.GetAll().ToList();
            return View(model);
        }
    }
}
