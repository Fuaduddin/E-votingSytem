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
        public ActionResult Index()
        {
            return View();
        }

        // Election Related Pages
        public ActionResult Appointment()
        {
           GlobalSettingsPatternsandConstant constant = new GlobalSettingsPatternsandConstant();
           CustomerViewModel appointment = new CustomerViewModel();
           appointment.Appointment=new AppointmentModel();
           appointment.AppointmentSubjectList = constant.GetAllSubject();
           return View("Appointment", appointment);
        }

        [HttpPost]
        public ActionResult Appointment(AppointmentModel appointment)
        {
            if(ModelState.IsValid)
            {
                if (AppointmentManager.AddNewAppointment(appointment))
                {
                    ViewData["Message"] = "Your data have been Updated";
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