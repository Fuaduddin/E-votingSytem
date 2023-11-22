using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class VoterCandidateViewModel
    {

        // Extra Feauture
        public int TotalPage { get; set; }
        public List<Options> genders { get; set; }
        public List<Options> AppointmentSubject { get; set; }
        public List<Options> ElectionStatus { get; set; }
    }
}
