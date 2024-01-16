using Evoting.BusinessLayer;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class VotingSettingsController : Controller
    {
        // GET: VotingSettings
        public ActionResult ElectionVotingResult()
        {
            SuperAdminAndAdminViewModel ElectionResultDetails = new SuperAdminAndAdminViewModel();
            ElectionResultDetails.ElectionResult = GiveVoteManager.ElectionResultDetails(1);
            return View("ElectionVotingResult", ElectionResultDetails);
        }
        //public ActionResult ElectionVotingResult(int ElectionID)
        //{
        //    SuperAdminAndAdminViewModel ElectionResultDetails = new SuperAdminAndAdminViewModel();
        //    if (ElectionID < 0)
        //    {
        //        ElectionResultDetails.ElectionResultDetails = GiveVoteManager.ElectionResultDetails(ElectionID);
        //    }
        //    return View("ElectionVotingResult", ElectionResultDetails);
        //}

        [HttpPost]
        public ActionResult ElectionVotingResult(SuperAdminAndAdminViewModel VotingResult)
        {
            return View();
        }
    }
}