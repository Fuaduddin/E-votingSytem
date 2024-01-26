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
using System.Web.UI.WebControls;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class VotersController : ApiController
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
                                     ZoneID = (int)area.ZoneID,
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

        [ResponseType(typeof(Voter))]
        public VoterModel GetVoter(int id)
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
                             where voter.VoterID == id
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
                                     ZoneID = (int)area.ZoneID,
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
            return VoterList;
        }

        [ResponseType(typeof(Voter))]
        public bool DeleteVoter(int id)
        {
            bool IsDeleted = true;
            try
            {
                var VoterDetails=db.Voters.Where(x=>x.VoterID== id).FirstOrDefault();
                var UserDetails=db.Users.Where(x=>x.UserIDNo ==VoterDetails.UserID).FirstOrDefault();
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
                var VoterDetails = db.Voters.Where(x => x.VoterID == id).FirstOrDefault();
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
        public bool PutVoter(int id, Voter voter)
        {
            bool isUpdated = true;
            if(voter != null && id> 0)
            {
                try
                {
                    var VoterDetails=db.Voters.Where(x=>x.VoterID== id).FirstOrDefault();
                    if(VoterDetails.VoterID>0)
                    {
                        VoterDetails.VoterName = voter.VoterName;
                        VoterDetails.VoterImage = voter.VoterImage;
                        VoterDetails.VoterPhoneNumber = voter.VoterPhoneNumber;
                        VoterDetails.VoterEmail = voter.VoterEmail;
                        VoterDetails.VoterZone = voter.VoterZone;
                        VoterDetails.VoterArea = voter.VoterArea;
                        VoterDetails.VoterPresentAddress = voter.VoterPresentAddress;
                        VoterDetails.VoterPermanentAddress = voter.VoterPermanentAddress;
                        VoterDetails.VoterNID = voter.VoterNID;
                        VoterDetails.VoterGender = voter.VoterGender;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    isUpdated = false;
                    throw new Exception(ex.Message.ToString());
                }
            }
            return isUpdated;
        }
    }
}