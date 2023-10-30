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

namespace E_Voting.Restful.API.Controllers
{
    public class Election_DetailController : ApiController
    {
        private Entities5 db = new Entities5();

        // GET: api/Election_Detail
        public IQueryable<Election_Detail> GetElection_Details()
        {
            return db.Election_Details;
        }

        // GET: api/Election_Detail/5
        [ResponseType(typeof(Election_Detail))]
        public async Task<IHttpActionResult> GetElection_Detail(int id)
        {
            Election_Detail election_Detail = await db.Election_Details.FindAsync(id);
            if (election_Detail == null)
            {
                return NotFound();
            }

            return Ok(election_Detail);
        }

        // PUT: api/Election_Detail/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElection_Detail(int id, Election_Detail election_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != election_Detail.ElectionID)
            {
                return BadRequest();
            }

            db.Entry(election_Detail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Election_DetailExists(id))
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

        //// POST: api/Election_Detail
        //[ResponseType(typeof(Election_Detail))]
        //public async Task<IHttpActionResult> PostElection_Detail(Election_Detail election_Detail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Election_Details.Add(election_Detail);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = election_Detail.ElectionID }, election_Detail);
        //}

        // DELETE: api/Election_Detail/5
        [ResponseType(typeof(Election_Detail))]
        public async Task<IHttpActionResult> DeleteElection_Detail(int id)
        {
            Election_Detail election_Detail = await db.Election_Details.FindAsync(id);
            if (election_Detail == null)
            {
                return NotFound();
            }

            db.Election_Details.Remove(election_Detail);
            await db.SaveChangesAsync();

            return Ok(election_Detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Election_DetailExists(int id)
        {
            return db.Election_Details.Count(e => e.ElectionID == id) > 0;
        }

        // Custome API Controller

        // POST: api/Election_Detail
        [ResponseType(typeof(Election_Detail))]
        public async Task<IHttpActionResult> PostElection_Detail(Election_Detail election_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Election_Details.Add(election_Detail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = election_Detail.ElectionID }, election_Detail);
        }
    }
}