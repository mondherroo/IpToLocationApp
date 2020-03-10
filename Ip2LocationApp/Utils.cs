using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationApp
{
    public class Utils
    {
        public static IP2Location.Component IP2Location = new IP2Location.Component
        {
            IPLicensePath = @"C:\Users\Administrator\Desktop\Ip2locAp\IpToLocationApp\Ip2LocationApp\wwwroot\license.key",
            IPDatabasePath = @"D:\TempsDocker\IP2LOCATION-LITE-DB11.BIN"
        };
    }
}
