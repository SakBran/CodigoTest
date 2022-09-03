using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using template.Controllers;
using template.Data.Models;
using template.Interface;
using WorldCities.Data;

namespace medicalsoftware.Controllers
{
    [ApiController]
    [Route("api/Medical")]
    [AllowAnonymous]
    public class MedicalController : BaseAPIController<MedicalRecord>
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<MedicalRecord> _query;
        private readonly LogInterface _log;
        
        public MedicalController(ApplicationDbContext context,LogInterface log):base(context,log)
        {
            _context = context;
            _query=_context.MedicalRecords;
            _log=log;
        }
    }
}