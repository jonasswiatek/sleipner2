﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MemcachedSharp;
using Sleipner.Cache.MemcachedSharp.MemcachedWrapper;
using SleipnerTestSite.Model.Contract;

namespace SleipnerTestSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrapService _crapService;
        
        public HomeController(ICrapService crapService)
        {
            _crapService = crapService;
        }

        public async Task<ActionResult> Index()
        {
            var data = await _crapService.GetCrapAsync();
            return Json(new { balls = data }, JsonRequestBehavior.AllowGet);
        }
    }
}