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
    public class SinglePageController : Controller
    {
        [Route("")]
        // GET: SinglePage
        public ActionResult SinglePageAnnoucement(int id)
        {
            CustomerViewModel EvotingHomePage = new CustomerViewModel();
            EvotingHomePage.AnnoucementList = AppointmentAnnoucementManager.GetAllAnnoucement();
            EvotingHomePage.SingleAnnoucementDetails = AppointmentAnnoucementManager.GetAllAnnoucement().Where(x => x.AnnoucemntID == id).FirstOrDefault();
            return View("SinglePageAnnoucement", EvotingHomePage);
        }
        public JsonResult GetAnnoucement(string search)
        {
            List<AnnoucementModel> AnnoucementModel = new List<AnnoucementModel>();
            if(search != null)
            {
                AnnoucementModel= AppointmentAnnoucementManager.GetAllAnnoucement().Where(x=>x.AnnoucementTitle.Contains(search)).ToList();
            }
            return Json(AnnoucementModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SinglePageElectionDetails(int id)
        {
            CustomerViewModel EvotingHomePage = new CustomerViewModel();
            EvotingHomePage.ElectionDetailsList = ElectionSettingsManager.GetAllElectionDetails();
            EvotingHomePage.SingleElectionDetails = ElectionSettingsManager.GetAllElectionDetails().Where(x => x.ElectionID == id).FirstOrDefault();
            return View("SinglePageElectionDetails", EvotingHomePage);
        }
        public JsonResult GetUpcomingElection(string search)
        {
            List<ElectionDetailsModel> ElectionDetailsModel = new List<ElectionDetailsModel>();
            if (search != null)
            {
                ElectionDetailsModel = ElectionSettingsManager.GetAllElectionDetails().Where(x => x.ElectionName.Contains(search)).ToList();
            }
            return Json(ElectionDetailsModel, JsonRequestBehavior.AllowGet);
        }
    }
}