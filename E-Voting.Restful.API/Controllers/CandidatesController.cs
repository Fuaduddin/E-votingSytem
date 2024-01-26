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
        [ResponseType(typeof(Voter))]
        [Route("api/ActivateProfile")]
        public bool ActivateProfile(int id)
        {
            bool IsActivated = true;
            try
            {
                var VoterDetails = db.Candidates.Where(x => x.CandidateID == id).FirstOrDefault();
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
        [ResponseType(typeof(Candidate))]
        public bool DeleteCandidate(int id)
        {
            bool IsDeleted = true;
            try
            {
                var VoterDetails = db.Candidates.Where(x => x.CandidateID == id).FirstOrDefault();
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
        [ResponseType(typeof(Candidate))]
        public CandidateModel GetCandidate(int id)
        {
            var AreaList = db.Areas;
            var ZoneList = db.Zones;
            var UserList = db.Users;
            var CandidateDetails = db.Candidates;
            var CandidateList = (from candidate in CandidateDetails
                             join
                             user in UserList on candidate.UserID equals user.UserIDNo
                             join
                             area in AreaList on candidate.CandidateArea equals area.AreaID
                             join
                             zone in ZoneList on candidate.CandidateZone equals zone.ZoneId
                             where candidate.CandidateID == id
                             select new CandidateModel
                             {
                                 CandidateID = candidate.CandidateID,
                                 CandidateImage = candidate.CandidateImage,
                                 CandidateName = candidate.CandidateName,
                                 CandidatePhoneNumber = candidate.CandidatePhoneNumber,
                                 CandidateEmail = candidate.CandidateEmail,
                                 CandidateZone = candidate.CandidateZone,
                                 CandidateArea = candidate.CandidateArea,
                                 CandidatePermanentAddress = candidate.CandidatePermanentAddress,
                                 CandidatePresentAddress = candidate.CandidatePresentAddress,
                                 CandidateNID = candidate.CandidateNID,
                                 CandidateParty =(int) candidate.CandidateParty,
                                 CandidateGender = candidate.CandidateGender,
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
            return CandidateList;
        }
        public List<CandidateModel> GetCandidates()
        {
            var AreaList = db.Areas;
            var ZoneList = db.Zones;
            var UserList = db.Users;
            var CandidateDetails = db.Candidates;
            var CandidateList = (from candidate in CandidateDetails
                                 join
                                 user in UserList on candidate.UserID equals user.UserIDNo
                                 join
                                 area in AreaList on candidate.CandidateArea equals area.AreaID
                                 join
                                 zone in ZoneList on candidate.CandidateZone equals zone.ZoneId
                                 select new CandidateModel
                                 {
                                     CandidateID = candidate.CandidateID,
                                     CandidateImage = candidate.CandidateImage,
                                     CandidateName = candidate.CandidateName,
                                     CandidatePhoneNumber = candidate.CandidatePhoneNumber,
                                     CandidateEmail = candidate.CandidateEmail,
                                     CandidateZone = candidate.CandidateZone,
                                     CandidateArea = candidate.CandidateArea,
                                     CandidatePermanentAddress = candidate.CandidatePermanentAddress,
                                     CandidatePresentAddress = candidate.CandidatePresentAddress,
                                     CandidateNID = candidate.CandidateNID,
                                     CandidateParty = (int)candidate.CandidateParty,
                                     CandidateGender = candidate.CandidateGender,
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
            return CandidateList;
        }
    }
}