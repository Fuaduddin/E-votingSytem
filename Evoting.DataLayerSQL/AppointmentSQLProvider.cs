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
    public class AppointmentSQLProvider
    {
        public bool AddNewAppointment(AppointmentModel appointment)
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
        public List<AppointmentModel> GetAllAppointment()
        {
            List<AppointmentModel> AllAppointment = new List<AppointmentModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Appointments").Result;
                AllAppointment = (List<AppointmentModel>)responseSingle.Content.ReadAsAsync<IEnumerable<AppointmentModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllAppointment;
        }
        public AppointmentModel GetSIngleAppointment(int id)
        {
            AppointmentModel AllAppointment = new AppointmentModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Appointments/" + id.ToString()).Result;
                AllAppointment = (AppointmentModel)responseSingle.Content.ReadAsAsync<AppointmentModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllAppointment;
        }
        //public bool UpdateArea(areamodel area)
        //{
        //    bool IsUpdated = true;
        //    try
        //    {
        //        HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Areas/" + area.AreaID.ToString(), area).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        IsUpdated = false;
        //        throw new Exception("Exception Getting Single Data." + ex.Message);
        //    }
        //    return IsUpdated;
        //}
    }
}
