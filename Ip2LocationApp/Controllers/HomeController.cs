using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ip2LocationApp.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ip2LocationApp.Controllers
{
    public class HomeController : Controller
    {
        private static IP2Location.Component oIP2Location = null;
        public override void OnActionExecuting(ActionExecutingContext requestContext)
        {
            if (oIP2Location == null)
            {
                oIP2Location = new IP2Location.Component
                {
                    IPLicensePath = @"C:\Users\ASUS\source\repos\Ip2LocationApp\Ip2LocationApp\wwwroot\license.key",
                    IPDatabasePath = @"C:\Users\ASUS\source\repos\Ip2LocationApp\Ip2LocationApp\wwwroot\IP2LOCATION-LITE-DB11.BIN"
                };
            }
            base.OnActionExecuting(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult Index(Models.IPParam IPParam)
        {
            ViewBag.Message = "IP2Location query page.";

            IPParam.oIPResult = new IP2Location.IPResult();

            IPParam.oIPResult = oIP2Location.IPQuery(IPParam.IP);

            return View(IPParam);
        }
    }
}
