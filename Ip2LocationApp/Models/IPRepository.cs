using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationApp.Models
{
    public interface IPRepository
    {
        Task<IEnumerable<ip2location_db11>> GetAll([FromQuery]string ip);
    }
}
