using System;
using System.Collections;
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

namespace E_Voting.Restful.API.Controllers
{
    public class AreasController : ApiController
    {
        private Entities2 db = new Entities2();

        // GET: api/Areas
        public IQueryable<Area> GetAreas()
        {
            return db.Areas;
        }

        // GET: api/Areas/5
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> GetArea(int id)
        {
            Area area = await db.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

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
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> PostArea(Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Areas.Add(area);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = area.AreaID }, area);
        }

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



        /// <summary>
        ///  Custome
        /// </summary>
        // GET: api/GetZoneWiseArea/5
        //[Route("api/GetZoneWiseArea/{id}")]
        //[HttpGet]
        //public async Task<IEnumerable<Area>> GetZoneWiseArea(int id)
        //{
        //    List<Area> arealist = new List<Area>();
        //    arealist= db.Areas.Where(x=>x.ZoneID == id).ToList();
        //    //Zone zone = await db.Zones.FindAsync(id);
        //    if (arealist == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(arealist);
        //}
        //// GET: api/searchresult/searchname
        //[Route("api/GetSearchAreaList/{searchname}")]
        //[HttpGet]
        //public async Task<IEnumerable<Area>> GetSearchAreaList([FromUri]string searchname)
        //{
        //    List<Area> arealist = new List<Area>();
        //    arealist = (List<Area>)(from area in db.Areas where area.AreaTitle.Contains(searchname) select area);
        //    //Zone zone = await db.Zones.FindAsync(id);
        //    if (arealist == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(arealist);
        //}
    }
}