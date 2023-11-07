using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;
using Newtonsoft.Json.Linq;

namespace E_Voting.Restful.API.Controllers
{
    public class AreasController : ApiController
    {
        private Entities6 db = new Entities6();

        // GET: api/Areas
        //public IQueryable<Area> GetAreas()
        //{
        //    return db.Areas;
        //}

        // GET: api/Areas/5
        //[ResponseType(typeof(Area))]
        //public async Task<IHttpActionResult> GetArea(int id)
        //{
        //    Area area = await db.Areas.FindAsync(id);
        //    if (area == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(area);
        //}

        // PUT: api/Areas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArea(int id, Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != area.AreaID)
            {
                return BadRequest();
            }

            db.Entry(area).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Areas
        //[ResponseType(typeof(Area))]
        //public async Task<IHttpActionResult> PostArea(Area area)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Areas.Add(area);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = area.AreaID }, area);
        //}

        // DELETE: api/Areas/5
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> DeleteArea(int id)
        {
            Area area = await db.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            db.Areas.Remove(area);
            await db.SaveChangesAsync();

            return Ok(area);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaExists(int id)
        {
            return db.Areas.Count(e => e.AreaID == id) > 0;
        }

        // Custome API Controller


        // GET: api/Areas/5
        [ResponseType(typeof(Area))]
        public areamodel GetArea(int id)
        {
            areamodel AreaDetails = new areamodel();
            if (id > 0)
            {
                var areadetails = db.Areas;
                var zonedetails = db.Zones;
                 AreaDetails = (from areasdetails in areadetails
                                   join zonedetailslist in zonedetails on areasdetails.ZoneID
                                   equals zonedetailslist.ZoneId
                                   where areasdetails.AreaID == id
                                   select new areamodel
                                   {
                                       AreaID = areasdetails.AreaID,
                                       AreaName = areasdetails.AreaName,
                                       AreaTitle = areasdetails.AreaTitle,
                                       ZoneID = zonedetailslist.ZoneId,
                                       ZoneDetailsitem = new zoneModel
                                       {
                                           ZoneId = zonedetailslist.ZoneId,
                                           ZoneName = zonedetailslist.ZoneName
                                       }
                                   }).FirstOrDefault();
                
            }
            return AreaDetails;
        }

        // GET: api/Areas
        public List<areamodel> GetAreas()
        {
            var areadetails = db.Areas;
            var zonedetails = db.Zones;
            var AreaDetails = (from areasdetails in areadetails
                              join zonedetailslist in zonedetails on areasdetails.ZoneID
                              equals zonedetailslist.ZoneId
                              where areasdetails.ZoneID == zonedetailslist.ZoneId
                              select new areamodel
                              {
                                  AreaID = areasdetails.AreaID,
                                  AreaName = areasdetails.AreaName,
                                  AreaTitle = areasdetails.AreaTitle,
                                  ZoneID = zonedetailslist.ZoneId,
                                  ZoneDetailsitem = new zoneModel
                                  {
                                      ZoneId = zonedetailslist.ZoneId,
                                      ZoneName = zonedetailslist.ZoneName
                                  }
                              }).ToList();
            return AreaDetails;
        }

        // POST: api/Areas
        [ResponseType(typeof(Area))]
        public int PostArea(areamodel area)
        {
            if(ModelState.IsValid)
            {
                if(area != null)
                {
                    var AreaDetails = new Area
                    {
                        AreaName = area.AreaName,
                        AreaTitle = area.AreaTitle,
                        ZoneID = area.ZoneID
                    };
                    db.Areas.Add(AreaDetails);
                    db.SaveChanges();
                }
            }
            return area.AreaID;
        }
    }
}