using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}