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
using System.Web.Security;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class ElectionAssignmentsController : ApiController
    {
        private Entities db = new Entities();

        //// GET: api/ElectionAssignments
        [Route("api/ElectionAssignments/{electionID}/{zoneID}/{areaID}")]
        [ResponseType(typeof(ElectionAssignment))]
        public int GetElectionAssignmentsList(int electionID,int zoneID, int areaID)
        {
            var electionassignmentlist= db.ElectionAssignments.Where(x=>x.ElectionID== electionID
                                                                     && x.ZoneID== zoneID
                                                                     && x.AreaID== areaID).FirstOrDefault();
            return electionassignmentlist.ElectionAssignID;
        }

        // PUT: api/ElectionAssignments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElectionAssignment(int id, ElectionAssignment ElectionAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ElectionAssignment.ElectionAssignID)
            {
                return BadRequest();
            }

            db.Entry(ElectionAssignment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionAssignmentExists(id))
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

        // DELETE: api/ElectionAssignments/5
        [ResponseType(typeof(ElectionAssignment))]
        public async Task<IHttpActionResult> DeleteElectionAssignment(int id)
        {
            ElectionAssignment ElectionAssignment = await db.ElectionAssignments.FindAsync(id);
            if (ElectionAssignment == null)
            {
                return NotFound();
            }

            db.ElectionAssignments.Remove(ElectionAssignment);
            await db.SaveChangesAsync();

            return Ok(ElectionAssignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElectionAssignmentExists(int id)
        {
            return db.ElectionAssignments.Count(e => e.ElectionAssignID == id) > 0;
        }

        // Custome API Controller
        [ResponseType(typeof(ElectionAssignment))]
        public int PostElectionAssignment(ElectionAssignmentModel ElectionAssignment)
        {
            var AssignmentElectionID = new ElectionAssignment()
            {
                ElectionID=ElectionAssignment.ElectionID,
                ZoneID=ElectionAssignment.ZoneID,
                AreaID=ElectionAssignment.AreaID
            };
            db.ElectionAssignments.Add(AssignmentElectionID);
            db.SaveChanges();
            return AssignmentElectionID.ElectionAssignID;
        }
        // GET: api/ElectionAssignments
        public List<ElectionDetailsModel> GetElectionAssignments()
        {    
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection= db.ElectionAssignments;
            var ZonesDetailsList = db.Zones;
            var AssingmentElectionList = (from electiondetails in ElectionDetails
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where electiondetails.ElectionType == electiondetailstype.ElectionID
                                          select new ElectionDetailsModel
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
                                              },
                                              ZoneList = (from assingmentelectiondetails in Assingelection
                                                          join ZonesDetails in ZonesDetailsList on assingmentelectiondetails.ZoneID
                                                          equals ZonesDetails.ZoneId where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                                          select new zoneModel
                                                          {
                                                              ZoneId = ZonesDetails.ZoneId,
                                                              ZoneName = ZonesDetails.ZoneName
                                                          }).ToList()
                                          }).ToList();

            return AssingmentElectionList;
        }
        public ElectionDetailsModel GetElectionAssignment(int id)
        {
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection = db.ElectionAssignments;
            var ZonesDetailsList = db.Zones;
            var AssingmentElectionList = (from electiondetails in ElectionDetails
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where electiondetails.ElectionType == electiondetailstype.ElectionID
                                          select new ElectionDetailsModel
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
                                              },
                                              ZoneList = (from assingmentelectiondetails in Assingelection
                                                          join ZonesDetails in ZonesDetailsList on assingmentelectiondetails.ZoneID
                                                          equals ZonesDetails.ZoneId
                                                          where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                                          select new zoneModel
                                                          {
                                                              ZoneId = ZonesDetails.ZoneId,
                                                              ZoneName = ZonesDetails.ZoneName
                                                          }).ToList()
                                          }).FirstOrDefault();

            return AssingmentElectionList;
        }
    }
}