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
    public class ElectionSettingsController : Controller
    {
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        // GET: Election

        // Election Type
        public ActionResult AddNewElectionType()
        {
            SuperAdminAndAdminViewModel electiontype = new SuperAdminAndAdminViewModel();
            electiontype.ElectionType = new ElectionModel();
            electiontype.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("AddNewElectionType", electiontype);
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
            SuperAdminAndAdminViewModel electiontypeview = new SuperAdminAndAdminViewModel();
            electiontypeview.ElectionType = new ElectionModel();
            electiontypeview.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("AddNewElectionType", electiontypeview);
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
            electiontype.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("AddNewElectionType", electiontype);
        }


        // All Extra Feautures not complete
        private List<PartyModel> GetPaginationElectiontype(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountElectiontype(int perpagedata)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        }
        public List<PartyModel> perpageshowdataElectiontype(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult GetpaginatiotabledataElectiontype(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
            party.TotalPage = pagecountElectiontype(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchElectionTypeData(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataArea(pageindex, pagesize);
            party.TotalPage = pagecountArea(pagesize);
            var result = JsonConvert.SerializeObject(party);
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
            Areadetails.AreaList = ElectionSettingsManager.GetAllArea();
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
                 //   area.Zones = (zoneModel)ElectionSettingsManager.GetSingleZone(area.ZoneID);
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
        
            areadetails.Area = new areamodel();
            areadetails.AreaList = ElectionSettingsManager.GetAllArea();
            areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", areadetails);
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
            SuperAdminAndAdminViewModel areadetails = new SuperAdminAndAdminViewModel();
            areadetails.Area = new areamodel();
            areadetails.AreaList = ElectionSettingsManager.GetAllArea();
            areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", areadetails);
        }
        public ActionResult GetSingleArea(int id)
        {
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = ElectionSettingsManager.GetSingleArea(id);
            Areadetails.AreaList = ElectionSettingsManager.GetAllArea();
            Areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }

        // All Extra Feautures not complete
        private List<PartyModel> GetPaginationArea(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountArea(int perpagedata)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        }
        public List<PartyModel> perpageshowdataArea(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult GetpaginatiotabledataArea(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataArea(pageindex, pagesize);
            party.TotalPage = pagecountArea(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAreaData(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataArea(pageindex, pagesize);
            party.TotalPage = pagecountArea(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Election Details
        public ActionResult AddNewElectionDetails()
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionDetails= new ElectionDetailsModel();
            electiondetails.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
           // electiondetails.AreaList = ElectionSettingsManager.GetAllArea();
           // electiondetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewElectionDetails", electiondetails);
            
        }
        [HttpPost]
        public ActionResult AddNewElectionDetails(ElectionDetailsModel electiondetailsmodel)
        {
            SuperAdminAndAdminViewModel electiondetails = new SuperAdminAndAdminViewModel();
            electiondetails.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
          //  electiondetails.AreaList = ElectionSettingsManager.GetAllArea();
            electiondetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewElectionDetails", electiondetails);

        }
        public ActionResult DeleteElectionDetails(int id)
        {
            if (id > 0)
            {
                if (ElectionSettingsManager.DeleteElectionType(id))
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
            electiontype.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("AddNewElectionType", electiontype);
        }
        public ActionResult GetSingleElectionDetails(int id)
        {
            SuperAdminAndAdminViewModel Areadetails = new SuperAdminAndAdminViewModel();
            Areadetails.Area = ElectionSettingsManager.GetSingleArea(id);
            Areadetails.AreaList = ElectionSettingsManager.GetAllArea();
            Areadetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("AddNewArea", Areadetails);
        }


        // All Extra Feautures not complete
        private List<PartyModel> GetPaginationElectionDetails(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountElectionDetails(int perpagedata)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        }
        public List<PartyModel> perpageshowdataElectionDetails(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataElectionDetails(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataElectiontype(pageindex, pagesize);
            party.TotalPage = pagecountElectiontype(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchElectionDetailsData(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdataArea(pageindex, pagesize);
            party.TotalPage = pagecountArea(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}