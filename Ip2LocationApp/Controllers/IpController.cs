using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ip2LocationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ip2LocationApp.Controllers
{
    [Route("api/timezone")]
    [ApiController]
    public class IpController : Controller
    {
        private readonly DataBContext _context;

        public IpController(DataBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index([FromQuery]string ip)
        {
            if(ip == null) return NotFound();
            var ipInRange = Utils.IP2Location.IPQuery(ip);
            long str = Convert.ToInt64(ipInRange.IPNumber);
            var result = _context.Ip.Where(a => a.ip_from <= str && a.ip_to >= str)
                .Select(m => m.time_zone);
            return Ok(result);
        } 
    }
}