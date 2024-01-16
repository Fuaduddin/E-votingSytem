using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class VoterModel
    {
        [Key]
        public int VoterID { get; set; }
        public string VoterImage { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string VoterName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Phone Number")]
        public string VoterPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Email")]
        public string VoterEmail { get; set; }
        [Required(ErrorMessage = "Please Select Zone")]
        public int VoterZone { get; set; }
        [Required(ErrorMessage = "Please Select Area")]
        public int VoterArea { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string VoterPresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string VoterPermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter NID")]
        public string VoterNID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string VoterGender { get; set; }

        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
        // public virtual ICollection<Vote> Votes { get; set; }

    }
}
