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
    public class VotersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Voters/5
        [ResponseType(typeof(Voter))]
        public async Task<IHttpActionResult> GetVoter(int id)
        {
            Voter voter = await db.Voters.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }

            return Ok(voter);
        }

        // PUT: api/Voters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVoter(int id, Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voter.VoterID)
            {
                return BadRequest();
            }

            db.Entry(voter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(id))
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
        // DELETE: api/Voters/5
        [ResponseType(typeof(Voter))]
        public async Task<IHttpActionResult> DeleteVoter(int id)
        {
            Voter voter = await db.Voters.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }

            db.Voters.Remove(voter);
            await db.SaveChangesAsync();

            return Ok(voter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoterExists(int id)
        {
            return db.Voters.Count(e => e.VoterID == id) > 0;
        }


        //Custome API Controllers Actions

        //// POST: api/Voters
        [ResponseType(typeof(Voter))]
        public int PostVoter(VoterModel voter)
        {
            var UserDetails = new User()
            {
                UserID = voter.User.UserID,
                UserPassword = voter.User.UserPassword,
                UserLastLogin = voter.User.UserLastLogin,
                UserTotalLogin = voter.User.UserTotalLogin,
                UserLastLogout = voter.User.UserLastLogout,
                UserRole = voter.User.UserRole,
                UserStatus = voter.User.UserStatus
            };
            db.Users.Add(UserDetails);
            db.SaveChanges();
            var VoterDetails = new Voter()
            {
                VoterImage = voter.VoterImage,
                VoterName = voter.VoterName,
                VoterPhoneNumber = voter.VoterPhoneNumber,
                VoterEmail = voter.VoterEmail,
                VoterZone = voter.VoterZone,
                VoterArea = voter.VoterArea,
                VoterPresentAddress = voter.VoterPresentAddress,
                VoterPermanentAddress = voter.VoterPermanentAddress,
                VoterNID = voter.VoterNID,
                VoterGender = voter.VoterGender,
                UserID = UserDetails.UserIDNo
            };
            db.Voters.Add(VoterDetails);
            db.SaveChanges();
            return VoterDetails.VoterID;
        }
        // GET: api/Voters
        public List<VoterModel> GetVoters()
        {
            var AreaList = db.Areas;
            var ZoneList = db.Zones;
            var UserList = db.Users;
            var VotersDetails = db.Voters;
            var VoterList = (from voter in VotersDetails
                             join
                             user in UserList on voter.UserID equals user.UserIDNo
                             join
                             area in AreaList on voter.VoterArea equals area.AreaID
                             join
                             zone in ZoneList on voter.VoterZone equals zone.ZoneId
                             select new VoterModel
                             {
                                 VoterID = voter.VoterID,
                                 VoterImage = voter.VoterImage,
                                 VoterName = voter.VoterName,
                                 VoterPhoneNumber = voter.VoterPhoneNumber,
                                 VoterEmail = voter.VoterEmail,
                                 VoterZone = voter.VoterZone,
                                 VoterArea = voter.VoterArea,
                                 VoterPresentAddress = voter.VoterPresentAddress,
                                 VoterPermanentAddress = voter.VoterPermanentAddress,
                                 VoterNID = voter.VoterNID,
                                 VoterGender = voter.VoterGender,
                                 Area = new areamodel()
                                 {
                                     AreaID = area.AreaID,
                                     AreaName = area.AreaName,
                                     AreaTitle = area.AreaTitle,
                                     ZoneID = area.ZoneID,
                                 },
                                 Zone = new zoneModel()
                                 {
                                     ZoneId = zone.ZoneId,
                                     ZoneName = zone.ZoneName
                                 },
                                 User = new UserModel()
                                 {
                                     UserIDNo = user.UserIDNo,
                                     UserRole = user.UserRole,
                                     UserID = user.UserID,
                                     UserPassword = user.UserPassword,
                                     UserLastLogin = (DateTime)user.UserLastLogin,
                                     UserStatus = user.UserStatus,
                                     UserTotalLogin = (int)user.UserTotalLogin,
                                     UserLastLogout = (DateTime)user.UserLastLogout,
                                 }
                             }).ToList();
            return VoterList;
        }
    }
}