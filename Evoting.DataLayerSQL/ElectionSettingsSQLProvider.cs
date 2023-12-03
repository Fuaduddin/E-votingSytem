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
using Evoting.GlobalSetting;
using static System.Collections.Specialized.BitVector32;


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
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("ElectionTypes", electiontype).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("ElectionTypes/" + id.ToString()).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("ElectionTypes").Result;
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
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Zones", zone).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Zones/" + id.ToString()).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Zones").Result;
                electiontype = (List<zoneModel>)responseSingle.Content.ReadAsAsync<IEnumerable<zoneModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return electiontype;
        }
        public zoneModel GetSingleZone(int id)
        {
            zoneModel zone = new zoneModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Zones/" + id.ToString()).Result;
                zone = (zoneModel)responseSingle.Content.ReadAsAsync<zoneModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return zone;
        }
        //Area
        public bool AddNewArea(areamodel Area)
        {
            bool Isadded=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Areas", Area).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Areas/" + id.ToString()).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Areas").Result;
                AllArea = (List<areamodel>)responseSingle.Content.ReadAsAsync<IEnumerable<areamodel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllArea;
        }
        public areamodel GetSIngleArea(int id)
        {
            areamodel AllArea = new areamodel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Areas/"+id.ToString()).Result;
                AllArea = (areamodel)responseSingle.Content.ReadAsAsync<areamodel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllArea;
        }
        public bool UpdateArea(areamodel area)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Areas/" + area.AreaID.ToString(),area).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsUpdated;
        }

        // ElectionDetails
        public bool AddNewElectionDetails(ElectionDetailsModel electiondetails)
        {
            bool Isadded = true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Election_Detail", electiondetails).Result;
                
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool DeleteElectionDetails(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Election_Detail/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public List<ElectionDetailsModel> GetAllElectionDetails()
        {
            List<ElectionDetailsModel> elections = new List<ElectionDetailsModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Election_Detail").Result;
                elections = (List<ElectionDetailsModel>)responseSingle.Content.ReadAsAsync<IEnumerable<ElectionDetailsModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return elections;
        }
        public ElectionDetailsModel GetSIngleElectionDetails(int id)
        {
            ElectionDetailsModel election = new ElectionDetailsModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Election_Detail/" + id.ToString()).Result;
                election = (ElectionDetailsModel)responseSingle.Content.ReadAsAsync<ElectionDetailsModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return election;
        }
        public bool UpdateElectionDetails(ElectionDetailsModel electiondetails)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Election_Detail/" + electiondetails.ElectionID.ToString(), electiondetails).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsUpdated;
        }

        // Assignment Election Details
        public bool AddNewAssingmentElectionDetails(ElectionAssignmentModel AssingmentElectionDetails)
        {
            bool isAdded = true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("ElectionAssignments", AssingmentElectionDetails).Result;
            }
            catch (Exception ex)
            {
                isAdded = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return isAdded;
        }
        public List<ElectionDetailsModel> GetAllAssingElectionDetails()
        {
            List<ElectionDetailsModel> AllAssingElectionDetails = new List<ElectionDetailsModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("ElectionAssignments").Result;
                AllAssingElectionDetails = (List<ElectionDetailsModel>)responseSingle.Content.ReadAsAsync<IEnumerable<ElectionDetailsModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return AllAssingElectionDetails;
        }
        public bool DeleteAssingElectionDetails(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("ElectionAssignments/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public ElectionAssignmentModel GetSIngleAssingElectionDetails(int id)
        {
            ElectionAssignmentModel election = new ElectionAssignmentModel();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("ElectionAssignments/" + id.ToString()).Result;
                election = (ElectionAssignmentModel)responseSingle.Content.ReadAsAsync<ElectionAssignmentModel>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return election;
        }
    }
}
