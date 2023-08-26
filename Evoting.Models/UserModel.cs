using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class UserModel
    {
        public int UserIDNo { get; set; }
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserLastLogin { get; set; }
        public int UserTotalLogin { get; set; }
        public DateTime UserLastLogout { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
    }
}
