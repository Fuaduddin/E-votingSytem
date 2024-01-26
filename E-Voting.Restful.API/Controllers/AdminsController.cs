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
        private Entities db = new Entities();


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
                                   ZoneID = (int)area.ZoneID,
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
        [ResponseType(typeof(Admin))]
        public AdminModel GetAdmin(int id)
        {
            var AreaList = db.Areas;
            var ZoneList = db.Zones;
            var UserList = db.Users;
            var AdminsDetails = db.Admins;
            var AdminList = (from admin in AdminsDetails
                             join
                             user in UserList on admin.UserID equals user.UserIDNo
                             join
                             area in AreaList on admin.AdminArea equals area.AreaID
                             join
                             zone in ZoneList on admin.AdminZone equals zone.ZoneId
                             where admin.AdminID == id
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
                                 Area = new areamodel()
                                 {
                                     AreaID = area.AreaID,
                                     AreaName = area.AreaName,
                                     AreaTitle = area.AreaTitle,
                                     ZoneID = (int) area.ZoneID,
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
                             }).FirstOrDefault();
            return AdminList;
        }

        [ResponseType(typeof(Admin))]
        public bool DeleteAdmin(int id)
        {
            bool IsDeleted = true;
            try
            {
                var VoterDetails = db.Admins.Where(x => x.AdminID == id).FirstOrDefault();
                var UserDetails = db.Users.Where(x => x.UserIDNo == VoterDetails.UserID).FirstOrDefault();
                UserDetails.UserStatus = "Inactive";
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message.ToString());
            }
            return IsDeleted;
        }
        [ResponseType(typeof(Voter))]
        [Route("api/ActivateProfile")]
        public bool ActivateProfile(int id)
        {
            bool IsActivated = true;
            try
            {
                var VoterDetails = db.Admins.Where(x => x.AdminID == id).FirstOrDefault();
                var UserDetails = db.Users.Where(x => x.UserIDNo == VoterDetails.UserID).FirstOrDefault();
                UserDetails.UserStatus = "Active";
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                IsActivated = false;
                throw new Exception(ex.Message.ToString());
            }
            return IsActivated;
        }
        [ResponseType(typeof(void))]
        public bool PutAdmin(int id, Admin admin)
        {
            bool IsUpdated = true;
            try
            {
                if(id>0 && admin!=null)
                {
                    var AdminDetails = db.Admins.Where(x => x.AdminID == id).FirstOrDefault();
                    if(AdminDetails.AdminID>0)
                    {
                        AdminDetails.AdminProfilePIc = admin.AdminProfilePIc;
                        AdminDetails.AdminName = admin.AdminName;
                        AdminDetails.AdminPhoneNumber = admin.AdminPhoneNumber;
                        AdminDetails.AdminEmail = admin.AdminEmail;
                        AdminDetails.AdminZone = admin.AdminZone;
                        AdminDetails.AdminArea = admin.AdminArea;
                        AdminDetails.AdminAddressPresent = admin.AdminAddressPresent;
                        AdminDetails.AdminAddressPermanent = admin.AdminAddressPermanent;
                        AdminDetails.AdminGender = admin.AdminGender;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception(ex.Message.ToString());
            }

            return IsUpdated;
        }
    }
}