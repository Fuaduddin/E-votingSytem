using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminProfilePIc { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string AdminPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
       
        public string AdminEmail { get; set; }
        [Required(ErrorMessage = "Please Select Zone")]
        public int AdminZone { get; set; }
        [Required(ErrorMessage = "Please Select Area")]
        public int AdminArea { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string AdminAddressPresent { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string AdminAddressPermanent { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string AdminGender { get; set; }

        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
    }
}
