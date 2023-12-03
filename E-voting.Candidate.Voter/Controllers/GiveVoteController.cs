using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Candidate.Voter.Controllers
{
    public class GiveVoteController : Controller
    {
        // GET: GiveVote
        public ActionResult GiveVote()
        {
            return View();
        }
        [HttpPost]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        public ActionResult GiveVote(VoterCandidateViewModel Voter)
        {
            return View();
        }
        public ActionResult GivenVotePage()
        {
            return View();
        }
        private VoterModel GetVoterDetails()                             
        {
            return (VoterModel) Session["VoterDetails"];
        }
        //private ElectionDetailsModel GetElectionDetails()
        //{

        //}
        //private bool CheckGivenVote()
        //{
        //    bool GivenVote;
        //    var checkvoting
        //    if()
        //}
    }
}