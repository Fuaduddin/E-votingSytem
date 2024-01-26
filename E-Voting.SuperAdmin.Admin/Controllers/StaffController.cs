using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.Models;
using Evoting.BusinessLayer;
using System.ComponentModel.Design;
using Evoting.GlobalSetting;
using Newtonsoft.Json;
using static Evoting.GlobalSetting.Enums;
using E_Voting.SuperAdmin.Admin.Extension;
using System.Drawing.Printing;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
  [Authorize]
    public class StaffController : Controller
    {
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        private readonly GlobalCommonData CommonData = new GlobalCommonData();
        private readonly ExtensionMethods extension = new ExtensionMethods();
        // GET: Staff
        /// <summary>
        /// /Voter Details
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult GetAllVoter()
        {
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = GetPaginationVoter(1, 10);
            Voter.TotalPage = pagecountVoter(10);
            return View("GetAllVoter", Voter);
        }
        public ActionResult AddNewVoter()
        {
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.Voter = new VoterModel();
            Voter.Voter.User = new UserModel();
            Voter.ZoneList = ElectionSettingsManager.GetAllZone();
            Voter.AreaList = ElectionSettingsManager.GetAllArea();
            Voter.genders = CommonData.genders;
            return View("AddNewVoter", Voter);
        }
        [HttpPost]
        public ActionResult AddNewVoter(SuperAdminAndAdminViewModel VoterDetails, HttpPostedFileBase File)
        {
            if (VoterDetails.Voter.VoterID > 0)
            {
                if (StaffManager.UpdateVoter(VoterDetails.Voter))
                {
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                    return View("AddNewVoter", VoterDetails.Voter);
                }
            }
            else
            {
                if (CheckVoterExistorNot(VoterDetails.Voter.VoterNID))
                {
                    ViewData["Message"] = "Your data is already existed";
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        VoterDetails.Voter.User = NewUserSettingsDetails(VoterDetails.Voter.VoterNID, VoterDetails.Voter.User.UserPassword);
                        VoterDetails.Voter.User.UserRole = Role.Voter.ToString();
                        VoterDetails.Voter.VoterImage = extension.UploadImage(File);
                        if (StaffManager.AddNewVoter(VoterDetails.Voter))
                        {
                            ViewData["Message"] = "Your data have been added";
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                            return View("AddNewVoter", VoterDetails.Voter);
                        }
                    }
                }
            }
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = GetPaginationVoter(1, 10);
            Voter.TotalPage = pagecountVoter(10);
            return View("GetAllVoter", Voter);
        }
        public ActionResult DeleteVoter(int id)
        {
            if (id > 0)
            {
                if (StaffManager.DeleteVoter(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = GetPaginationVoter(1, 10);
            Voter.TotalPage = pagecountVoter(10);
            return View("GetAllVoter", Voter);
        }
        public ActionResult GetSingleVoter(int id)
        {
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            if (id > 0)
            {
                Voter.Voter = StaffManager.GetSingleVoter(id);
                Voter.ZoneList = ElectionSettingsManager.GetAllZone();
                Voter.AreaList = ElectionSettingsManager.GetAllArea();
            }
            return View("AddNewVoter", Voter);
        }
        public ActionResult ActiveProfile(int id)
        {
            if (id > 0)
            {
                if (StaffManager.ActiveProfile(id))
                {
                    ViewData["Message"] = "Your data have been Activated";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = GetPaginationVoter(1, 10);
            Voter.TotalPage = pagecountVoter(10);
            return View("GetAllVoter", Voter);
        }
        // All Extra Feautures not complete
        private List<VoterModel> GetPaginationVoter(int pageindex, int pagesize)
        {
            List<VoterModel> Voterlist = StaffManager.GetAllVoter();
            return Voterlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountVoter(int perpagedata)
        {
            List<VoterModel> Voterlist = StaffManager.GetAllVoter();
            return Convert.ToInt32(Math.Ceiling(Voterlist.Count() / (double)perpagedata));
        }
        public JsonResult GetpaginatiotabledataVoter(int pageindex, int pagesize)
        {
            List<VoterModel> Voterlist = new List<VoterModel>();
            Voterlist = GetPaginationVoter(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(Voterlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchVoter(string Search)
        {
            List<VoterModel> Voterlist = new List<VoterModel>();
            Voterlist = StaffManager.GetAllVoter().Where(x => x.VoterEmail.Contains(Search) || x.VoterName.Contains(Search) || x.VoterNID.Contains(Search)
            || x.VoterPhoneNumber.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(Voterlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// /Candidate Details
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllCandidate()
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.CandidateList = GetPaginationCandidate(1, 10);
            Candidate.TotalPage = pagecountCandidate(10);
            return View("GetAllVoter", Candidate);
        }
        public ActionResult AddNewCandidate()
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.Candidate = new CandidateModel();
            Candidate.ElectionDetailsList = ElectionSettingsManager.GetAllElectionDetails();
            Candidate.ZoneList = ElectionSettingsManager.GetAllZone();
            Candidate.AreaList = ElectionSettingsManager.GetAllArea();
            Candidate.genders = CommonData.genders;
            Candidate.PartyList = PartyManager.GetAllParty();
            return View("AddNewCandidate", Candidate);
        }
        [HttpPost]
        public ActionResult AddNewCandidate(SuperAdminAndAdminViewModel CandidateDetails, HttpPostedFileBase File, HttpPostedFileBase ElectionIcon)
        {
            if (CandidateDetails.Candidate.CandidateID > 0)
            {
                if (StaffManager.UpdateCandidate(CandidateDetails.Candidate))
                {
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            else
            {
                if (CheckVoterExistorNot(CandidateDetails.Candidate.CandidateNID))
                {
                    if (CheckElectionValidation(CandidateDetails.Candidate.AssignmentCandidate.ElectionAssignment.ElectionID))
                    {
                        if (CheckCandidateExistorNot(CandidateDetails.Candidate.CandidateNID))
                        {
                            ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                        }
                        else
                        {
                            if (ModelState.IsValid)
                            {
                                CandidateDetails.Candidate.User = NewUserSettingsDetails(CandidateDetails.Candidate.User.UserID, CandidateDetails.Candidate.User.UserPassword);
                                CandidateDetails.Candidate.User.UserRole = Role.Candidate.ToString();
                                CandidateDetails.Candidate.CandidateImage = extension.UploadImage(File);
                                CandidateDetails.Candidate.AssignmentCandidate.ZoneandArea = ElectionSettingsManager.GetSingleAssingElectionDetailsList(CandidateDetails.Candidate.AssignmentCandidate.ElectionAssignment.ElectionID,
                                                                                                                                                      CandidateDetails.Candidate.AssignmentCandidate.ElectionAssignment.ZoneID,
                                                                                                                                                      CandidateDetails.Candidate.AssignmentCandidate.ElectionAssignment.AreaID);
                                CandidateDetails.Candidate.AssignmentCandidate.ElectionComplete = 0;
                                CandidateDetails.Candidate.AssignmentCandidate.CandidateSymbol = extension.UploadImage(ElectionIcon);
                                CandidateDetails.Candidate.AssignmentCandidate.ElectionID = CandidateDetails.Candidate.AssignmentCandidate.ElectionAssignment.ElectionID;
                                CandidateDetails.Candidate.AssignmentCandidate.CandidateID = StaffManager.AddNewCandidate(CandidateDetails.Candidate);
                                if (ElectionSettingsManager.AddNewAssignCandidate(CandidateDetails.Candidate.AssignmentCandidate))
                                {
                                    ViewData["Message"] = "Your data have been added";
                                    ModelState.Clear();
                                }
                                else
                                {
                                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                    }

                }
                else
                {
                    ViewData["Message"] = "User Does not Have any Voter Account";
                }
            }
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.CandidateList = GetPaginationCandidate(1, 10);
            Candidate.TotalPage = pagecountCandidate(10);
            return View("GetAllVoter", Candidate);
        }
        public ActionResult DeleteCandidate(int id)
        {
            if (id > 0)
            {
                if (StaffManager.DeleteCandidate(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.CandidateList = GetPaginationCandidate(1, 10);
            Candidate.TotalPage = pagecountCandidate(10);
            return View("GetAllVoter", Candidate);
        }
        public ActionResult GetSingleCandidate(int id)
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            if (id > 0)
            {
                Candidate.Candidate = StaffManager.GetSingleCandiate(id);
                Candidate.ZoneList = ElectionSettingsManager.GetAllZone();
                Candidate.AreaList = ElectionSettingsManager.GetAllArea();
            }
            return View("AddNewCandidate", Candidate);
        }

        // All Extra Feautures not complete
        private List<CandidateModel> GetPaginationCandidate(int pageindex, int pagesize)
        {
            List<CandidateModel> Candidatelist = StaffManager.GetAllCandidate();
            return Candidatelist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountCandidate(int perpagedata)
        {
            List<CandidateModel> Candidatelist = StaffManager.GetAllCandidate();
            return Convert.ToInt32(Math.Ceiling(Candidatelist.Count() / (double)perpagedata));
        }
        public JsonResult GetpaginatiotabledataCandidate(int pageindex, int pagesize)
        {
            List<CandidateModel> Candidatelist = new List<CandidateModel>();
            Candidatelist = GetPaginationCandidate(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(Candidatelist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchCandidate(string Search)
        {
            List<CandidateModel> Candidatelist = new List<CandidateModel>();
            Candidatelist = StaffManager.GetAllCandidate().Where(x => x.CandidateName.Contains(Search) || x.CandidatePhoneNumber.Contains(Search) || x.CandidateEmail.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(Candidatelist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// /Admin Details
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewAdmin()
        {
            SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
            Admin.Admin = new AdminModel();
            Admin.User= new UserModel();
            Admin.ZoneList = ElectionSettingsManager.GetAllZone();
            Admin.AreaList = ElectionSettingsManager.GetAllArea();
            Admin.genders = CommonData.genders;
            return View("AddNewAdmin", Admin);
        }
        [HttpPost]
        public ActionResult AddNewAdmin(SuperAdminAndAdminViewModel AdminDetails, HttpPostedFileBase File)
        {
            if (AdminDetails.Admin.AdminID > 0)
            {
                if (File.ContentLength > 0)
                {

                }
                if (StaffManager.UpdateAdmin(AdminDetails.Admin))
                {
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            else
            {
                // if(ModelState.IsValid)
                if (AdminDetails.Admin != null)
                {
                    AdminDetails.Admin.User = NewUserSettingsDetails(AdminDetails.Admin.User.UserID, AdminDetails.Admin.User.UserPassword);
                    AdminDetails.Admin.User.UserRole = Role.Admin.ToString();
                    AdminDetails.Admin.AdminProfilePIc = extension.UploadImage(File);
                    if (StaffManager.AddNewAdmin(AdminDetails.Admin))
                    {
                        ViewData["Message"] = "Your data have been Added";
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                    }
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                    // return View("AddNewAdmin", Admin);
                }

            }
            SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
            Admin.Admin = new AdminModel();
            Admin.ZoneList = ElectionSettingsManager.GetAllZone();
            Admin.AreaList = ElectionSettingsManager.GetAllArea();
            return View("GetAllAdmin", Admin);
        }
        public ActionResult GetAllAdmin()
        {
            SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
            Admin.AdminList = GetPaginationAdmin(1, 10);
            Admin.TotalPage = pagecountAdmin(10);
            return View("GetAllAdmin", Admin);
        }
        public ActionResult DeleteAdmin(int id)
        {
            if (id > 0)
            {
                if (StaffManager.DeleteCandidate(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
            Admin.AdminList = GetPaginationAdmin(1, 10);
            Admin.TotalPage = pagecountAdmin(10);
            return View("GetAllVoter", Admin);
        }
        public ActionResult GetSingleAdmin(int id)
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            if (id > 0)
            {
                Candidate.Candidate = StaffManager.GetSingleCandiate(id);
                Candidate.ZoneList = ElectionSettingsManager.GetAllZone();
                Candidate.AreaList = ElectionSettingsManager.GetAllArea();
            }
            return View("AddNewCandidate", Candidate);
        }
        public ActionResult ActiveProfileAdmin(int id)
        {
            if (id > 0)
            {
                if (StaffManager.ActiveProfile(id))
                {
                    ViewData["Message"] = "Your data have been Activated";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
            Admin.AdminList = GetPaginationAdmin(1, 10);
            Admin.TotalPage = pagecountAdmin(10);
            return View("GetAllVoter", Admin);
        }
        // All Extra Feautures not complete
        private List<AdminModel> GetPaginationAdmin(int pageindex, int pagesize)
        {
            List<AdminModel> Adminlist = StaffManager.GetAllAdmin();
            return Adminlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountAdmin(int perpagedata)
        {
            List<AdminModel> Adminlist = StaffManager.GetAllAdmin();
            return Convert.ToInt32(Math.Ceiling(Adminlist.Count() / (double)perpagedata));
        }

        public JsonResult GetpaginatiotabledataAdmin(int pageindex, int pagesize)
        {
            List<AdminModel> Adminlist  = new List<AdminModel>();
            Adminlist = GetPaginationAdmin(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(Adminlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAdmin(string Search)
        {
            List<AdminModel> Adminlist = new List<AdminModel>();
            Adminlist = StaffManager.GetAllAdmin().Where(x=>x.AdminName.Contains(Search) || x.AdminPhoneNumber.Contains(Search) || x.AdminEmail.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(Adminlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// /Common Internal Function
        /// </summary>
        /// <returns></returns>

        // Make New User Details Settings
        internal UserModel NewUserSettingsDetails(string UserNID, string UserPassword)
        {
            var UserDetails = new UserModel()
            {
                UserID = UserNID,
                UserPassword = settings.PasswordEncrypt(UserPassword),
                UserStatus = Status.Active.ToString(),
                UserTotalLogin = 0,
            };
            return UserDetails;
        }
        /// Check Exist ID
        private bool CheckCandidateExistorNot(string NIDNumber)
        {
            bool IsExisted = false;
            var GetAllVoter = StaffManager.GetAllCandidate();
            if (GetAllVoter.Count(e => e.CandidateNID == NIDNumber) > 0)
            {
                IsExisted = true;
            }
            return IsExisted;
        }
        private bool CheckVoterExistorNot(string NIDNumber)
        {
            bool IsExisted = false;
            var GetAllVoter = StaffManager.GetAllVoter();
            if (GetAllVoter.Count(e => e.VoterNID == NIDNumber) > 0)
            {
                IsExisted = true;
            }
            return IsExisted;
        }
        private bool CheckElectionValidation(int ElectionID)
        {
            bool Validated = true;
            var ElectionValidation = ElectionSettingsManager.GetAllElectionDetails().Where(x=> x.ElectionID== ElectionID).FirstOrDefault();
            var TodaysDate=DateTime.Now;
            if (TodaysDate > ElectionValidation.StartDate)
            {
                Validated = false;
            }
            return Validated;
        }
    }
}