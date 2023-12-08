using Evoting.BusinessLayer;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Evoting.GlobalSetting.Enums;

namespace E_voting.Candidate.Voter.Controllers
{
    public class GiveVoteController : Controller
    {
        // GET: GiveVote
        public ActionResult GiveVote()
        {
            VoterCandidateViewModel Voter = new VoterCandidateViewModel();
            Voter.CandidateList = GetVotingCandidate();
            return View("GiveVote", Voter);
        }
        //public ActionResult GiveVote()
        //{
        //    VoterCandidateViewModel Voter = new VoterCandidateViewModel();
        //    Voter.CandidateList = GetVotingCandidate();
        //    if (Voter.CandidateList.Count > 0)
        //    {
        //        if (CheckGivenVote())
        //        {
        //            return View("ErrorPage");
        //        }
        //        else
        //        {
        //            return View("ErrorPage");
        //        }
        //    }
        //    else
        //    {
        //        return View("ErrorPage");
        //    }
        //}
        [HttpPost]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        public ActionResult GiveVote(VoterCandidateViewModel Voter)
        {
            return View();
        }
        public ActionResult ErrorPage()
        {
            return View("~/Views/ErrorPageVIew/error-404.cshtml");
        }
        public ActionResult GivenVote()
        {
            return View("~/Views/ErrorPageVIew/error-500.cshtml");
        }
        private VoterModel GetVoterDetails()                             
        {
            return (VoterModel) Session["VoterDetails"];
        }
        private ElectionDetailsModel GetElectionDetails()
        {
            var ElectionDetails = ElectionSettingsManager.GetAllElectionDetails().Where(x => x.StartDate == DateTime.Now && x.ElectionStatus == ElectionStatus.Pending.ToString()).FirstOrDefault();
            return ElectionDetails;
        }
        private List<CandidateModel> GetVotingCandidate()
        {
            var VoterDetails = GetVoterDetails();
            var VotingCandidate = GetElectionDetails();
            //  var CandidateList = GiveVoteManager.GetZoneAreaWiseCandidate(VotingCandidate.ElectionID,VoterDetails.VoterZone,VoterDetails.VoterArea);
            var CandidateList = GiveVoteManager.GetZoneAreaWiseCandidate(1,3,3);
            return CandidateList;
        }
        private bool CheckGivenVote()
        {
            bool NotGivenVote=true;
            var VoterDetails = GetVoterDetails();
            var VoteGivenCheck = GiveVoteManager.GiveVoteList().Where(x=>x.VoterID==VoterDetails.VoterID).FirstOrDefault();
            if (VoteGivenCheck != null)
            {
                NotGivenVote = false;
            }
            return NotGivenVote;
        }
    }
}