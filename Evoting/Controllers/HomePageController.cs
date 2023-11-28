using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.Models;
using Evoting.BusinessLayer;
using Evoting.GlobalSetting;
using System.Web.WebPages;

namespace Evoting.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        [Route("Home")]
        public ActionResult Index()
        {
            return View("Index");
        }

		// Election Related Pages
		[Route("Appointment")]
		public ActionResult Appointment()
        {
            GlobalCommonData constant = new GlobalCommonData();
           CustomerViewModel appointment = new CustomerViewModel();
           appointment.Appointment=new AppointmentAnnoucementModel();
           appointment.AppointmentSubject = constant.AppointmentSubject;
           return View("Appointment", appointment);
        }

        [HttpPost]
        public ActionResult Appointment(AppointmentAnnoucementModel appointment)
        {
            if(ModelState.IsValid)
            {
                if (AppointmentAnnoucementManager.AddNewAppointment(appointment))
                {
                    ViewData["Message"] = "In 72 hours Our agents will contact with you.. ";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
                }
            }
            else
            {
                ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
            }
            return View("Appointment");
  
        }
		[Route("UpcomingElection")]
		public ActionResult UpcomingElection()
        {
            return View();
        }
		[Route("Result")]
		public ActionResult Result()
        {
            return View();
        }
		[Route("CandidateProfile")]
		public ActionResult CandidateProfile()
        {
            return View();
        }
		[Route("Statics")]
		public ActionResult Statics()
        {
            return View();
        }
        public ActionResult about()
        {
            return View("about");
        }
        [Route("Login")]
		// Login & Logout
		public ActionResult Login()
        {
            return View();
        }


        
    }
}