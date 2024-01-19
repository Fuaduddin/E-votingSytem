using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class ResultsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Results
        public IQueryable<Result> GetResults()
        {
            return db.Results;
        }

        // PUT: api/Results/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResult(int id, Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != result.ResultID)
            {
                return BadRequest();
            }

            db.Entry(result).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Results
        [ResponseType(typeof(Result))]
        public async Task<IHttpActionResult> PostResult(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Results.Add(result);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = result.ResultID }, result);
        }

        // DELETE: api/Results/5
        [ResponseType(typeof(Result))]
        public async Task<IHttpActionResult> DeleteResult(int id)
        {
            Result result = await db.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            db.Results.Remove(result);
            await db.SaveChangesAsync();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultExists(int id)
        {
            return db.Results.Count(e => e.ResultID == id) > 0;
        }


        // Custome API Methods

        [ResponseType(typeof(Result))]
        [Route("api/Results/{ElectionID}")]
        public ElectionResultDetailsModel GetResult(int ElectionID)
        {
            ElectionResultDetailsModel ElectionResult = new ElectionResultDetailsModel();
            List<VotingResultModel> votingResults = new List<VotingResultModel>();
            if (ElectionID > 0)
            {
                ElectionResult.ElectionDetails = db.Election_Details.Where(x => x.ElectionID == ElectionID)
                                               .Select(x => new ElectionDetailsModel()
                                               {
                                                   ElectionID = x.ElectionID,
                                                   ElectionName = x.ElectionName,
                                                   ElectionDetails = x.ElectionDetails,
                                                   ElectionStatus = x.ElectionStatus,
                                               }).FirstOrDefault();
                var CentersList = db.ElectionAssignments.Where(x => x.ElectionID == ElectionID).ToList();
                if (CentersList.Count > 0)
                {
                    foreach (var center in CentersList)
                    {
                        VotingResultModel ResultDetails = new VotingResultModel();
                        ResultDetails.AreaDetails = db.Areas.Where(x => x.AreaID == center.AreaID).Select(x=> new areamodel()
                        {
                            AreaID= x.AreaID,
                            AreaName = x.AreaName,
                            AreaTitle = x.AreaTitle
                        }).FirstOrDefault();
                        ResultDetails.TotalGivenVote = db.Votes.Where(x => x.ElectionID == ElectionID && x.AssignmentElectionID == center.ElectionAssignID).Count();
                        ResultDetails.ElectionDetails = ElectionID;
                        ResultDetails.SelectedCandidate = db.Votes.Where(x => x.ElectionID == ElectionID && x.AssignmentElectionID == center.ElectionAssignID).Max(x => x.CandidateID);
                        ResultDetails.SelectedCandidateVote = db.Votes.Where(x => x.ElectionID == ElectionID && x.CandidateID == ResultDetails.SelectedCandidate && x.AssignmentElectionID == center.ElectionAssignID).Count();
                        ResultDetails.SelectedCandidateDetails = db.Candidates.Where(x => x.CandidateID == ResultDetails.SelectedCandidate)
                                             .Select(x =>
                                             new CandidateModel()
                                             {
                                                 CandidateID = x.CandidateID,
                                                 CandidateName = x.CandidateName,
                                                 CandidateArea = x.CandidateArea,
                                                 CandidateEmail = x.CandidateEmail,
                                                 CandidateGender = x.CandidateGender,
                                                 CandidateImage = x.CandidateImage,
                                                 CandidateNID = x.CandidateNID,
                                                 CandidateParty = x.CandidateParty,
                                                 CandidatePermanentAddress = x.CandidatePermanentAddress,
                                                 CandidatePhoneNumber = x.CandidatePhoneNumber,
                                                 CandidatePresentAddress = x.CandidatePresentAddress,
                                                 CandidateZone = x.CandidateZone,
                                             }).FirstOrDefault();
                        ResultDetails.RunnerUpCandidateVote = db.Votes.Where(x => x.ElectionID == ElectionID && x.CandidateID != ResultDetails.SelectedCandidate && x.AssignmentElectionID == center.ElectionAssignID).Max(x => x.CandidateID);
                        ResultDetails.RunnerUpCandidateDetails = db.Candidates.Where(x => x.CandidateID == ResultDetails.RunnerUpCandidateVote)
                                                 .Select(x =>
                                                 new CandidateModel()
                                                 {
                                                     CandidateID = x.CandidateID,
                                                     CandidateName = x.CandidateName,
                                                     CandidateArea = x.CandidateArea,
                                                     CandidateEmail = x.CandidateEmail,
                                                     CandidateGender = x.CandidateGender,
                                                     CandidateImage = x.CandidateImage,
                                                     CandidateNID = x.CandidateNID,
                                                     CandidateParty = x.CandidateParty,
                                                     CandidatePermanentAddress = x.CandidatePermanentAddress,
                                                     CandidatePhoneNumber = x.CandidatePhoneNumber,
                                                     CandidatePresentAddress = x.CandidatePresentAddress,
                                                     CandidateZone = x.CandidateZone,
                                                 }).FirstOrDefault();
                        ResultDetails.SelectedCandidateVote = db.Votes.Where(x => x.ElectionID == ElectionID && x.CandidateID == ResultDetails.RunnerUpCandidateVote && x.AssignmentElectionID == center.ElectionAssignID).Count();
                        votingResults.Add(ResultDetails);
                    }
                }
            }
            ElectionResult.ResultDetails= votingResults;
            return ElectionResult;
        }
       
        [ResponseType(typeof(Result))]
        [Route("api/Results")]
        public ElectionResultDetailsModel GetAllCandidateElectionResultDetails()
        {
            ElectionResultDetailsModel ElectionResult = new ElectionResultDetailsModel();
            List<SingleCandidateGivenVoteCount> AllCandidateResult= new List<SingleCandidateGivenVoteCount>();
            var ElectionDetails = db.Election_Details.Where(x => x.StartDate == DateTime.Now.Date).FirstOrDefault();
            if(ElectionDetails.ElectionID > 0)
            {
                var CenterList=db.ElectionAssignments.Where(x=>x.ElectionID==ElectionDetails.ElectionID).ToList();
                if(CenterList.Count > 0)
                {
                    foreach (var Ceneter in CenterList)
                    {
                        var CandidateList=db.ElectionCandidates.Where(x=>x.ZoneandArea == Ceneter.ElectionAssignID).ToList();
                        foreach(var Candidate in CandidateList)
                        {
                            var OtherCandidateVote = new SingleCandidateGivenVoteCount()
                            {
                                CandidateDetails = db.Candidates.Where(x => x.CandidateID == Candidate.CandidateID)
                                   .Select(x =>
                                   new CandidateModel()
                                   {
                                       CandidateID = x.CandidateID,
                                       CandidateName = x.CandidateName,
                                       CandidateGender = x.CandidateGender,
                                       CandidateImage = x.CandidateImage,
                                   }).FirstOrDefault(),
                                TotalVote = db.Votes.Where(x => x.ElectionID == ElectionDetails.ElectionID && x.AssignmentElectionID == Ceneter.ElectionAssignID && x.CandidateID == Candidate.CandidateID).Count()
                            };
                            AllCandidateResult.Add(OtherCandidateVote);
                        }
                    }
                }
            }
            return ElectionResult;
        }


    }
}