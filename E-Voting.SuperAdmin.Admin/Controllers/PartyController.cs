using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.BusinessLayer;
using Newtonsoft.Json;
using Evoting.GlobalSetting;
using E_Voting.SuperAdmin.Admin.Extension;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class PartyController : Controller
    {
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        private readonly ExtensionMethods extension = new ExtensionMethods();
        // GET: Party
        public ActionResult AddNewParty()
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.Party = new PartyModel();
            party.PartyList = perpageshowdata(1, 10);
            party.TotalPage = pagecount(10);
            return View("AddNewParty", party);
        }
        [HttpPost]
        public ActionResult AddNewParty(PartyModel partyModel, HttpPostedFileBase File)
        {
            if(partyModel.PartyID>0)
            {
                if(File.ContentLength>0)
                {
                    partyModel.PartySymbol = extension.UploadImage(File);
                }
                if(PartyManager.UpdateParty(partyModel))
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
                if(File.ContentLength > 0) { partyModel.PartySymbol = extension.UploadImage(File); }
                if(ModelState.IsValid)
                {
                   
                    if (PartyManager.AddNewParty(partyModel))
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
                    ViewData["Message"] = "Error !!!!!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.Party = new PartyModel();
            party.PartyList = perpageshowdata(1, 10);
            party.TotalPage = pagecount(10);
            return View("AddNewParty", party);
        }
        public ActionResult GetSingleParty(int id)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            if(id>0)
            {
                party.Party = PartyManager.GetSingleParty(id);
            }
            party.Party = new PartyModel();
            party.PartyList = perpageshowdata(1, 10);
            party.TotalPage = pagecount(10);
            return View("AddNewParty");
        }
        public ActionResult DeleteParty(int id)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            if (PartyManager.DeleteParty(id))
            {
                ViewData["Message"] = "Your data have  been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not  been Deleted";
            }
            party.Party = new PartyModel();
            party.PartyList = perpageshowdata(1, 10);
            party.TotalPage = pagecount(10);
            return View("AddNewParty");
        }
        // All Extra Feauture
        private List<PartyModel> GetPaginationParty(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecount(int perpagedata)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return Convert.ToInt32(Math.Ceiling(partylist.Count() / (double)perpagedata));
        }
        public List<PartyModel> perpageshowdata(int pageindex, int pagesize)
        {
            List<PartyModel> partylist = PartyManager.GetAllParty();
            return partylist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            SuperAdminAndAdminViewModel party = new SuperAdminAndAdminViewModel();
            party.PartyList = perpageshowdata(pageindex, pagesize);
            party.TotalPage = pagecount(pagesize);
            var result = JsonConvert.SerializeObject(party);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}