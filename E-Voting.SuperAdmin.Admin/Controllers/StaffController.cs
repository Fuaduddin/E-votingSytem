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

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class StaffController : Controller
    {
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        // GET: Staff
        /// <summary>
        /// /Voter Details
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult GetAllVoter()
        {
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = StaffManager.GetAllVoter();
            return View("GetAllVoter", Voter);
        }
        public ActionResult AddNewVoter()
        {
            SuperAdminAndAdminViewModel Voter= new SuperAdminAndAdminViewModel();
            Voter.Voter=new VoterModel();
            Voter.ZoneList = ElectionSettingsManager.GetAllZone();
            Voter.AreaList = ElectionSettingsManager.GetAllArea();
            return View("AddNewVoter", Voter);
        }
        [HttpPost]
        public ActionResult AddNewVoter(VoterModel VoterDetails)
        {
            if(VoterDetails.VoterID>0)
            {
                if(StaffManager.UpdateVoter(VoterDetails))
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
                if (CheckVoterExistorNot(VoterDetails.VoterNID))
                {
                    ViewData["Message"] = "Your data is already existed";
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        VoterDetails.User.UserPassword = settings.PasswordEncrypt(VoterDetails.VoterNID);
                        if (StaffManager.AddNewVoter(VoterDetails))
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
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList=StaffManager.GetAllVoter();
            return View("GetAllVoter", Voter);
        }
        public ActionResult DeleteVoter(int id)
        {
            if(id>0)
            {
                if(StaffManager.DeleteVoter(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!!!! ERROR !!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.VoterList = StaffManager.GetAllVoter();
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
        // check if exsist
        private bool CheckVoterExistorNot(string NIDNumber)
        {
            bool IsExisted=false;
            var GetAllVoter =StaffManager.GetAllVoter();
            if(GetAllVoter.Count(e => e.VoterNID == NIDNumber) > 0)
            {
                IsExisted=true;
            }
            return IsExisted;
        }
        // All Extra Feautures not complete
        //private List<ElectionModel> GetPaginationElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}
        //private int pagecountElectiontype(int perpagedata)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        //}
        //public List<ElectionModel> perpageshowdataElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}

        //public JsonResult GetpaginatiotabledataElectiontype(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
        //    party.TotalPage = pagecountElectiontype(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult SearchElectionTypeData(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataArea(pageindex, pagesize);
        //    party.TotalPage = pagecountArea(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);


        /// <summary>
        /// /Candidate Details
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllCandidate()
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.CandidateList = StaffManager.GetAllCandidate();
            return View("GetAllCandidate", Candidate);
        }
        public ActionResult AddNewCandidate()
        {
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.Candidate = new CandidateModel();
            Candidate.ZoneList = ElectionSettingsManager.GetAllZone();
            Candidate.AreaList = ElectionSettingsManager.GetAllArea();
            return View("AddNewCandidate", Candidate);
        }
        [HttpPost]
        public ActionResult AddNewCandidate(CandidateModel CandidateDetails)
        {
            if(CandidateDetails.CandidateID>0)
            {
                if(StaffManager.UpdateCandidate(CandidateDetails))
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
                if(CheckCandidaterExistorNot(CandidateDetails.CandidateNID))
                {
                    ViewData["Message"] = "Your data is already existed";
                }
                else
                {
                    if(ModelState.IsValid)
                    {
                        if(StaffManager.AddNewCandidate(CandidateDetails))
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
            SuperAdminAndAdminViewModel Candidate = new SuperAdminAndAdminViewModel();
            Candidate.CandidateList = StaffManager.GetAllCandidate();
            return View("GetAllCandidate", Candidate);
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
            SuperAdminAndAdminViewModel Voter = new SuperAdminAndAdminViewModel();
            Voter.CandidateList = StaffManager.GetAllCandidate();
            return View("GetAllVoter", Voter);
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
        private bool CheckCandidaterExistorNot(string NIDNumber)
        {
            bool IsExisted = false;
            var GetAllCandidate= StaffManager.GetAllCandidate();
            if (GetAllCandidate.Count(e => e.CandidateNID == NIDNumber) > 0)
            {
                IsExisted = true;
            }
            return IsExisted;
        }
        // All Extra Feautures not complete
        //private List<ElectionModel> GetPaginationElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}
        //private int pagecountElectiontype(int perpagedata)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        //}
        //public List<ElectionModel> perpageshowdataElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}

        //public JsonResult GetpaginatiotabledataElectiontype(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
        //    party.TotalPage = pagecountElectiontype(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult SearchElectionTypeData(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataArea(pageindex, pagesize);
        //    party.TotalPage = pagecountArea(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);

        /// <summary>
        /// /Admin Details
        /// </summary>
        /// <returns></returns>
        //public ActionResult AddNewAdmin()
        //{
        //    SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
        //    Admin.Admin = new AdminModel();
        //    Admin.ZoneList = ElectionSettingsManager.GetAllZone();
        //    Admin.AreaList = ElectionSettingsManager.GetAllArea();
        //    return View("AddNewAdmin", Admin);
        //}
        //[HttpPost]
        //public ActionResult AddNewAdmin()
        //{
        //    SuperAdminAndAdminViewModel Admin = new SuperAdminAndAdminViewModel();
        //    Admin.Admin = new AdminModel();
        //    Admin.ZoneList = ElectionSettingsManager.GetAllZone();
        //    Admin.AreaList = ElectionSettingsManager.GetAllArea();
        //    return View("AddNewAdmin", Admin);
        //}


        // All Extra Feautures not complete
        //private List<ElectionModel> GetPaginationElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}
        //private int pagecountElectiontype(int perpagedata)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        //}
        //public List<ElectionModel> perpageshowdataElectiontype(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}

        //public JsonResult GetpaginatiotabledataElectiontype(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
        //    party.TotalPage = pagecountElectiontype(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult SearchElectionTypeData(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataArea(pageindex, pagesize);
        //    party.TotalPage = pagecountArea(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
    }
}