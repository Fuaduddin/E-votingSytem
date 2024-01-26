using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class ElectionResultDetailsModel
    {
        public ElectionDetailsModel ElectionDetails { get; set; }
        public VotingResultModel Result { get; set; }
        public Dictionary<areamodel,List<SingleCandidateGivenVoteCount>> AllCandidateResults { get; set;}
    }
    public class GiveVoteModel
    {
        [Key]
        public int VoteID { get; set; }
        public int ElectionID { get; set; }
        public int CandidateID { get; set; }
        public int VoterID { get; set; }
        public DateTime VoteDate { get; set; }

        public  CandidateModel Candidate { get; set; }
        public  ElectionDetailsModel ElectionDetails { get; set; }
        public  VoterModel Voter { get; set; }
    }
    public class VotingResultModel
    {
        public int ResultID { get; set; }
        public int ElectionDetails { get; set; }
        public int TotalVoter { get; set; }
        public int TotalGivenVote { get; set; }
        public int SelectedCandidate { get; set; }
        public int SelectedCandidateVote { get; set; }
        public int RunnerUpCandidate { get; set; }
        public int RunnerUpCandidateVote { get; set; }
        public int AssignmentElectionID { get; set; }
        public areamodel AreaDetails { get; set; }
        public CandidateModel SelectedCandidateDetails { get; set; }
        public CandidateModel RunnerUpCandidateDetails { get; set; }
    }
    public class SingleCandidateGivenVoteCount
    {
        public CandidateModel CandidateDetails { get; set; }
        public int TotalVote { get; set; }       
    }
}
