using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Ip2LocationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Dapper;
using System.Data;

namespace Ip2LocationApp.Controllers
{
    [Route("api/timezone")]
    [ApiController]
    [ResponseCache(Duration = 30)]
    public class IpController : Controller
    {
        private readonly IPRepository _pRepository;
        private readonly DataBContext _context;
        private IMemoryCache _memoryCache;

        public IpController(DataBContext context, IMemoryCache memoryCache, IPRepository pRepository)
        {
            _context = context;
            _memoryCache = memoryCache;
            _pRepository = pRepository;
        }

        public async Task<IActionResult> Index([FromQuery]string ip)
        {           
            if (ip == null) return NotFound();
            if (_memoryCache.TryGetValue(ip, out string currentTime)) return Ok(currentTime);                      
            var res = await _pRepository.GetAll(ip);
            if (res == null) return NotFound();
            currentTime = res.FirstOrDefault().time_zone;
            _memoryCache.Set(ip, currentTime, new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(24)));
            return Ok(currentTime);
        }
    }
}