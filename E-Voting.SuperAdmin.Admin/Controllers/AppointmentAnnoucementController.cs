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
using E_Voting.SuperAdmin.Admin.Extension;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class AppointmentAnnoucementController : Controller
    {
        // Global Function
        private readonly ExtensionMethods extension = new ExtensionMethods();
        private readonly GlobalCommonData constant = new GlobalCommonData();


        // GET: AppointmentAnnoucement
        public ActionResult AddNewAnnoucement()
        {
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.Annoucement=new AnnoucementModel();
            return View("AddNewAnnoucement", Annoucement);
        }
        [HttpPost]
        public ActionResult AddNewAnnoucement(SuperAdminAndAdminViewModel AnnoucementDetails, HttpPostedFileBase File)
        {
            if(File.ContentLength>0)
            {
                AnnoucementDetails.Annoucement.AnnoucementImage= extension.UploadImage(File);
            }
            if(AnnoucementDetails.Annoucement.AnnoucemntID>0)
            {
                if(AppointmentAnnoucementManager.UpdateAnnoucement(AnnoucementDetails.Annoucement))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            else
            {
                AnnoucementDetails.Annoucement.PublishedDate = DateTime.Now;
                if (AppointmentAnnoucementManager.AddNewAnnoucement(AnnoucementDetails.Annoucement))
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            AnnoucementDetails.AnnoucementList = AppointmentAnnoucementManager.GetAllAnnoucement();
            return View("GetAllAnnoucement", AnnoucementDetails);
        }
        public ActionResult GetAllAnnoucement()
        {
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.AnnoucementList = AppointmentAnnoucementManager.GetAllAnnoucement();
            return View("GetAllAnnoucement", Annoucement);
        }
        public ActionResult DeleteAnnoucement(int id)
        {
            if(id>0)
            {
                if (AppointmentAnnoucementManager.DeleteAnnoucement(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.AnnoucementList = AppointmentAnnoucementManager.GetAllAnnoucement();
            return View("GetAllAnnoucement", Annoucement);
        }
        public ActionResult GetSingleAnnoucement(int id)
        {
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.Annoucement = AppointmentAnnoucementManager.GetSingleAnnoucement(id);
            return View("AddNewAnnoucement", Annoucement);
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
        //}

        // Appointment
        public ActionResult AddNewAAppointment()
        {
            
            SuperAdminAndAdminViewModel appointment = new SuperAdminAndAdminViewModel();
            appointment.Appointment = new AppointmentAnnoucementModel();
            appointment.AppointmentSubject = constant.AppointmentSubject;
            return View("AddNewAnnoucement", appointment);
        }
        [HttpPost]
        public ActionResult AddNewAppointment(SuperAdminAndAdminViewModel Appointment)
        {
            if (Appointment.Appointment.AppointmentID > 0)
            {
                if (AppointmentAnnoucementManager.UpdateAppointment(Appointment.Appointment))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (AppointmentAnnoucementManager.AddNewAppointment(Appointment.Appointment))
                    {
                        ViewData["Message"] = "Your data have been Added ";
                        ModelState.Clear();
                        SuperAdminAndAdminViewModel AppointmentList = new SuperAdminAndAdminViewModel();
                        AppointmentList.AppointmentList = AppointmentAnnoucementManager.GetAllAppointment();
                       // RedirectToActionPermanent();
                       // return View("GetAllAnnoucement", AppointmentList);
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
                    }
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
                }
            }
            return View("GetAllAnnoucement");
        }
        public ActionResult GetAllAppointment()
        {
            SuperAdminAndAdminViewModel Appointment = new SuperAdminAndAdminViewModel();
            Appointment.AppointmentList = AppointmentAnnoucementManager.GetAllAppointment();
            return View("GetAllAppointment", Appointment);
        }
        public ActionResult DeleteAppointment(int id)
        {
            if (id > 0)
            {
                if (AppointmentAnnoucementManager.DeleteAssignmentAppointment(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel Appointment = new SuperAdminAndAdminViewModel();
            Appointment.AppointmentList = AppointmentAnnoucementManager.GetAllAppointment();
            return View("GetAllAppointment", Appointment);
        }
        public ActionResult GetSingleAAppointment(int id)
        {
            SuperAdminAndAdminViewModel Appointment = new SuperAdminAndAdminViewModel();
            Appointment.Appointment = AppointmentAnnoucementManager.GetSingleAppointment(id);
            return View("AddNewAppointment", Appointment);
        }

        // Assign to admin
        public ActionResult AddNewAssignment(int id)
        {

            SuperAdminAndAdminViewModel AssignmentAppointment = new SuperAdminAndAdminViewModel();
            AssignmentAppointment.Appointment = AppointmentAnnoucementManager.GetSingleAppointment(id);
            AssignmentAppointment.AdminList = StaffManager.GetAllAdmin();
            AssignmentAppointment.AssignemntAppointment = new AssignmentAppointment();
            return View("AddNewAssignment", AssignmentAppointment);
        }
        [HttpPost]
        public ActionResult AddNewAssignment(SuperAdminAndAdminViewModel AssignmentAppointment)
        {
            if (AssignmentAppointment.AssignemntAppointment.AssignmentID > 0)
            {
                if (AppointmentAnnoucementManager.UpdateAssignmentAppointment(AssignmentAppointment.AssignemntAppointment))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    AssignmentAppointment.AssignemntAppointment.AssignmentIssueDate= DateTime.Now;
                    AssignmentAppointment.AssignemntAppointment.AppointmentID = AssignmentAppointment.Appointment.AppointmentID;
                    AssignmentAppointment.AssignemntAppointment.AssignmentUpdate = 0;
                    if (AppointmentAnnoucementManager.AddNewAssignmentAppointment(AssignmentAppointment.AssignemntAppointment))
                    {
                        ViewData["Message"] = "Your data have been Added ";
                        ModelState.Clear();
                        SuperAdminAndAdminViewModel AssignmentAppointmentList = new SuperAdminAndAdminViewModel();
                        AssignmentAppointmentList.AssignemntAppointmentList = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
                    }
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! Error !!!!!!!!!";
                }
            }
            return View("GetAllAssignment");
        }
        public ActionResult GetAllAssignment()
        {
            SuperAdminAndAdminViewModel AssignmentAppointmentList = new SuperAdminAndAdminViewModel();
            AssignmentAppointmentList.AssignemntAppointmentList = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
            return View("GetAllAssignment", AssignmentAppointmentList);
        }
        public ActionResult DeleteAssignment(int id)
        {
            if (id > 0)
            {
                if (AppointmentAnnoucementManager.DeleteAssignmentAppointment(id))
                {
                    ViewData["Message"] = "Your data have been Deleted";
                }
                else
                {
                    ViewData["Message"] = "!!!!!!! ERROR !!!!!!!!!!";
                }
            }
            SuperAdminAndAdminViewModel AssignmentAppointmentList = new SuperAdminAndAdminViewModel();
            AssignmentAppointmentList.AssignemntAppointmentList = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
            return View("GetAllAssignment", AssignmentAppointmentList);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            SuperAdminAndAdminViewModel AssignmentAppointmentList = new SuperAdminAndAdminViewModel();
            AssignmentAppointmentList.AssignemntAppointment = AppointmentAnnoucementManager.GetSingleAssignmentAppointment(id);
            return View("AddNewAssignment", AssignmentAppointmentList);
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
        //}
    }
}