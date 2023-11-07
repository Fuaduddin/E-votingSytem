using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class ElectionAssignmnetsController : ApiController
    {
        private Entities6 db = new Entities6();

        //// GET: api/ElectionAssignmnets
        //public IQueryable<ElectionAssignmnet> GetElectionAssignmnets()
        //{
        //    return db.ElectionAssignmnets;
        //}

        //// GET: api/ElectionAssignmnets/5
        //[ResponseType(typeof(ElectionAssignmnet))]
        //public async Task<IHttpActionResult> GetElectionAssignmnet(int id)
        //{
        //    ElectionAssignmnet electionAssignmnet = await db.ElectionAssignmnets.FindAsync(id);
        //    if (electionAssignmnet == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(electionAssignmnet);
        //}

        // PUT: api/ElectionAssignmnets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElectionAssignmnet(int id, ElectionAssignmnet electionAssignmnet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != electionAssignmnet.AssignmentElection)
            {
                return BadRequest();
            }

            db.Entry(electionAssignmnet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionAssignmnetExists(id))
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

        // POST: api/ElectionAssignmnets
        [ResponseType(typeof(ElectionAssignmnet))]
        public async Task<IHttpActionResult> PostElectionAssignmnet(ElectionAssignmnet electionAssignmnet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElectionAssignmnets.Add(electionAssignmnet);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = electionAssignmnet.AssignmentElection }, electionAssignmnet);
        }

        // DELETE: api/ElectionAssignmnets/5
        [ResponseType(typeof(ElectionAssignmnet))]
        public async Task<IHttpActionResult> DeleteElectionAssignmnet(int id)
        {
            ElectionAssignmnet electionAssignmnet = await db.ElectionAssignmnets.FindAsync(id);
            if (electionAssignmnet == null)
            {
                return NotFound();
            }

            db.ElectionAssignmnets.Remove(electionAssignmnet);
            await db.SaveChangesAsync();

            return Ok(electionAssignmnet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElectionAssignmnetExists(int id)
        {
            return db.ElectionAssignmnets.Count(e => e.AssignmentElection == id) > 0;
        }

        // Custome API Controller

        // GET: api/ElectionAssignmnets
        public List<ElectionAssignment> GetElectionAssignmnets()
        {    
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection= db.ElectionAssignmnets;
            var Zones = db.Zones;
            var Areas=db.Areas;
            var AssingmentElectionList = (from assingmentelectiondetails in Assingelection
                                          join electiondetails in ElectionDetails on assingmentelectiondetails.ElectionID
                                          equals electiondetails.ElectionID
                                          join Zonesdetails in Zones on assingmentelectiondetails.ZoneID
                                          equals Zonesdetails.ZoneId
                                          join Areasdetails in Areas on assingmentelectiondetails.AreaID
                                          equals Areasdetails.AreaID
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                          select new ElectionAssignment
                                          {
                                              ElectionID = electiondetails.ElectionID,
                                              ZoneID = Zonesdetails.ZoneId,
                                              AreaID = Areasdetails.AreaID,
                                              ZoneName = Zonesdetails.ZoneName,
                                              AreaTitle = Areasdetails.AreaTitle,
                                              AreaName = Areasdetails.AreaName,
                                              ElectionDetails = new ElectionDetailsModel
                                              {
                                                  ElectionID = electiondetails.ElectionID,
                                                  ElectionName = electiondetails.ElectionName,
                                                  ElectionDetails = electiondetails.ElectionDetails,
                                                  ElectionStatus = electiondetails.ElectionStatus,
                                                  ElectionType = electiondetails.ElectionType,
                                                  StartDate = electiondetails.StartDate,
                                                  EndDate = electiondetails.EndDate,
                                                  ElectionTypeDetails = new ElectionModel
                                                  {
                                                      ElectionID = electiondetailstype.ElectionID,
                                                      ElectionName = electiondetailstype.ElectionName
                                                  }
                                              }
                                          }).ToList();
            return AssingmentElectionList;
        }

        // GET: api/ElectionAssignmnets/5
        [ResponseType(typeof(ElectionAssignmnet))]
        public ElectionAssignment GetElectionAssignmnet(int id)
        {
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection = db.ElectionAssignmnets;
            var Zones = db.Zones;
            var Areas = db.Areas;
            var AssingmentElectionList = (from assingmentelectiondetails in Assingelection
                                          join electiondetails in ElectionDetails on assingmentelectiondetails.ElectionID
                                          equals electiondetails.ElectionID
                                          join Zonesdetails in Zones on assingmentelectiondetails.ZoneID
                                          equals Zonesdetails.ZoneId
                                          join Areasdetails in Areas on assingmentelectiondetails.AreaID
                                          equals Areasdetails.AreaID
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                          select new ElectionAssignment
                                          {
                                              ElectionID = electiondetails.ElectionID,
                                              ZoneID = Zonesdetails.ZoneId,
                                              AreaID = Areasdetails.AreaID,
                                              ZoneName = Zonesdetails.ZoneName,
                                              AreaTitle = Areasdetails.AreaTitle,
                                              AreaName = Areasdetails.AreaName,
                                              ElectionDetails = new ElectionDetailsModel()
                                              {
                                                  ElectionID = electiondetails.ElectionID,
                                                  ElectionName = electiondetails.ElectionName,
                                                  ElectionDetails = electiondetails.ElectionDetails,
                                                  ElectionStatus = electiondetails.ElectionStatus,
                                                  ElectionType = electiondetails.ElectionType,
                                                  StartDate = electiondetails.StartDate,
                                                  EndDate = electiondetails.EndDate,
                                                  ElectionTypeDetails = new ElectionModel()
                                                  {
                                                      ElectionID = electiondetailstype.ElectionID,
                                                      ElectionName = electiondetailstype.ElectionName
                                                  }
                                              }
                                          }).FirstOrDefault();
            return AssingmentElectionList;
        }
    }
}