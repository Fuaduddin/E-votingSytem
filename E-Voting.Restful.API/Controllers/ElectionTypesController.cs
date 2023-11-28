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
    public class ElectionTypesController : ApiController
    {
        private Entities db = new Entities(); 

        // GET: api/ElectionTypes
        //public IQueryable<ElectionType> GetElectionTypes()
        //{
        //    return db.ElectionTypes;
        //}

        // GET: api/ElectionTypes/5
        [ResponseType(typeof(ElectionType))]
        public async Task<IHttpActionResult> GetElectionType(int id)
        {
            ElectionType electionType = await db.ElectionTypes.FindAsync(id);
            if (electionType == null)
            {
                return NotFound();
            }

            return Ok(electionType);
        }

        // PUT: api/ElectionTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElectionType(int id, ElectionType electionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != electionType.ElectionID)
            {
                return BadRequest();
            }

            db.Entry(electionType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionTypeExists(id))
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

        // POST: api/ElectionTypes
        [ResponseType(typeof(ElectionType))]
        public async Task<IHttpActionResult> PostElectionType(ElectionType electionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElectionTypes.Add(electionType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = electionType.ElectionID }, electionType);
        }

        // DELETE: api/ElectionTypes/5
        [ResponseType(typeof(ElectionType))]
        public async Task<IHttpActionResult> DeleteElectionType(int id)
        {
            ElectionType electionType = await db.ElectionTypes.FindAsync(id);
            if (electionType == null)
            {
                return NotFound();
            }

            db.ElectionTypes.Remove(electionType);
            await db.SaveChangesAsync();

            return Ok(electionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElectionTypeExists(int id)
        {
            return db.ElectionTypes.Count(e => e.ElectionID == id) > 0;
        }

        // Custome API

        // GET: api/ElectionTypes
        public List<ElectionType> GetElectionTypes()
        {
            List<ElectionType> ElectionTypes = new List<ElectionType>();
            var ElectionTypeList= db.ElectionTypes;
            foreach (var electionType in ElectionTypeList)
            {
                var type = new ElectionType()
                {
                    ElectionID = electionType.ElectionID,
                    ElectionName = electionType.ElectionName
                };
                ElectionTypes.Add(type);
            }
            return ElectionTypes;
        }
    }
}