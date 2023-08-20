using Evoting.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Evoting.Utility;


namespace Evoting.DataLayerSQL
{
   public class ElectionSettingsSQLProvider: IElectionSettingsDataLayerProvider
    {
        // Election Type
        public bool AddNewElectionType(ElectionModel electiontype)
        {
            bool Isadded=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("ElectionTypes", electiontype).Result;
               // Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool DeleteElectionType(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.DeleteAsync("ElectionTypes/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public List<ElectionModel> GetAllElectionType()
        {
            List<ElectionModel> electiontype = new List<ElectionModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("ElectionTypes").Result;
                // electiontype = (List<ElectionModel>)responseSingle.Content.ReadAsAsync<IEnumerable<List<ElectionModel>>>().Result;
                electiontype = (List<ElectionModel>)responseSingle.Content.ReadAsAsync<IEnumerable<ElectionModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return electiontype;
        }

        // Zone
        public bool AddNewZone(zoneModel zone)
        {
            bool Isadded=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("Zones", zone).Result;
                //Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool DeleteZone(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.DeleteAsync("Zones/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public List<zoneModel> GetAllZone()
        {
            List<zoneModel> electiontype = new List<zoneModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("Zones").Result;
                electiontype = (List<zoneModel>)responseSingle.Content.ReadAsAsync<IEnumerable<zoneModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return electiontype;
        }

        //Area
        public bool AddNewArea(areamodel Area)
        {
            bool Isadded=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("Areas", Area).Result;
                //Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool DeleteArea(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.DeleteAsync("Areas/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);    
            }
            return IsDeleted;
        }
        public List<areamodel> GetAllArea()
        {
            List<areamodel> AllArea = new List<areamodel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("Areas").Result;
                AllArea = (List<areamodel>)responseSingle.Content.ReadAsAsync<IEnumerable<areamodel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllArea;
        }
    }
}
