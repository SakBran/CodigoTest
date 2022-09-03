using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using template.Data.Models;
using template.Interface;
using WorldCities.Data;

namespace template.Services
{
    public class LogServices : LogInterface
    {

        private readonly ApplicationDbContext _context;
        private IHttpContextAccessor _httpContextAccessor;


        public LogServices(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task save(LogModel data)
        {
            await _context.LogModels.AddAsync(data);
            //await _context.SaveChangesAsync();
        }

        public async Task LogPost(object oldData)
        {
                var newData ="New" ;
                LogModel logData = new LogModel();
                logData.logOldData = JsonSerializer.Serialize(oldData);
                logData.logNewData = newData;
                logData.logId = Guid.NewGuid().ToString();
                logData.createdDate = DateTime.Now;
                logData.logTable = oldData.GetType().ToString();
                logData.user =_httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;
                await save(logData);
        }

        public async Task LogPut(object oldData, object newData)
        {
            LogModel logData = new LogModel();
            logData.logOldData = JsonSerializer.Serialize(oldData);
            logData.logNewData = JsonSerializer.Serialize(newData);
            logData.logId = Guid.NewGuid().ToString();
            logData.createdDate = DateTime.Now;
            logData.logTable = newData.GetType().ToString();
            logData.user =_httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;
            await save(logData);
        }

        public async Task LogDelete(object oldData)
        {
                var newData ="Deleted" ;
                LogModel logData = new LogModel();
                logData.logOldData = JsonSerializer.Serialize(oldData);
                logData.logNewData = newData;
                logData.logId = Guid.NewGuid().ToString();
                logData.createdDate = DateTime.Now;
                logData.logTable = oldData.GetType().ToString();
                logData.user =_httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;
                await save(logData);
        }
    }

}