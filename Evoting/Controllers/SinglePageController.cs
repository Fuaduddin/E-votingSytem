using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evoting.Controllers
{
    public class SinglePageController : Controller
    {
        // GET: SinglePage
        public ActionResult SinglePageAnnoucement(int id)
        {
            return View();
        }
    }
}