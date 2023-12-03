using Evoting.BusinessLayer;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.GlobalSetting;
using static Evoting.GlobalSetting.Enums;
using System.Configuration;

namespace Evoting.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly GlobalSettingsExtension settings = new GlobalSettingsExtension();
        private readonly GlobalCommonData CommonData = new GlobalCommonData();
        public ActionResult Login()
        {
            CustomerViewModel User= new CustomerViewModel();
            User.UserDetails=new UserModel();
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(UserModel user, string candidateoption)
        {
            if (user == null)
            {
                var UserDetails = UserDetailsUpdate(user.UserID);
                if(user.UserID== ConfigurationManager.AppSettings["SuperAdminusername"] && user.UserPassword == ConfigurationManager.AppSettings["SuperAdminUserPassword"])
                {
                    return RedirectToAction("DashBoard", "DashBoard");
                }
                else if (candidateoption== "candidate" && user.UserPassword== settings.PasswordEncrypt(UserDetails.UserPassword) && user.UserRole == Role.Candidate.ToString() && UserDetails.UserStatus== Status.Active.ToString())
                {
                    if(StaffManager.UpdateUser(UserDetails))
                    {
                        var CandidateList = StaffManager.GetAllCandidate();
                        Session["candidateDetails"] = CandidateList.Where(x => x.UserID == UserDetails.UserIDNo).FirstOrDefault();
                        return RedirectToAction("DashBoard", "Candidate"); 
                    }
                }
                else if(user.UserRole== Role.Voter.ToString() && user.UserPassword == settings.PasswordEncrypt(UserDetails.UserPassword) && UserDetails.UserStatus == Status.Active.ToString())
                {
                    if (StaffManager.UpdateUser(UserDetails))
                    {
                        var VoterList = StaffManager.GetAllVoter();
                        Session["VoterDetails"] = VoterList.Where(x => x.UserID == UserDetails.UserIDNo).FirstOrDefault();
                        return RedirectToAction("DashBoard", "Voter"); 
                    }
                }
                else if (user.UserRole == Role.Admin.ToString() && user.UserPassword == settings.PasswordEncrypt(UserDetails.UserPassword) && UserDetails.UserStatus == Status.Active.ToString())
                {
                    if (StaffManager.UpdateUser(UserDetails))
                    {
                        var AdminList = StaffManager.GetAllAdmin();
                        Session["AdminDetails"] = AdminList.Where(x => x.UserID == UserDetails.UserIDNo).FirstOrDefault();
                        return RedirectToAction("DashBoard", "Admin"); 
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            return View("Login");
        }
        private UserModel UserDetailsUpdate(string UserNID)
        { 
            var user= StaffManager.GetAllUser();
            var UserDetails=user.Where(x=> x.UserID== UserNID).FirstOrDefault();
            return new UserModel() 
            { 
                UserIDNo= UserDetails.UserIDNo,
                UserID=UserDetails.UserID,
                UserPassword= UserDetails.UserPassword,
                UserLastLogin=DateTime.Now,
                UserLastLogout=UserDetails.UserLastLogout,
                UserRole=UserDetails.UserRole,
                UserStatus=UserDetails.UserStatus,
                UserTotalLogin=UserDetails.UserTotalLogin + 1
            }; 
        }
    }
}