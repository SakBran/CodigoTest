using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data.Models;

namespace template.Data
{
    public class userDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string role { get; set; }
        public string password { get; set; }
    }
}