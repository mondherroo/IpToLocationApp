using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ip2LocationApp.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data.SqlClient;

namespace Ip2LocationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private DataBContext dataBContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private static IP2Location.Component oIP2Location = null;
        public HomeController(IConfiguration config, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DataBContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            dataBContext = db;
            _config = config;
        }
        
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
            IPParam.oIPResult = oIP2Location.IPQuery(IPParam.IP);           
            long str = Convert.ToInt64(IPParam.oIPResult.IPNumber);
            var timezone =  dataBContext.Ip.Where(a => a.ip_from <= str && a.ip_to >= str).Select(x=>x.time_zone).FirstOrDefault();
            return Ok(timezone);
        }
               
    }
}
