using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class AdminsController : ApiController
    {
        private Entities6 db = new Entities6();

        // GET: api/Admins
        //public IQueryable<Admin> GetAdmins()
        //{
        //    return db.Admins;
        //}

        // GET: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> GetAdmin(int id)
        {
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.AdminID)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        //[ResponseType(typeof(Admin))]
        //public async Task<IHttpActionResult> PostAdmin(Admin admin)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Admins.Add(admin);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = admin.AdminID }, admin);
        //}

        // DELETE: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> DeleteAdmin(int id)
        {
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admins.Remove(admin);
            await db.SaveChangesAsync();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(int id)
        {
            return db.Admins.Count(e => e.AdminID == id) > 0;
        }



        /// Customer API Controller Methods
        [ResponseType(typeof(Admin))]
        public int PostAdmin(AdminModel admin)
        {
            var UserDetails = new User()
            {
                UserID = admin.User.UserID,
                UserPassword = admin.User.UserPassword,
                UserLastLogin = admin.User.UserLastLogin,
                UserTotalLogin = admin.User.UserTotalLogin,
                UserLastLogout = admin.User.UserLastLogout,
                UserRole = admin.User.UserRole,
                UserStatus = admin.User.UserStatus
            };
            db.Users.Add(UserDetails);
            db.SaveChanges();
            var AdminDetails = new Admin()
            {
                AdminProfilePIc = admin.AdminProfilePIc,
                AdminName = admin.AdminName,
                AdminPhoneNumber = admin.AdminPhoneNumber,
                AdminEmail = admin.AdminEmail,
                AdminZone = admin.AdminZone,
                AdminArea = admin.AdminArea,
                AdminAddressPresent = admin.AdminAddressPresent,
                AdminAddressPermanent = admin.AdminAddressPermanent,
                AdminGender = admin.AdminGender,
                UserID = UserDetails.UserIDNo
            };
            db.Admins.Add(AdminDetails);
            db.SaveChanges();
            return AdminDetails.AdminID;
        }
        // GET: api/Admins
        public List<AdminModel> GetAdmins()
        {
            var AreaList = db.Areas;
            var ZoneList=db.Zones;
            var UserList=db.Users;
            var AdminsDetails = db.Admins;
            var AdminList=(from admin in AdminsDetails 
                           join
                           user in UserList on admin.UserID equals user.UserIDNo
                           join 
                           area in AreaList on admin.AdminArea equals area.AreaID
                           join
                           zone in ZoneList on admin.AdminZone equals zone.ZoneId
                           select new AdminModel
                           {
                               AdminID = admin.AdminID,
                               AdminProfilePIc = admin.AdminProfilePIc,
                               AdminName = admin.AdminName,
                               AdminPhoneNumber = admin.AdminPhoneNumber,
                               AdminEmail = admin.AdminEmail,
                               AdminZone = admin.AdminZone,
                               AdminArea = admin.AdminArea,
                               AdminAddressPresent = admin.AdminAddressPresent,
                               AdminAddressPermanent = admin.AdminAddressPermanent,
                               AdminGender = admin.AdminGender,
                               Area= new areamodel()
                               {
                                   AreaID = area.AreaID,
                                   AreaName = area.AreaName,
                                   AreaTitle = area.AreaTitle,
                                   ZoneID = area.ZoneID,
                               },
                               Zone=new zoneModel()
                               {
                                   ZoneId = zone.ZoneId,
                                   ZoneName = zone.ZoneName
                               },
                               User = new UserModel()
                               {
                                   UserIDNo = user.UserIDNo,
                                   UserRole= user.UserRole,
                                   UserID = user.UserID,
                                   UserPassword = user.UserPassword,
                                   UserLastLogin = (DateTime)user.UserLastLogin,
                                   UserStatus = user.UserStatus,
                                   UserTotalLogin = (int)user.UserTotalLogin,
                                   UserLastLogout = (DateTime)user.UserLastLogout,
                               }
                           }).ToList();
            return AdminList;
        }
    }
}