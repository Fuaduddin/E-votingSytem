﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoting.Models;
using Evoting.BusinessLayer;

namespace E_Voting.SuperAdmin.Admin.Controllers
{
    public class ElectionSettingsController : Controller
    {
        // GET: Election
        // Election Type
        public ActionResult Index()
        {
            SuperAdminAndAdminViewModel electiontype = new SuperAdminAndAdminViewModel();
            electiontype.ElectionType = new ElectionModel();                                                                                                                                                                                                                                         
            electiontype.ElectionTypeList = ElectionSettingsManager.GetAllElectionType();
            return View("Index", electiontype);
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
            return View("Index", electiontypeview);
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
            return View("Index", electiontype);
        }

        //Zone
        public ActionResult AddNewZone()
        {
            SuperAdminAndAdminViewModel zonedetails = new SuperAdminAndAdminViewModel();
            zonedetails.Zone = new zoneModel();
            zonedetails.ZoneList = ElectionSettingsManager.GetAllZone();
            return View("Index", zonedetails);
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
            return View("Index", zonedetails);
        }

        // Area

    }
}