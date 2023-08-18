using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evoting.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        // Election Related Pages
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult UpcomingElection()
        {
            return View();
        }
        public ActionResult Result()
        {
            return View();
        }
        public ActionResult CandidateProfile()
        {
            return View();
        }
        public ActionResult Statics()
        {
            return View();
        }

        // Login & Logout
        public ActionResult Login()
        {
            return View();
        }
    }
}