using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Candidate.Voter.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}