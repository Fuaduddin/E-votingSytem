using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evoting.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            CustomerViewModel User= new CustomerViewModel();
            User.UserDetails=new UserModel();
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (user == null)
            {

            }
            return View();
        }
        public ActionResult Logout()
        {
            return View("Login");
        }
    }
}