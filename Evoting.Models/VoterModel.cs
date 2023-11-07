using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class VoterModel
    {
        public int VoterID { get; set; }
        public string VoterImage { get; set; }
        public string VoterName { get; set; }
        public string VoterPhoneNumber { get; set; }
        public string VoterEmail { get; set; }
        public int VoterZone { get; set; }
        public int VoterArea { get; set; }
        public string VoterPresentAddress { get; set; }
        public string VoterPermanentAddress { get; set; }
        public string VoterNID { get; set; }
        public int UserID { get; set; }
        public string VoterGender { get; set; }
        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
        // public virtual ICollection<Vote> Votes { get; set; }

    }
}
