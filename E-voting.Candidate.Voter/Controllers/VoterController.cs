using Evoting.BusinessLayer;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Candidate.Voter.Controllers
{
    [Authorize]
    public class VoterController : Controller
    {
        // GET: Voter
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult GetAllElectionDetails()
        {
            VoterCandidateViewModel electiondetails = new VoterCandidateViewModel();
            electiondetails.ElectionDetailsList = ElectionSettingsManager.GetAllElectionDetails();
            return View("GetAllElectionDetails", electiondetails);
        }
        private VoterModel VoterDetaisl()
        {
            return (VoterModel)Session["candidateDetails"];
        }
    }
}