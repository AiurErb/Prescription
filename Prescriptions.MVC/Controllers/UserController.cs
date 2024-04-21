using Microsoft.AspNetCore.Mvc;
using Prescription.DAL.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Prescriptions.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly string _connectionString;
        public UserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerLocal")??string.Empty;
            if (_connectionString == string.Empty)
                throw new Exception("There isn't valid connection string");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string? returnUrl, 
            [FromForm] string name, [FromForm] string password) 
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM [auth].[User] WHERE Name=@name AND Password=@Password";
            User? user = conn.QueryFirst<User>(sql, new { name, password });
            
            if (user == null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            return Redirect(returnUrl??"/");
            
        }
    }
}
