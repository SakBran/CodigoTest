using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using template.Data;
using template.Data.Models;
using template.Interface;
using WorldCities.Data;
using WorldCities.Data.Models;

namespace template.Controllers
{
    [ApiController]
    [Route("api/Logs")]
    public class LogsController : BaseAPIController<LogModel>
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<LogModel> _query;
        private readonly LogInterface _log;
        
      
        public LogsController(ApplicationDbContext context, LogInterface log) : base(context, log)
        {
            _context = context;
            //var userQuery = _userManager.Users;
            // var logQuery = _context.LogModels;
            // var query = from user in userQuery
            //           join logs in logQuery on user.Id equals logs.user
            //           select (new LogModelDTO
            //           {
            //               logData = logs,
            //               userData = user
            //           });
            _query = _context.LogModels;
            _log = log;
        }

        // [HttpGet("{id}")]
        // public new async Task<ActionResult<LogModelDTO>> Get(string id)
        // {
        //     var data = await _query.Where(x=>x.logData.logId==id).FirstOrDefaultAsync();
        //     if (data == null)
        //     {
        //         return NotFound();
        //     }
            
        //     return data;
        // }
    }

}