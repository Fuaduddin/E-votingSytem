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
    [Authorize]
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
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.AnnoucementList = GetPaginationAnnoucement(1, 10);
            Annoucement.TotalPage = pagecountAnnoucement(10);
            return View("GetAllAnnoucement", AnnoucementDetails);
        }
        public ActionResult GetAllAnnoucement()
        {
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.AnnoucementList = GetPaginationAnnoucement(1,10);
            Annoucement.TotalPage = pagecountAnnoucement(10);
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
            Annoucement.AnnoucementList = GetPaginationAnnoucement(1, 10);
            Annoucement.TotalPage = pagecountAnnoucement(10);
            return View("GetAllAnnoucement", Annoucement);
        }
        public ActionResult GetSingleAnnoucement(int id)
        {
            SuperAdminAndAdminViewModel Annoucement = new SuperAdminAndAdminViewModel();
            Annoucement.Annoucement = AppointmentAnnoucementManager.GetSingleAnnoucement(id);
            return View("AddNewAnnoucement", Annoucement);
        }
        private List<AnnoucementModel> GetPaginationAnnoucement(int pageindex, int pagesize)
        {
            List<AnnoucementModel> Annoucementlist = AppointmentAnnoucementManager.GetAllAnnoucement();
            return Annoucementlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountAnnoucement(int perpagedata)
        {
            List<AnnoucementModel> Annoucementlist = AppointmentAnnoucementManager.GetAllAnnoucement();
            return Convert.ToInt32(Math.Ceiling(Annoucementlist.Count() / (double)perpagedata));
        }
        public JsonResult GetpaginatiotabledataAnnoucement(int pageindex, int pagesize)
        {
            List<AnnoucementModel> Annoucementlist= new List<AnnoucementModel>();
            Annoucementlist = GetPaginationAnnoucement(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(Annoucementlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAnnoucement(string Search)
        {
            List<AnnoucementModel> Annoucementlist = new List<AnnoucementModel>();
            Annoucementlist = AppointmentAnnoucementManager.GetAllAnnoucement().Where(x=>x.AnnoucementTitle.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(Annoucementlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

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
            SuperAdminAndAdminViewModel AppointmentList = new SuperAdminAndAdminViewModel();
            AppointmentList.AppointmentList = GetPaginationAppointment(1, 10);
            AppointmentList.TotalPage = pagecountAppointment(10);
            return View("GetAllAnnoucement", AppointmentList);
        }
        public ActionResult GetAllAppointment()
        {
            SuperAdminAndAdminViewModel Appointment = new SuperAdminAndAdminViewModel();
            Appointment.AppointmentList = GetPaginationAppointment(1, 10);
            Appointment.TotalPage = pagecountAppointment(10);
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
            Appointment.AppointmentList = GetPaginationAppointment(1,10);
            Appointment.TotalPage = pagecountAppointment(10);
            return View("GetAllAppointment", Appointment);
        }
        public ActionResult GetSingleAAppointment(int id)
        {
            SuperAdminAndAdminViewModel Appointment = new SuperAdminAndAdminViewModel();
            Appointment.Appointment = AppointmentAnnoucementManager.GetSingleAppointment(id);
            return View("AddNewAppointment", Appointment);
        }
        // All Extra Feautures not complete
        private List<AppointmentAnnoucementModel> GetPaginationAppointment(int pageindex, int pagesize)
        {
            List<AppointmentAnnoucementModel> Appointmentlist = AppointmentAnnoucementManager.GetAllAppointment();
            return Appointmentlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountAppointment(int perpagedata)
        {
            List<AppointmentAnnoucementModel> Appointmentlist = AppointmentAnnoucementManager.GetAllAppointment();
            return Convert.ToInt32(Math.Ceiling(Appointmentlist.Count() / (double)perpagedata));
        }

        public JsonResult GetpaginatiotabledataAppointment(int pageindex, int pagesize)
        {
            List<AppointmentAnnoucementModel> Appointmentlist = new List<AppointmentAnnoucementModel>();
            Appointmentlist = GetPaginationAppointment(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(Appointmentlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAppointment(string Search)
        {
            List<AppointmentAnnoucementModel> Appointmentlist = new List<AppointmentAnnoucementModel>();
            Appointmentlist = AppointmentAnnoucementManager.GetAllAppointment().Where(x=>x.AppointmentSubject.Contains(Search) 
             || x.CustomerName.Contains(Search) || x.UserEmaul.Contains(Search) || x.UserPhoneNumber.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(Appointmentlist);
            return Json(result, JsonRequestBehavior.AllowGet);
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
            AssignmentAppointmentList.AssignemntAppointmentList = GetPaginationAssignAppointment(1, 10);
            AssignmentAppointmentList.TotalPage = pagecountAssignAppointment(10);
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
            AssignmentAppointmentList.AssignemntAppointmentList = GetPaginationAssignAppointment(1,10);
            AssignmentAppointmentList.TotalPage = pagecountAssignAppointment(10);
            return View("GetAllAssignment", AssignmentAppointmentList);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            SuperAdminAndAdminViewModel AssignmentAppointmentList = new SuperAdminAndAdminViewModel();
            AssignmentAppointmentList.AssignemntAppointment = AppointmentAnnoucementManager.GetSingleAssignmentAppointment(id);
            return View("AddNewAssignment", AssignmentAppointmentList);
        }

        // All Extra Feautures not complete
        private List<AssignmentAppointment> GetPaginationAssignAppointment(int pageindex, int pagesize)
        {
            List<AssignmentAppointment> AssignAppointmentlist = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
            return AssignAppointmentlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        private int pagecountAssignAppointment(int perpagedata)
        {
            List<AssignmentAppointment> AssignAppointmentlist = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
            return Convert.ToInt32(Math.Ceiling(AssignAppointmentlist.Count() / (double)perpagedata));
        }
        public List<AssignmentAppointment> perpageshowdataAssignAppointment(int pageindex, int pagesize)
        {
            List<AssignmentAppointment> AssignAppointmentlist = AppointmentAnnoucementManager.GetAllAssignmentAppointment();
            return AssignAppointmentlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult GetpaginatiotabledataAssignAppointment(int pageindex, int pagesize)
        {
            List<AssignmentAppointment> AssignAppointmentlist = new List<AssignmentAppointment>();
            AssignAppointmentlist = GetPaginationAssignAppointment(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(AssignAppointmentlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchAssignAppointment(string Search)
        {
            List<AssignmentAppointment> AssignAppointmentlist = new List<AssignmentAppointment>();
            AssignAppointmentlist = AppointmentAnnoucementManager.GetAllAssignmentAppointment().Where(x=>x.Admin.AdminName.Contains(Search)
            || x.Appointment.AppointmentSubject.Contains(Search)).ToList();
            var result = JsonConvert.SerializeObject(AssignAppointmentlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}