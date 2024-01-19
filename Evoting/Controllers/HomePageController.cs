using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.Models;
using Evoting.BusinessLayer;
using Evoting.GlobalSetting;
using System.Web.WebPages;
using Newtonsoft.Json;

namespace Evoting.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        [Route("/Home")]
        public ActionResult Index()
        {
            CustomerViewModel EvotingHomePage = new CustomerViewModel();
            EvotingHomePage.AnnoucementList = AppointmentAnnoucementManager.GetAllAnnoucement();
            EvotingHomePage.ElectionDetailsList=ElectionSettingsManager.GetAllElectionDetails();
            EvotingHomePage.CandidateList=StaffManager.GetAllCandidate();
            return View("Index",EvotingHomePage);
        }

		// Election Related Pages
		[Route("/Appointment")]
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
		[Route("/UpcomingElection")]
		public ActionResult UpcomingElection()
        {
            CustomerViewModel EvotingHomePage = new CustomerViewModel();
            EvotingHomePage.ElectionDetailsList = GetPaginationUpcomingElection(1,10);
            EvotingHomePage.TotalPage = pagecountUpcomingElection(10);
            return View("UpcomingElection", EvotingHomePage);
        }
        // All Extra Feauture
        private List<ElectionDetailsModel> GetPaginationUpcomingElection(int pageindex, int pagesize)
        {
            List<ElectionDetailsModel> UpcomingElectionlist = ElectionSettingsManager.GetAllElectionDetails().OrderByDescending(x => x.StartDate).ToList();
            return UpcomingElectionlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountUpcomingElection(int perpagedata)
        {
            List<ElectionDetailsModel> UpcomingElectionlist = ElectionSettingsManager.GetAllElectionDetails().OrderByDescending(x => x.StartDate).ToList();
            return Convert.ToInt32(Math.Ceiling(UpcomingElectionlist.Count() / (double)perpagedata));
        }
        public List<ElectionDetailsModel> perpageshowdataUpcomingElection(int pageindex, int pagesize)
        {
            List<ElectionDetailsModel> UpcomingElectionlist = ElectionSettingsManager.GetAllElectionDetails().OrderByDescending(x => x.StartDate).ToList();
            return UpcomingElectionlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataUpcomingElection(int pageindex, int pagesize)
        {
            CustomerViewModel UpcomingElection = new CustomerViewModel();
            UpcomingElection.ElectionDetailsList = perpageshowdataUpcomingElection(pageindex, pagesize);
            UpcomingElection.TotalPage = pagecountCandidate(pagesize);
            var result = JsonConvert.SerializeObject(UpcomingElection);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("/Result")]
		public ActionResult Result()
        {
            return View("Result");
        }
		[Route("/CandidateProfile")]
		public ActionResult CandidateProfile()
        {
            CustomerViewModel CandidateList = new CustomerViewModel();
            CandidateList.CandidateList = GetPaginationCandidate(1,10);
            CandidateList.TotalPage = pagecountCandidate(10);
            return View("CandidateProfile", CandidateList);
        }
        // All Extra Feauture
        private List<CandidateModel> GetPaginationCandidate(int pageindex, int pagesize)
        {
            List<CandidateModel> CandidateList = StaffManager.GetAllCandidate();
            return CandidateList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountCandidate(int perpagedata)
        {
            List<CandidateModel> CandidateList = StaffManager.GetAllCandidate();
            return Convert.ToInt32(Math.Ceiling(CandidateList.Count() / (double)perpagedata));
        }
        public List<CandidateModel> perpageshowdataCandidate(int pageindex, int pagesize)
        {
            List<CandidateModel> CandidateList = StaffManager.GetAllCandidate();
            return CandidateList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            CustomerViewModel CandidateList = new CustomerViewModel();
            CandidateList.CandidateList = perpageshowdataCandidate(pageindex, pagesize);
            CandidateList.TotalPage = pagecountCandidate(pagesize);
            var result = JsonConvert.SerializeObject(CandidateList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("/About")]
        public ActionResult about()
        {
            return View("about");
        }
        [Route("/Login")]
		// Login & Logout
		public ActionResult Login()
        {
            return View("Login");
        }
    }
}