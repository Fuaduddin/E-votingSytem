using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class GiveVoteModel
    {
        public int VoteID { get; set; }
        public int ElectionID { get; set; }
        public int CandidateID { get; set; }
        public int VoterID { get; set; }
        public DateTime VoteDate { get; set; }

        public  CandidateModel Candidate { get; set; }
        public  ElectionDetailsModel ElectionDetails { get; set; }
        public  VoterModel Voter { get; set; }
    }
}
