using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class AppointmentAnnoucementModel
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required(ErrorMessage = "Please Select Appointment Subject")]
        public string AppointmentSubject { get; set; }
        [Required(ErrorMessage = "Please Enter Appointment Details")]
        public string AppointmentDetails { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Phone Number")]
        public string UserPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("", ErrorMessage = "Please Enter Valid Email")]
        public string UserEmaul { get; set; }
        public int AssignToAdmin { get; set; }
        public int AssignmentUpdate { get; set; }

        //public virtual ICollection<AdminAssignment> AdminAssignments { get; set; }
    }

    public class AnnoucementModel
    {
        [Key]
        public int AnnoucemntID { get; set; }
        [Required(ErrorMessage = "Please Select Annoucement Title")]
        public string AnnoucementTitle { get; set; }
        [Required(ErrorMessage = "Please Enter Anoucement Details")]
        public string AnoucementDetails { get; set; }
        public string AnnoucementImage { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class AssignmentAppointment
    {
        [Key]
        public int AssignmentID { get; set; }
        [Required(ErrorMessage = "Please Select Admin")]
        public int AdminID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime AssignmentIssueDate { get; set; }
        [Required(ErrorMessage = "Please Select a Fixed Date")]
        public DateTime? AssignmentFixedDate { get; set; }
        public int AssignmentUpdate { get; set; }

        public  AdminModel Admin { get; set; }
        public AppointmentAnnoucementModel Appointment { get; set; }
    }
}


