using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationApp.Models
{
    public class PRepository : IPRepository
    {
        private readonly ConnectionString _connectionString;

        public PRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ip2location_db11>> GetAll([FromQuery]string ip)
        {
            var ipInRange = Utils.IP2Location.IPQuery(ip);
            var str = Convert.ToInt64(ipInRange.IPNumber);
            string query = $"SELECT * FROM ip2location_db11 where (ip_from <= {str} AND ip_to >= {str})";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<ip2location_db11>(query);
                return result;
            }
        }
    }
}
