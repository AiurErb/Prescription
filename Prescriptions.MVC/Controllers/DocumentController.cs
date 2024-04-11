using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescriptions.MVC.Controllers
{
    public class DocumentController : Controller
    {
        private string _connectionString;
        private readonly IWebHostEnvironment _environment;
        private readonly string _uploadsDir;
        public DocumentController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _connectionString = configuration.GetConnectionString("SqlServerLocal");
            if (_connectionString.IsNullOrEmpty())
                throw new Exception("Ther isn't valid connection string");
            _environment = environment;
            _uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        }
        private DocumentRepo GetRepo() => new DocumentRepo(new SqlConnection(_connectionString));
        // GET: DocumentController/OpenFile
        public IActionResult OpenFile(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                string contentType = "application/pdf";
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                return File(fileStream, contentType, fileName);
            }
            else return NotFound();
        }
        // GET: DocumentController
        public async Task<ActionResult> Index()
        {
            List<Document> model = await GetRepo().GetAll();
            return View(model);
        }

        // GET: DocumentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Document newDoc)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");                    
                    var filePath = Path.Combine(uploads, file.FileName);
                    newDoc.Link = filePath.ToString();
                    Console.WriteLine(filePath.ToString());
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    Console.WriteLine("File is empty");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex}");
            }
            newDoc.Id = 0;
            newDoc.Created = DateTime.Now;            
            GetRepo().Insert(newDoc);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
