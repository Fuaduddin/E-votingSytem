using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class AdminModel
    {
        public int AdminID { get; set; }
        public string AdminProfilePIc { get; set; }
        public string AdminName { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string AdminEmail { get; set; }
        public int AdminZone { get; set; }
        public int AdminArea { get; set; }
        public string AdminAddressPresent { get; set; }
        public string AdminAddressPermanent { get; set; }
        public int UserID { get; set; }
        public string AdminGender { get; set; }

        public areamodel Area { get; set; }
        public UserModel User { get; set; }
        public zoneModel Zone { get; set; }
    }
}
