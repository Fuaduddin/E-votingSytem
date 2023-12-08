using E_Voting.Restful.API.Models.DB;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Voting.Restful.API.Controllers
{
    public class CustomeAPIController : ApiController
    {
        private static readonly Entities db = new Entities();
        // GET api/values
        [Route("api/CustomeAPI/{ElectionID}/{ZoneID}/{AreaID}")]
        public List<CandidateModel> GetZoneAreaWiseCandidate(int ElectionID, int ZoneID, int AreaID)
        {
            var electionassignmentlist = db.ElectionAssignments.Where(x => x.ElectionID == ElectionID && x.ZoneID == ZoneID
                                                                     && x.AreaID == AreaID).FirstOrDefault();
            var Candidates = db.Candidates;
            var AssignCandidates = db.ElectionCandidates;
            var Partylist = db.Parties;
            var CandidateList=(from candidate in Candidates join assignemts in AssignCandidates 
                               on candidate.CandidateID equals assignemts.CandidateID
                               where assignemts.ZoneandArea == electionassignmentlist.ElectionAssignID
                               select new CandidateModel
                               {
                                   CandidateID=candidate.CandidateID,
                                   CandidateName=candidate.CandidateName,
                                   AssignmentCandidate= new AssignmentCandidateModel()
                                   {
                                       CandidateID=candidate.CandidateID,
                                       ElectionCandidateID=assignemts.ElectionCandidateID,
                                       ElectionID = assignemts.ElectionID,
                                       ElectionComplete = assignemts.ElectionComplete,
                                       CandidateSymbol = assignemts.CandidateSymbol
                                   }                      
                               }).ToList();
            return CandidateList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
