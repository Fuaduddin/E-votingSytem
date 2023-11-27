using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Candidate.Voter.Controllers
{
    public class GiveVoteController : Controller
    {
        // GET: GiveVote
        public ActionResult GiveVote()
        {
            return View();
        }
    }
}