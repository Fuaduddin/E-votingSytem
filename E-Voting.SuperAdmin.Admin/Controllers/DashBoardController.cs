using Evoting.BusinessLayer;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult DashBoard()
        {
            var  Dashboard = DashboardSettings();
            return View("DashBoard", Dashboard);
        }
        public ActionResult AdminDashBoard()
        {
            var Dashboard = DashboardSettings();
            return View("AdminDashBoard", Dashboard);
        }



        // DashBoardSettings
        private DashBoardModel DashboardSettings()
        {
            return new DashBoardModel()
            {
                TotalAdmin=StaffManager.GetAllAdmin().Count(),
                TotalAppointment=AppointmentAnnoucementManager.GetAllAppointment().Count(),
                TotalArea=ElectionSettingsManager.GetAllArea().Count(),
                TotalCandiddate=StaffManager.GetAllCandidate().Count(),
                TotalElection=ElectionSettingsManager.GetAllElectionDetails().Count(),
                TotalVoter=StaffManager.GetAllVoter().Count(), 
                TotalZone=ElectionSettingsManager.GetAllZone().Count()
            };
        }
    }
}