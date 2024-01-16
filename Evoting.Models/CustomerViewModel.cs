using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;


namespace Evoting.Models
{
    public class CustomerViewModel
    {
        public AppointmentAnnoucementModel Appointment { get; set; }
        public UserModel UserDetails { get; set; }
        public AnnoucementModel Annoucement { get; set; }
        public CandidateModel Candidate { get; set; }


        // All List
        public List<AnnoucementModel> AnnoucementList { get; set; }
        public List<CandidateModel> CandidateList { get; set; }
        public List<ElectionDetailsModel> ElectionDetailsList { get; set; }


        // Extra Feautures
        public List<Options> genders { get; set; }
        public List<Options> AppointmentSubject { get; set; }
        public List<Options> ElectionStatus { get; set; }
    }
}
