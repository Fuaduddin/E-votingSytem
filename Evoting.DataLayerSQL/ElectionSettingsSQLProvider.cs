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
            bool Isadded;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("ElectionTypes", electiontype).Result;
                Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Adding Data. " + ex.Message);
                Isadded = false;
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
                throw new Exception("Exception Getting Single Data." + ex.Message);
                IsDeleted = false;
            }
            return IsDeleted;
        }
        public List<ElectionModel> GetAllElectionType()
        {
            List<ElectionModel> electiontype = new List<ElectionModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("ElectionTypes").Result;
                electiontype = (List<ElectionModel>)responseSingle.Content.ReadAsAsync<IEnumerable<List<ElectionModel>>>().Result;
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
            bool Isadded;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("Zones", zone).Result;
                Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Adding Data. " + ex.Message);
                Isadded = false;
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
                throw new Exception("Exception Getting Single Data." + ex.Message);
                IsDeleted = false;
            }
            return IsDeleted;
        }
        public List<zoneModel> GetAllZone()
        {
            List<zoneModel> electiontype = new List<zoneModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("Zones").Result;
                electiontype = (List<zoneModel>)responseSingle.Content.ReadAsAsync<IEnumerable<List<zoneModel>>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return electiontype;
        }
    }
}
