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
    public class VotingSettingsController : Controller
    {
        // GET: VotingSettings
        public ActionResult ElectionVotingResult()
        {
            SuperAdminAndAdminViewModel ElectionResultDetails = new SuperAdminAndAdminViewModel();
            ElectionResultDetails.ElectionResult = GiveVoteManager.ElectionResultDetails(1);
            return View("ElectionVotingResult", ElectionResultDetails);
        }

        public ActionResult PublishedElectionVotingResult(int AssingElectionID)
        {
            ElectionResultDetailsModel ResultDetails =new ElectionResultDetailsModel() ;
            if (AssingElectionID < 0)
            {
                 ResultDetails = GiveVoteManager.ElectionResultDetails(AssingElectionID);
            }
            return View("ElectionVotingResult", ResultDetails);
        }
        [HttpPost]
        public ActionResult PublishedElectionVotingResultSubmit(int assigID)
        {
            var result= GiveVoteManager.ElectionResultDetails(assigID);
            if (result != null)
            {
                if (GiveVoteManager.PublishElectionResultDetails(result.Result))
                {
                    ViewData["Message"] = "Your data  have  been Published";
                }
                else
                {
                    ViewData["Message"] = "Your data  have  not been Published";
                }
            }
            SuperAdminAndAdminViewModel ElectionResultDetails = new SuperAdminAndAdminViewModel();
            ElectionResultDetails.ElectionResult = GiveVoteManager.ElectionResultDetails(1);
            return View("ElectionVotingResult", ElectionResultDetails);
        }
    }
}