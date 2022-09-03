using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using template.Interface;
using template.Data.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController<T> : ControllerBase where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly LogInterface _log;
        private readonly IQueryable<T> _query;



        public BaseAPIController(ApplicationDbContext context, LogInterface log)
        {
            _context = context;
            _query = context.Set<T>();
            _log = log;

        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<T>>> Get(
                  int pageIndex = 0,
                  int pageSize = 10,
                  string sortColumn = null,
                  string sortOrder = null,
                  string filterColumn = null,
                  string filterQuery = null)
        {

            var query = _query;
            return await ApiResult<T>.CreateAsync(
                    query,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        //GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id)
        {
            var data = await _context.FindAsync<T>(id);
            if (data == null)
            {
                return NotFound();
            }
            
            return data;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(string id ,T obj)
        {
        
            var oldData = await _context.FindAsync<T>(id);
            var newData = obj;
            await _log.LogPut(oldData,newData);
            _context.Entry(oldData).State = EntityState.Detached;
            _context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

       
        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<T>> PostData(T data)
        {

            await _context.AddAsync(data);
            await _log.LogPost(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetData", new { }, data);
        }

        [Authorize]
        [HttpPost]
        [Route("PostDataList")]
        public async Task<ActionResult<T>> PostDataList(List<T> data)
        {

            await _context.AddRangeAsync(data);
            await _log.LogPost(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetData", new { }, data);
        }

        // DELETE: api/Cities/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> DeleteData(string id)
        {
            var temp = await _context.FindAsync<T>(id);
            if (temp == null)
            {
                return NotFound();
            }
            await _log.LogDelete(temp);
            _context.Remove(temp);
            
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}