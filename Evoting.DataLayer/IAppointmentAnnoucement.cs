using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
    public interface IAppointmentAnnoucement
    {
        // Appointments
        bool AddNewAppointment(AppointmentAnnoucementModel appointment);
        bool DeleteAppointment(int id);
        List<AppointmentAnnoucementModel> GetAllAppointment();
        AppointmentAnnoucementModel GetSIngleAppointment(int id);
        bool UpdateAppointment(AppointmentAnnoucementModel appointment);

        // Annoucement
        bool AddNewAnnoucement(AnnoucementModel annoucement);
        bool UpdateAnnoucement(AnnoucementModel annoucement);
        List<AnnoucementModel> GetAllAnnoucement();
        AnnoucementModel GetSingleAnnoucement(int id);
        bool DeleteAnnoucement(int id);


        // Assign Appointment
        bool AddNewAssignmentAppointment(AssignmentAppointment AssingAppointment);
        bool UpdateAssignmentAppointment(AssignmentAppointment AssingAppointment);
        List<AssignmentAppointment> GetAllAssignmentAppointment();
        AssignmentAppointment GetSingleAssignmentAppointment(int id);
        bool DeleteAssignmentAppointment(int id);

    }
}
