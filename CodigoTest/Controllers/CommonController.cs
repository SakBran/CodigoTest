using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace template.Controllers
{
    //Case when current User ID is required
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private IHttpContextAccessor _httpContextAccessor;


        public CommonController(ILogger<CommonController> logger,IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
             _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
                 
        {
            var userId="";
            await Task.Run(()=>{
                userId=_httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;
            });
            return userId;
        }

    }
}