using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public string AppointmentSubject { get; set; }
        public string AppointmentDetails { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmaul { get; set; }
        public int AssignToAdmin { get; set; }
        public int AssignmentUpdate { get; set; }
        
        //public virtual ICollection<AdminAssignment> AdminAssignments { get; set; }
    }
}
