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

namespace Evoting.DataLayerSQL
{
    public class PartySQLProvider: IPartyDataLayerProvider
    {
        public bool AddNewParty(PartyModel party)
        {
            bool Isadded=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Parties", party).Result;
            }
            catch (Exception ex)
            {
                Isadded = false;
                throw new Exception("Exception Adding Data. " + ex.Message);
            }
            return Isadded;
        }
        public bool UpdateParty(PartyModel party)
        {
            bool IsUpdated=true;
            try
            {
                HttpResponseMessage responseADD = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Parties/"+ party.PartyID.ToString(), party).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception("Exception Updating Data. " + ex.Message);
                
            }
            return IsUpdated;
        }
        public PartyModel GetSingleParty(int id)
        {
            PartyModel party = new PartyModel();
            try
            {
                HttpResponseMessage responseSingle= GlobalSettingsWebAPI.WebApiClient.GetAsync("Parties/" + id.ToString()).Result;
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
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Parties/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return IsDeleted;
        }
        public List<PartyModel> GetAllParty()
        {
            List<PartyModel> party = new List<PartyModel>();
            try
            {
                HttpResponseMessage responseSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Parties").Result;
                party = (List<PartyModel>)responseSingle.Content.ReadAsAsync<IEnumerable<PartyModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Getting Single Data." + ex.Message);
            }
            return party;
        }
    }
}
