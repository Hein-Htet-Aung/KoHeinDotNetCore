using KoHeinDotNetCore.LoginUser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace KoHeinDotNetCore.LoginUser.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly AppDBContext _db;
        
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _db = new AppDBContext();
        }

        [ActionName("LoginUI")]
        public IActionResult login()
        {
            return View("login");
        }

        [ActionName("Validatelogin")]
        public IActionResult Validatelogin(UsersModel User)
        {
            UsersModel? Checklogin = _db.Users.Where(x => x.UserName == User.UserName && x.Password == User.Password).FirstOrDefault();

            if (Checklogin is null)
            {
                return View("LoginUI");
            }

            CookieOptions cookie = new CookieOptions();
            DateTime SessionExpire = DateTime.Now.AddSeconds(10);
            cookie.Expires = SessionExpire;
            Response.Cookies.Append("Username", User.UserName, cookie);
            Response.Cookies.Append("Password", User.Password, cookie);

            LoginModel Login = new LoginModel();

            Login.SessionId = Guid.NewGuid().ToString();
            Login.UserId = Checklogin.UserId;
            Login.SessionExpired = SessionExpire;
            _db.Login.Add(Login);
            _db.SaveChanges();

            return Redirect("/Home");
        }



    }
}
