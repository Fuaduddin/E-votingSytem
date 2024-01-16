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

        // PUT: api/Candidates/5
        [ResponseType(typeof(void))]
        public bool PutCandidate(int id, CandidateModel candidate)
        {
            bool IsUpdated = true;
            try
            {
                var CandidateDetails=db.Candidates.Where(x=>x.CandidateID==id).FirstOrDefault();
                if(CandidateDetails!=null)
                {
                    CandidateDetails.CandidateImage = candidate.CandidateImage;
                    CandidateDetails.CandidateName=candidate.CandidateName;
                    CandidateDetails.CandidatePhoneNumber = candidate.CandidatePhoneNumber;
                    CandidateDetails.CandidateEmail = candidate.CandidateEmail;
                    CandidateDetails.CandidateZone = candidate.CandidateZone;
                    CandidateDetails.CandidateArea = candidate.CandidateArea;
                    CandidateDetails.CandidatePermanentAddress = candidate.CandidatePermanentAddress;
                    CandidateDetails.CandidatePresentAddress = candidate.CandidatePresentAddress;
                    CandidateDetails.CandidateNID = candidate.CandidateNID;
                    CandidateDetails.CandidateParty = candidate.CandidateParty;
                    CandidateDetails.CandidateGender = candidate.CandidateGender;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception (ex.Message);

            }

            return IsUpdated;
        }

    }
}