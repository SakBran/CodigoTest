using System;
using System.Linq;
using WorldCities.Data;
using template.Data;
using template.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using template.Interface;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace template.Services
{
    public class CommonService : ICommonService
    {
        private readonly ApplicationDbContext _context;
        public CommonService(ApplicationDbContext context)
        {
            _context = context;
        }
    
    }

}