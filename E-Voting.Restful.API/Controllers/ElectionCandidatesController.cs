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
    public class ElectionCandidatesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/ElectionCandidates
        public IQueryable<ElectionCandidate> GetElectionCandidates()
        {
            return db.ElectionCandidates;
        }

        // GET: api/ElectionCandidates/5
        [ResponseType(typeof(ElectionCandidate))]
        public async Task<IHttpActionResult> GetElectionCandidate(int id)
        {
            ElectionCandidate electionCandidate = await db.ElectionCandidates.FindAsync(id);
            if (electionCandidate == null)
            {
                return NotFound();
            }

            return Ok(electionCandidate);
        }

        // PUT: api/ElectionCandidates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElectionCandidate(int id, ElectionCandidate electionCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != electionCandidate.ElectionCandidateID)
            {
                return BadRequest();
            }

            db.Entry(electionCandidate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionCandidateExists(id))
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

        // POST: api/ElectionCandidates
        [ResponseType(typeof(ElectionCandidate))]
        public async Task<IHttpActionResult> PostElectionCandidate(ElectionCandidate electionCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElectionCandidates.Add(electionCandidate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = electionCandidate.ElectionCandidateID }, electionCandidate);
        }

        // DELETE: api/ElectionCandidates/5
        [ResponseType(typeof(ElectionCandidate))]
        public async Task<IHttpActionResult> DeleteElectionCandidate(int id)
        {
            ElectionCandidate electionCandidate = await db.ElectionCandidates.FindAsync(id);
            if (electionCandidate == null)
            {
                return NotFound();
            }

            db.ElectionCandidates.Remove(electionCandidate);
            await db.SaveChangesAsync();

            return Ok(electionCandidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElectionCandidateExists(int id)
        {
            return db.ElectionCandidates.Count(e => e.ElectionCandidateID == id) > 0;
        }
    }
}