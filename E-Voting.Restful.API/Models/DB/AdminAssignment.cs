//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Voting.Restful.API.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminAssignment
    {
        public int AssignmentID { get; set; }
        public int AdminID { get; set; }
        public int AppointmentID { get; set; }
        public System.DateTime AssignmentIssueDate { get; set; }
        public Nullable<System.DateTime> AssignmentFixedDate { get; set; }
        public int AssignmentUpdate { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
