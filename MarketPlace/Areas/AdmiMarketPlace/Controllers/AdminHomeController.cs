﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Areas.AdmiMarketPlace.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdmiMarketPlace/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}