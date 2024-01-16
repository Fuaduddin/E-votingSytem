using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class CandidateModel
    {
        [Key]
        public int CandidateID { get; set; }
        public string CandidateImage { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string CandidateName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Phone Number")]
        public string CandidatePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Email")]
        public string CandidateEmail { get; set; }
        [Required(ErrorMessage = "Please Select Zone")]
        public int CandidateZone { get; set; }
        [Required(ErrorMessage = "Please Select Area")]
        public int CandidateArea { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string CandidatePermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string CandidatePresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter NID")]
        public string CandidateNID { get; set; }
        public int? CandidateParty { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string CandidateGender { get; set; }
        public PartyModel Party { get; set; }
        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
        public AssignmentCandidateModel AssignmentCandidate { get; set; }
    }
    public class AssignmentCandidateModel
    {
        public int ElectionCandidateID { get; set; }
        public int CandidateID { get; set; }
        public int ElectionID { get; set; }
        public int ElectionComplete { get; set; }
        public string CandidateSymbol { get; set; }
        public int ZoneandArea { get; set; }

        public CandidateModel Candidate { get; set; }
        public  ElectionDetailsModel Election_Details { get; set; }
        public  ElectionAssignmentModel ElectionAssignment { get; set; }
    }
}
