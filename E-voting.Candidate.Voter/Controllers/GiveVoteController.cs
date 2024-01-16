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
            if (Voter.CandidateList.Count > 0)
            {
                if (CheckGivenVote())
                {
                    return View("ErrorPage");
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            else
            {
                return View("ErrorPage");
            }
        }
        [HttpPost]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        public ActionResult GiveVote(int CandidateID)
        {
            if(CandidateID > 0)
            {
                var GiveVote = GiveVoteDetails(CandidateID);
                if (GiveVoteManager.GiveVote(GiveVote))
                {
                    ViewData["Message"] = "Your vote have been submitted";
                }
            }
            else
            {
                ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
            }
            return View("GivenVote");
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
            var CandidateList = GiveVoteManager.GetZoneAreaWiseCandidate(VotingCandidate.ElectionID,VoterDetails.VoterZone,VoterDetails.VoterArea);
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
        private GiveVoteModel GiveVoteDetails(int id)
        {
            GiveVoteModel vote= new GiveVoteModel();
            var VoterDetails = GetVoterDetails();
            var ElectionDetails = GetElectionDetails();
            if (id>0)
            {
                vote.VoterID = VoterDetails.VoterID;
                vote.ElectionID = ElectionDetails.ElectionID;      
                vote.CandidateID = id;
                vote.VoteDate=DateTime.Now;
            }
            return vote;
        }
    }
}