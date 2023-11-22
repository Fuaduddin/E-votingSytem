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
        public List<ElectionAssignmentModel> GetElectionAssignmnets()
        {    
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection= db.ElectionAssignmnets;
            var AssingmentElectionList = (from assingmentelectiondetails in Assingelection
                                          join electiondetails in ElectionDetails on assingmentelectiondetails.ElectionID
                                          equals electiondetails.ElectionID
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                          select new ElectionAssignmentModel
                                          {
                                              AssignmentElection=assingmentelectiondetails.AssignmentElection,
                                              ElectionID = electiondetails.ElectionID,
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
                                              },
                                          }).ToList();
            foreach(var assingments in AssingmentElectionList)
            {
                assingments.AreaList = GetAreaDetails(assingments.AssignmentElection);
                assingments.ZoneList= GetZoneDetails(assingments.AssignmentElection);
            }
            return AssingmentElectionList;
        }
        private List<zoneModel> GetZoneDetails(int id)
        {
            var Zones = db.Zones;
            var Assingelection = db.ElectionAssignmnets;
            var AssignedZone = Assingelection.Where(x => x.ElectionID == id).ToList();
            var ZoneList = new List<zoneModel>();
            foreach (var ZoneDetailsitem in AssignedZone)
            {
                var Zone = Zones.Where(x => x.ZoneId == ZoneDetailsitem.ZoneID).FirstOrDefault();
                var ZoneDetails = new zoneModel
                {
                    ZoneId = Zone.ZoneId,
                    ZoneName = Zone.ZoneName
                };
                ZoneList.Add(ZoneDetails);
            }
            return ZoneList;
        }
        private List<areamodel> GetAreaDetails(int id)
        {
            var Areas = db.Areas;
            var Assingelection = db.ElectionAssignmnets;
            var AssignedArea = Assingelection.Where(x => x.ElectionID == id).ToList();
            var AreaList = new List<areamodel>();
            foreach (var AreasDetailsitem in AssignedArea)
            {
                var Area = Areas.Where(x => x.AreaID == AreasDetailsitem.AreaID).FirstOrDefault();
                var areaDetails = new areamodel
                {
                    AreaID = Area.AreaID,
                    AreaName= Area.AreaName,
                    AreaTitle= Area.AreaTitle,
                    ZoneID=Area.ZoneID
                };
                AreaList.Add(areaDetails);
            }
            return AreaList;
        }
        // GET: api/ElectionAssignmnets/5
        [ResponseType(typeof(ElectionAssignmnet))]
        public ElectionAssignmentModel GetElectionAssignmnet(int id)
        {
            var ElectionDetails = db.Election_Details;
            var ElectionTypeDetails = db.ElectionTypes;
            var Assingelection = db.ElectionAssignmnets;
            var Zones = db.Zones;
            var Areas = db.Areas;
            var AssingmentElectionList = (from assingmentelectiondetails in Assingelection
                                          join electiondetails in ElectionDetails on assingmentelectiondetails.ElectionID
                                          equals electiondetails.ElectionID
                                          join electiondetailstype in ElectionTypeDetails on electiondetails.ElectionType
                                          equals electiondetailstype.ElectionID
                                          where assingmentelectiondetails.ElectionID == electiondetails.ElectionID
                                          select new ElectionAssignmentModel
                                          {
                                              AssignmentElection = assingmentelectiondetails.AssignmentElection,
                                              ElectionID = electiondetails.ElectionID,
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
                                              },
                                              AreaList = GetAreaDetails((int)assingmentelectiondetails.AssignmentElection),
                                              ZoneList = GetZoneDetails((int)assingmentelectiondetails.AssignmentElection)
                                          }).FirstOrDefault();
            return AssingmentElectionList;
        }
    }
}