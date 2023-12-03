using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class AppointmentAnnoucementModel
    {
        public int AppointmentID { get; set; }
        public string AppointmentSubject { get; set; }
        public string AppointmentDetails { get; set; }
        public string CustomerName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmaul { get; set; }
        public int AssignToAdmin { get; set; }
        public int AssignmentUpdate { get; set; }
        //public virtual ICollection<AdminAssignment> AdminAssignments { get; set; }
    }

    public class AnnoucementModel
    {
        public int AnnoucemntID { get; set; }
        public string AnnoucementTitle { get; set; }
        public string AnoucementDetails { get; set; }
        public string AnnoucementImage { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class AssignmentAppointment
    {
        public int AssignmentID { get; set; }
        public int AdminID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime AssignmentIssueDate { get; set; }
        public DateTime? AssignmentFixedDate { get; set; }
        public int AssignmentUpdate { get; set; }
        public  AdminModel Admin { get; set; }
        public AppointmentAnnoucementModel Appointment { get; set; }
    }
}


