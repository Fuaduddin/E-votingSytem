using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;

namespace Evoting.Models
{
    public class SuperAdminAndAdminViewModel
    {
        
        // All Single Model
        public PartyModel Party { get; set; }
        public ElectionModel ElectionType { get; set; }
        public zoneModel Zone { get; set; }
        public areamodel Area { get; set; }
        public ElectionDetailsModel ElectionDetails { get; set; }
        public ElectionAssignmentModel AssignElectionDetails { get; set; }
        public VoterModel Voter { get; set; }
        public CandidateModel Candidate { get; set; }
        public AdminModel Admin { get; set; }
        public UserModel User { get; set; }
        public AnnoucementModel Annoucement { get; set; }
        public AppointmentAnnoucementModel Appointment { get; set; }
        public AssignmentAppointment AssignemntAppointment { get; set; }
        public VotingResultModel ElectionResultDetails { get; set; }
        public ElectionResultDetailsModel ElectionResult { get; set; }

        // All List

        public List<AssignmentAppointment> AssignemntAppointmentList { get; set; }
        public List<AppointmentAnnoucementModel> AppointmentList { get; set; }
        public List<AnnoucementModel> AnnoucementList { get; set; }
        public List<PartyModel> PartyList { get; set; }
        public List<ElectionModel> ElectionTypeList { get; set; }
        public List<zoneModel> ZoneList { get; set; }
        public List<areamodel> AreaList { get; set; }
        public List<ElectionDetailsModel> ElectionDetailsList { get; set; }
        public List<ElectionAssignmentModel> AssignElectionDetailsList { get; set; }
        public List<VoterModel> VoterList { get; set; }
        public List<CandidateModel> CandidateList { get; set; }
        public List<AdminModel> AdminList { get; set; }





        // Extra Feauture
        public int TotalPage { get; set; }
        public List<Options> genders { get; set; }
        public List<Options> AppointmentSubject { get; set; }
        public List<Options> ElectionStatus { get; set; }
    }
}
