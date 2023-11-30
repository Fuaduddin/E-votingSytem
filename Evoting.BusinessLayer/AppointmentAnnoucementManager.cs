using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
    public class AppointmentAnnoucementManager
    {
        public static bool AddNewAppointment(AppointmentAnnoucementModel appointment)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            bool IsAdded = provider.AddNewAppointment(appointment);
            return IsAdded;
        }
        public static bool DeleteAppointment(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            bool IsDeleted = provider.DeleteAppointment(id);
            return IsDeleted;
        }
        public static List<AppointmentAnnoucementModel> GetAllAppointment()
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var area = provider.GetAllAppointment();
            return area;
        }
        public static AppointmentAnnoucementModel GetSingleAppointment(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var area = provider.GetSIngleAppointment(id);
            return area;
        }
        public static bool UpdateAppointment(AppointmentAnnoucementModel appointment)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var area = provider.UpdateAppointment(appointment);
            return area;
        }

        // Annoucement Start

        public static bool AddNewAnnoucement(AnnoucementModel AnnoucementDetails)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.AddNewAnnoucement(AnnoucementDetails);
            return Annoucement;
        }
        public static bool UpdateAnnoucement(AnnoucementModel AnnoucementDetails)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.UpdateAnnoucement(AnnoucementDetails);
            return Annoucement;
        }
        public static List<AnnoucementModel> GetAllAnnoucement()
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.GetAllAnnoucement();
            return Annoucement;
        }
        public static AnnoucementModel GetSingleAnnoucement(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.GetSingleAnnoucement(id);
            return Annoucement;
        }
        public static bool DeleteAnnoucement(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.DeleteAnnoucement(id);
            return Annoucement;
        }

        // Assignment Appointment Start

        public static bool AddNewAssignmentAppointment(AssignmentAppointment AssingAppointment)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.AddNewAssignmentAppointment(AssingAppointment);
            return Annoucement;
        }
        public static bool UpdateAssignmentAppointment(AssignmentAppointment AssingAppointment)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.UpdateAssignmentAppointment(AssingAppointment);
            return Annoucement;
        }
        public static List<AssignmentAppointment> GetAllAssignmentAppointment()
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.GetAllAssignmentAppointment();
            return Annoucement;
        }
        public static AssignmentAppointment GetSingleAssignmentAppointment(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.GetSingleAssignmentAppointment(id);
            return Annoucement;
        }
        public static bool DeleteAssignmentAppointment(int id)
        {
            AppointmentAnnoucementSQLProvider provider = new AppointmentAnnoucementSQLProvider();
            var Annoucement = provider.DeleteAssignmentAppointment(id);
            return Annoucement;
        }
    }
}
