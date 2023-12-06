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

namespace E_Voting.Restful.API.Controllers
{
    public class CandidatesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Candidates
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        // GET: api/Candidates/5
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> GetCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // PUT: api/Candidates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidate.CandidateID)
            {
                return BadRequest();
            }

            db.Entry(candidate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        //[ResponseType(typeof(Candidate))]
        //public async Task<IHttpActionResult> PostCandidate(Candidate candidate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Candidates.Add(candidate);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = candidate.CandidateID }, candidate);
        //}

        // DELETE: api/Candidates/5
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> DeleteCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            db.Candidates.Remove(candidate);
            await db.SaveChangesAsync();

            return Ok(candidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidateExists(int id)
        {
            return db.Candidates.Count(e => e.CandidateID == id) > 0;
        }

        // Custome API

        [ResponseType(typeof(Candidate))]
        public int PostCandidate(CandidateModel candidate)
        {
            var UserDetails = new User()
            {
                UserID = candidate.User.UserID,
                UserPassword = candidate.User.UserPassword,
                UserLastLogin = candidate.User.UserLastLogin,
                UserTotalLogin = candidate.User.UserTotalLogin,
                UserLastLogout = candidate.User.UserLastLogout,
                UserRole = candidate.User.UserRole,
                UserStatus = candidate.User.UserStatus
            };
            db.Users.Add(UserDetails);
            db.SaveChanges();
            var CandidateDetails = new Candidate()
            {
                CandidateImage = candidate.CandidateImage,
                CandidateName = candidate.CandidateName,
                CandidatePhoneNumber = candidate.CandidatePhoneNumber,
                CandidateEmail = candidate.CandidateEmail,
                CandidateZone = candidate.CandidateZone,
                CandidateArea = candidate.CandidateArea,
                CandidatePermanentAddress = candidate.CandidatePermanentAddress,
                CandidatePresentAddress = candidate.CandidatePresentAddress,
                CandidateNID = candidate.CandidateNID,
                CandidateParty = candidate.CandidateParty,
                CandidateGender=candidate.CandidateGender,
                UserID = UserDetails.UserIDNo
            };
            db.Candidates.Add(CandidateDetails);
            db.SaveChanges();
            return CandidateDetails.CandidateID;
        }
    }
}