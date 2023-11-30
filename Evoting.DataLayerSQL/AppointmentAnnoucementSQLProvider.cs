using Evoting.Models;
using Evoting.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayerSQL
{
    public class AppointmentAnnoucementSQLProvider
    {
        public bool AddNewAppointment(AppointmentAnnoucementModel appointment)
        {
            bool Isadded = true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Appointments", appointment).Result;
                //Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool DeleteAppointment(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Appointments/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public List<AppointmentAnnoucementModel> GetAllAppointment()
        {
            List<AppointmentAnnoucementModel> AllAppointment = new List<AppointmentAnnoucementModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Appointments").Result;
                AllAppointment = (List<AppointmentAnnoucementModel>)responseSingle.Content.ReadAsAsync<IEnumerable<AppointmentAnnoucementModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllAppointment;
        }
        public AppointmentAnnoucementModel GetSIngleAppointment(int id)
        {
            AppointmentAnnoucementModel AllAppointment = new AppointmentAnnoucementModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Appointments/" + id.ToString()).Result;
                AllAppointment = (AppointmentAnnoucementModel)responseSingle.Content.ReadAsAsync<AppointmentAnnoucementModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllAppointment;
        }
        public bool UpdateAppointment(AppointmentAnnoucementModel appointment)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Appointments/" + appointment.AppointmentID.ToString(), appointment).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsUpdated;
        }

        // Annoucement
        public bool AddNewAnnoucement(AnnoucementModel annoucement)
        {
            bool Isadded = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Announcements", annoucement).Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return Isadded;
        }
        public bool UpdateAnnoucement(AnnoucementModel annoucement)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Announcements/" + annoucement.AnnoucemntID.ToString(), annoucement).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsUpdated;
        }
        public List<AnnoucementModel> GetAllAnnoucement()
        {
            List<AnnoucementModel> annoucementModelsList = new List<AnnoucementModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Announcements").Result;
                annoucementModelsList = (List<AnnoucementModel>)responseSingle.Content.ReadAsAsync<IEnumerable<AnnoucementModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return annoucementModelsList;
        }
        public AnnoucementModel GetSingleAnnoucement(int id)
        {
            AnnoucementModel annoucement = new AnnoucementModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Announcements/" + id.ToString()).Result;
                annoucement = (AnnoucementModel)responseSingle.Content.ReadAsAsync<AnnoucementModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return annoucement;
        }
        public bool DeleteAnnoucement(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Announcements/"+id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }

        // Assign Appointment
        public bool AddNewAssignmentAppointment(AssignmentAppointment AssingAppointment)
        {
            bool Isadded = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("AdminAssignments", AssingAppointment).Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return Isadded;
        }
        public bool UpdateAssignmentAppointment(AssignmentAppointment AssingAppointment)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("AdminAssignments/" + AssingAppointment.AssignmentID.ToString(), AssingAppointment).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsUpdated;
        }
        public List<AssignmentAppointment> GetAllAssignmentAppointment()
        {
            List<AssignmentAppointment> AssignmentAppointList = new List<AssignmentAppointment>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("AdminAssignments").Result;
                AssignmentAppointList = (List<AssignmentAppointment>)responseSingle.Content.ReadAsAsync<IEnumerable<AssignmentAppointment>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AssignmentAppointList;
        }
        public AssignmentAppointment GetSingleAssignmentAppointment(int id)
        {
            AssignmentAppointment annoucement = new AssignmentAppointment();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("AdminAssignments/" + id.ToString()).Result;
                annoucement = (AssignmentAppointment)responseSingle.Content.ReadAsAsync<AssignmentAppointment>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return annoucement;
        }
        public bool DeleteAssignmentAppointment(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("AdminAssignments/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
    }
}

