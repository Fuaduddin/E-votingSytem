using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class UserModel
    {
        [Key]
        public int UserIDNo { get; set; }
        [Required(ErrorMessage = "Please Enter User ID")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }
        public DateTime UserLastLogin { get; set; }
        public int UserTotalLogin { get; set; }
        public DateTime UserLastLogout { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
    }
}
