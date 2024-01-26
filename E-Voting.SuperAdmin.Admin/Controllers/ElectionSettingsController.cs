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
    [Authorize]
    public class ElectionSettingsController : Controller
    {
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        // GET: Election

        // Election Type
        public ActionResult AddNewElectionType()
        {
            SuperAdminAndAdminViewModel electiontypelist = new SuperAdminAndAdminViewModel();
            electiontypelist.ElectionType = new ElectionModel();
            electiontypelist.ElectionTypeList = GetPaginationElectiontype(1, 10);
            electiontypelist.TotalPage = pagecountElectiontype(10);
            return View("AddNewElectionType", electiontypelist);
        }
        [HttpPost]
        public ActionResult AddNewElectionType(ElectionModel electiontype)
        {
            if(ModelState.IsValid)
            {
                if(ElectionSettingsManager.AddNewElectionType(electiontype))
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                }
            }
            else
            {
                ViewData["Message"] = "ERROR !!!!!!!!!!!!!!!";
            }
            SuperAdminAndAdminViewModel electiontypelist = new SuperAdminAndAdminViewModel();
            electiontypelist.ElectionType = new ElectionModel();
            electiontypelist.ElectionTypeList = GetPaginationElectiontype(1, 10);
            electiontypelist.TotalPage = pagecountElectiontype(10);
            return View("AddNewElectionType", electiontypelist);
        }
        public ActionResult DeleteElectionType(int id)
        {
            if(id>0)
            {
                if(ElectionSettingsManager.DeleteElectionType(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "Your data not have  been Deleted";
                }
            }
            SuperAdminAndAdminViewModel electiontype = new SuperAdminAndAdminViewModel();
            electiontype.ElectionType = new ElectionModel();
            electiontype.ElectionTypeList = GetPaginationElectiontype(1,10);
            electiontype.TotalPage = pagecountElectiontype(10);
            return View("AddNewElectionType", electiontype);
        }


        // All Extra Feautures not complete
        private List<ElectionModel> GetPaginationElectiontype(int pageindex, int pagesize)
        {
            List<ElectionModel> ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return ElectionTypeList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountElectiontype(int perpagedata)
        {
            List<ElectionModel> ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return Convert.ToInt32(Math.Ceiling(ElectionTypeList.Count() / (double)perpagedata));
        }

        public JsonResult GetpaginatiotabledataElectiontype(int pageindex, int pagesize)
        {
            List<ElectionModel> ElectionTypeList=new List<ElectionModel>();
            ElectionTypeList = GetPaginationElectiontype(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(ElectionTypeList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Zone
        public ActionResult AddNewZone()
        {
            SuperAdminAndAdminViewModel zonedetails = new SuperAdminAndAdminViewModel();
            zonedetails.Zone = new zoneModel();
            zonedetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewZone", zonedetails);
        }
        [HttpPost]
        public ActionResult AddNewZone(zoneModel zone)
        {
            SuperAdminAndAdminViewModel zonedetails = new SuperAdminAndAdminViewModel();
            if(ModelState.IsValid)
            {
                if(ElectionSettingsManager.AddNewZone(zone))
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                }
            }
            else
            {
                ViewData["Message"] = "!!!!!! ERROR !!!!!!!";
            }
            zonedetails.Zone = new zoneModel();
            zonedetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewZone", zonedetails);
        }
        public ActionResult DeleteZone(int id)
        {
            if(id>0)
            {
                if(ElectionSettingsManager.DeleteZone(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been deleted";
                }
            }
            else
            {
                ViewData["Message"] = "!!!!!! ERROR !!!!!!!";
            }
            SuperAdminAndAdminViewModel zonedetails = new SuperAdminAndAdminViewModel();
            zonedetails.Zone = new zoneModel();
            zonedetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewZone", zonedetails);
        }

        // Area
        public ActionResult AddNewArea()
        {
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = new areamodel();
            Areadetails.AreaList = GetPaginationArea(1,10);
            Areadetails.TotalPage = pagecountArea(10);
            Areadetails.ZoneList=ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }
        [HttpPost]
        public ActionResult AddNewArea(areamodel area)
        {
            SuperAdminAndAdminViewModel areadetails = new SuperAdminAndAdminViewModel();
            if(area.AreaID>0)
            {
                if(ElectionSettingsManager.UpdateArea(area))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (ElectionSettingsManager.AddNewArea(area))
                    {
                        ViewData["Message"] = "Your data have been Added";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewData["Message"] = "Your data have not been Added";
                    }
              }
                else
                {
                    ViewData["Message"] = "!!!!!! ERROR !!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = new areamodel();
            Areadetails.AreaList = GetPaginationArea(1, 10);
            Areadetails.TotalPage = pagecountArea(10);
            Areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }
        public ActionResult DeleteArea(int id)
        {
            if (id > 0)
            {
                if (ElectionSettingsManager.DeleteArea(id))
                {
                    ViewData["Message"] = "Your data have been deleted";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been deleted";
                }
            }
            else
            {
                ViewData["Message"] = "!!!!!! ERROR !!!!!!!";
            }
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = new areamodel();
            Areadetails.AreaList = GetPaginationArea(1, 10);
            Areadetails.TotalPage = pagecountArea(10);
            Areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }
        public ActionResult GetSingleArea(int id)
        {
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = ElectionSettingsManager.GetSingleArea(id);
            Areadetails.Area = new areamodel();
            Areadetails.AreaList = GetPaginationArea(1, 10);
            Areadetails.TotalPage = pagecountArea(10);
            Areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }

        // All Extra Feautures not complete
        private List<areamodel> GetPaginationArea(int pageindex, int pagesize)
        {
            List<areamodel> arealist = ElectionSettingsManager.GetAllArea();
            return arealist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountArea(int perpagedata)
        {
            List<areamodel> arealist = ElectionSettingsManager.GetAllArea();
            return Convert.ToInt32(Math.Ceiling(arealist.Count() / (double)perpagedata));
        }

        public JsonResult GetpaginatiotabledataArea(int pageindex, int pagesize)
        {
            List<areamodel> arealist= new List<areamodel>();
            arealist = GetPaginationArea(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(arealist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAreaData(string Search)
        {
            List<areamodel> arealist = new List<areamodel>();
            arealist = ElectionSettingsManager.GetAllArea().Where(x=>x.AreaTitle.Contains(Search) || x.AreaName.Contains(Search) || x.ZoneDetailsitem.ZoneName.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(arealist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Election Details
        public ActionResult GetAllElectionDetails()
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionDetailsList = ElectionSettingsManager.GetAllElectionDetails();
            return View("GetAllElectionDetails", electiondetails);
        }
        public ActionResult AddNewElectionDetails()
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionDetails= new ElectionDetailsModel();
            electiondetails.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("AddNewElectionDetails", electiondetails);
            
        }
        [HttpPost]
        public ActionResult AddNewElectionDetails(SuperAdminAndAdminViewModel electiondetailsmodel)
        {
            if (electiondetailsmodel.ElectionDetails.ElectionID > 0)
            {
                if (ElectionSettingsManager.UpdateElectionDetails(electiondetailsmodel.ElectionDetails))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    electiondetailsmodel.ElectionDetails.ElectionStatus = "Pending";
                    if (ElectionSettingsManager.AddNewElectionDetails(electiondetailsmodel.ElectionDetails))
                    {
                        ViewData["Message"] = "Your data have been Added";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewData["Message"] = "Your data have not been Added";
                    }
                }
            }
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("GetAllElectionDetails", electiondetails);
        }
        public ActionResult DeleteElectionDetails(int id)
        {
            if (id > 0)
            {
                if (ElectionSettingsManager.DeleteElectionDetails(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "Your data not have  been Deleted";
                }
            }
            SuperAdminAndAdminViewModel electiontype = new SuperAdminAndAdminViewModel();
            electiontype.ElectionDetailsList = ElectionSettingsManager.GetAllElectionDetails();
            return View("AddNewElectionType", electiontype);
        }
        public ActionResult GetSingleElectionDetails(int id)
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            if (id > 0)
            {
                electiondetails.ElectionDetails = ElectionSettingsManager.GetSingleElectionDetails(id);
                electiondetails.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            }
            return View("AddNewElectionDetails", electiondetails);
        }

        public ActionResult GetAllAssignElection()
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.AssignElectionDetails = new ElectionAssignmentModel();
            //electiondetails.ElectionDetails = ElectionSettingsManager.GetSingleElectionDetails(id);
            electiondetails.AreaList = ElectionSettingsManager.GetAllArea();
            electiondetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AssignElection", electiondetails);
        }
        // All Extra Feautures not complete
        private List<ElectionDetailsModel> GetPaginationElectionDetails(int pageindex, int pagesize)
        {
            List<ElectionDetailsModel> ElectionDetailslist = ElectionSettingsManager.GetAllElectionDetails();
            return ElectionDetailslist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountElectionDetails(int perpagedata)
        {
            List<ElectionDetailsModel> ElectionDetailslist = ElectionSettingsManager.GetAllElectionDetails();
            return Convert.ToInt32(Math.Ceiling(ElectionDetailslist.Count() / (double)perpagedata));
        }
        public List<ElectionDetailsModel> perpageshowdataElectionDetails(int pageindex, int pagesize)
        {
            List<ElectionDetailsModel> ElectionDetailslist = ElectionSettingsManager.GetAllElectionDetails();
            return ElectionDetailslist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataElectionDetails(int pageindex, int pagesize)
        {
            List<ElectionDetailsModel> ElectionDetailslist = new List<ElectionDetailsModel>();
            ElectionDetailslist = GetPaginationElectionDetails(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(ElectionDetailslist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchElectionDetailsData(string Search)
        {
            List<ElectionDetailsModel> ElectionDetailslist = new List<ElectionDetailsModel>();
            ElectionDetailslist= ElectionSettingsManager.GetAllElectionDetails().Where(x=>x.ElectionName.Contains(Search) || x.ElectionTypeDetails.ElectionName.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(ElectionDetailslist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // AssignmentElectionIDDetails
        public ActionResult GetAllAssignmentElectionIDDetails()
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionDetailsList = ElectionSettingsManager.GetAllAssingElectionDetails();
            return View("GetAllAssignmentElectionIDDetails", electiondetails);
        }
        public ActionResult AssignElection(int id)
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            if (id > 0)
            {
                electiondetails.AssignElectionDetails = new ElectionAssignmentModel();
                electiondetails.ElectionDetails = ElectionSettingsManager.GetSingleElectionDetails(id);
                electiondetails.AreaList = ElectionSettingsManager.GetAllArea();
                electiondetails.ZoneList = ElectionSettingsManager.GetAllZone();
            }
            return View("AssignElection", electiondetails);
        }
        [HttpPost]
        public ActionResult AddNewAssignElection(int[] zones, int[] areas, SuperAdminAndAdminViewModel election)
        {
            if (zones.Count() > 0 && areas.Count() > 0)
            {
                var n = 0;
                foreach (var zone in zones)
                {
                    var AsssingAreaElection = new ElectionAssignmentModel()
                    {
                        ElectionID = election.ElectionDetails.ElectionID,
                        ZoneID = zone,
                        AreaID = areas[n],
                    };
                    ElectionSettingsManager.AddNewAssignmentElectionIDDetailsElection(AsssingAreaElection);
                    n++;
                }
            }

            return View("GetAllAssignmentElectionIDDetails");
        }
        public ActionResult DeleteAssignmentElectionIDDetails(int id)
        {
            if (id > 0)
            {
                if (ElectionSettingsManager.DeleteAssingElectionDetails(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "Your data not have  been Deleted";
                }
            }
            SuperAdminAndAdminViewModel AssignElectionDetails = new SuperAdminAndAdminViewModel();
            AssignElectionDetails.ElectionDetailsList = ElectionSettingsManager.GetAllAssingElectionDetails();
            return View("GetAllAssignmentElectionIDDetails", AssignElectionDetails);
        }
        public ActionResult GetSingleAssignmentElectionIDDetails(int id)
        {
            SuperAdminAndAdminViewModel AssignElectionDetails = new SuperAdminAndAdminViewModel();
            AssignElectionDetails.ElectionDetails = ElectionSettingsManager.GetSingleElectionDetails(id);
            return View("AddNewAssignmentElectionIDDetails", AssignElectionDetails);
        }


        // All Extra Feautures not complete
        //private List<PartyModel> GetPaginationAssignmentElectionIDDetails(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}
        //private int pagecountAssignmentElectionIDDetails(int perpagedata)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        //}
        //public List<PartyModel> perpageshowdataAssignmentElectionIDDetails(int pageindex, int pagesize)
        //{
        //    List<PartyModel> partylist = PartyManager.GetAllParty();
        //    return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //}
        //public JsonResult GetpaginatiotabledataAssignmentElectionIDDetails(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
        //    party.TotalPage = pagecountElectiontype(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult SearchAssignmentElectionIDDetails(int pageindex, int pagesize)
        //{
        //    SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
        //    party.PartyList = perpageshowdataArea(pageindex, pagesize);
        //    party.TotalPage = pagecountArea(pagesize);
        //    var result = JsonConvert.SerializeObject(party);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}