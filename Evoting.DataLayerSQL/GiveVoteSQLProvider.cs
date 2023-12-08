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
    public class GiveVoteSQLProvider
    {
        public List<CandidateModel> GetZoneAreaCandidate(int ElectionID,int ZoneID,int AreaID) 
        {
            List<CandidateModel> CandidateList= new List<CandidateModel>();
            try
            {
                HttpResponseMessage ResponseList = GlobalSettingsWebAPI.WebApiClient.GetAsync("CustomeAPI/"+ ElectionID.ToString()+"/"+ ZoneID.ToString()+"/"+ AreaID.ToString()).Result;
                CandidateList= ResponseList.Content.ReadAsAsync<List<CandidateModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return CandidateList; 
        }

        public int GiveVote(GiveVoteModel Vote)
        {
            int id = 0;
            try
            {
                HttpResponseMessage ResponseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Votes", Vote).Result;
                id=ResponseADD.Content.ReadAsAsync<int>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return id;
        }
        public List<GiveVoteModel> GiveVoteList()
        {
            List<GiveVoteModel> VoteList= new List<GiveVoteModel>();
            try
            {
                HttpResponseMessage ResposnseList = GlobalSettingsWebAPI.WebApiClient.GetAsync("Votes").Result;
                VoteList = (List<GiveVoteModel>)ResposnseList.Content.ReadAsAsync<IEnumerable<GiveVoteModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return VoteList;
        }
    }
}
