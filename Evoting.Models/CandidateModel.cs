using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class CandidateModel
    {
        public int CandidateID { get; set; }
        public string CandidateImage { get; set; }
        public string CandidateName { get; set; }
        public string CandidatePhoneNumber { get; set; }
        public string CandidateEmail { get; set; }
        public int CandidateZone { get; set; }
        public int CandidateArea { get; set; }
        public string CandidatePermanentAddress { get; set; }
        public string CandidatePresentAddress { get; set; }
        public string CandidateNID { get; set; }
        public int? CandidateParty { get; set; }
        public int UserID { get; set; }
        public string CandidateGender { get; set; }
        public PartyModel Party { get; set; }
        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
    }
    public class AssignmentCandidateModel
    {
        public int ElectionCandidateID { get; set; }
        public int CandidateID { get; set; }
        public int ElectionID { get; set; }
        public int ElectionComplete { get; set; }
        public CandidateModel Candidate { get; set; }
        public virtual ElectionDetailsModel Election_Details { get; set; }
    }
}
