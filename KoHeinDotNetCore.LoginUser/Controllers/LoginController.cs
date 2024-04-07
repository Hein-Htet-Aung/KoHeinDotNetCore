using KoHeinDotNetCore.LoginUser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KoHeinDotNetCore.LoginUser.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult login()
        {
            return View();
        }


        
    }
}
