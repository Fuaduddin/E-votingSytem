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
    public class PartySQLProvider: PartyDataLayerProvider
    {
        public bool AddNewParty(PartyModel party)
        {
            bool Isadded;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PostAsJsonAsync("Parties", party).Result;
                Isadded = responseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Adding Data. " + ex.Message);
                Isadded = false;
            }
            return Isadded;
        }
        public bool UpdateParty(PartyModel party)
        {
            bool IsUpdated=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettings.WebApiClient.PutAsJsonAsync("Parties/"+ party.PartyID.ToString(), party).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Updating Data. " + ex.Message);
                IsUpdated = false;
            }
            return IsUpdated;
        }
        public PartyModel GetSingleParty(int id)
        {
            PartyModel party = new PartyModel();
            try
            {
                HttpResponseMessage responseSingle=GlobalSettings.WebApiClient.GetAsync("Parties/" + id.ToString()).Result;
                party = (PartyModel)responseSingle.Content.ReadAsAsync<IEnumerable<PartyModel>>().Result;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return party;
        }
        public bool DeleteParty(int id)
        {
            bool IsDeleted = true;
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.DeleteAsync("Parties/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
                IsDeleted = false;
            }
            return IsDeleted;
        }
        public List<PartyModel> GetAllParty()
        {
            List<PartyModel> party = new List<PartyModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettings.WebApiClient.GetAsync("Parties").Result;
                party = (List<PartyModel>)responseSingle.Content.ReadAsAsync<IEnumerable<List<PartyModel>>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return party;
        }
    }
}
