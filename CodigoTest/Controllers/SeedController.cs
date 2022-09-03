using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Data;
using Microsoft.AspNetCore.Hosting;
using WorldCities.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using template.Data;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.EntityFramework.Interfaces;
using System.Collections.Generic;

namespace WorldCities.Controllers
{
    [Route("api/Seed")]
    [ApiController]
    
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedController(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        #region  Default
        // [HttpGet]
        // public async Task<ActionResult> Import()
        // {
        //     // prevents non-development environments from running this method
        //     if (!_env.IsDevelopment())
        //         throw new SecurityException("Not allowed");

        //     var path = Path.Combine(
        //         _env.ContentRootPath,
        //         "Data/Source/worldcities.xlsx");

        //     using var stream = System.IO.File.OpenRead(path);
        //     using var excelPackage = new ExcelPackage(stream);

        //     // get the first worksheet 
        //     var worksheet = excelPackage.Workbook.Worksheets[0];

        //     // define how many rows we want to process
        //     var nEndRow = worksheet.Dimension.End.Row;

        //     // initialize the record counters 
        //     var numberOfCountriesAdded = 0;
        //     var numberOfCitiesAdded = 0;

        //     // create a lookup dictionary
        //     // containing all the countries already existing 
        //     // into the Database (it will be empty on first run).
        //     var countriesByName = _context.Countries
        //         .AsNoTracking()
        //         .ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);

        //     // iterates through all rows, skipping the first one 
        //     for (int nRow = 2; nRow <= nEndRow; nRow++)
        //     {
        //         var row = worksheet.Cells[
        //             nRow, 1, nRow, worksheet.Dimension.End.Column];

        //         var countryName = row[nRow, 5].GetValue<string>();
        //         var iso2 = row[nRow, 6].GetValue<string>();
        //         var iso3 = row[nRow, 7].GetValue<string>();

        //         // skip this country if it already exists in the database
        //         if (countriesByName.ContainsKey(countryName))
        //             continue;

        //         // create the Country entity and fill it with xlsx data 
        //         var country = new Country
        //         {
        //             Name = countryName,
        //             ISO2 = iso2,
        //             ISO3 = iso3
        //         };

        //         // add the new country to the DB context 
        //         await _context.Countries.AddAsync(country);

        //         // store the country in our lookup to retrieve its Id later on
        //         countriesByName.Add(countryName, country);

        //         // increment the counter 
        //         numberOfCountriesAdded++;
        //     }

        //     // save all the countries into the Database 
        //     if (numberOfCountriesAdded > 0) await _context.SaveChangesAsync();

        //     // create a lookup dictionary 
        //     // containing all the cities already existing 
        //     // into the Database (it will be empty on first run). 
        //     var cities = _context.Cities
        //         .AsNoTracking()
        //         .ToDictionary(x => (
        //             Name: x.Name,
        //             Lat: x.Lat,
        //             Lon: x.Lon,
        //             CountryId: x.CountryId));

        //     // iterates through all rows, skipping the first one 
        //     for (int nRow = 2; nRow <= nEndRow; nRow++)
        //     {
        //         var row = worksheet.Cells[
        //             nRow, 1, nRow, worksheet.Dimension.End.Column];

        //         var name = row[nRow, 1].GetValue<string>();
        //         var nameAscii = row[nRow, 2].GetValue<string>();
        //         var lat = row[nRow, 3].GetValue<decimal>();
        //         var lon = row[nRow, 4].GetValue<decimal>();
        //         var countryName = row[nRow, 5].GetValue<string>();

        //         // retrieve country Id by countryName
        //         var countryId = countriesByName[countryName].Id;

        //         // skip this city if it already exists in the database
        //         if (cities.ContainsKey((
        //             Name: name,
        //             Lat: lat,
        //             Lon: lon,
        //             CountryId: countryId)))
        //             continue;

        //         // create the City entity and fill it with xlsx data 
        //         var city = new City
        //         {
        //             Name = name,
        //             Name_ASCII = nameAscii,
        //             Lat = lat,
        //             Lon = lon,
        //             CountryId = countryId
        //         };

        //         // add the new city to the DB context 
        //         _context.Cities.Add(city);

        //         // increment the counter 
        //         numberOfCitiesAdded++;
        //     }

        //     // save all the cities into the Database 
        //     if (numberOfCitiesAdded > 0) await _context.SaveChangesAsync();

        //     return new JsonResult(new
        //     {
        //         Cities = numberOfCitiesAdded,
        //         Countries = numberOfCountriesAdded
        //     });
        // }

        // [HttpGet]
        // public async Task<ActionResult> CreateDefaultUsers()
        // {
        //     // setup the default role names
        //     string role_RegisteredUser = "RegisteredUser";
        //     string role_ITUser = "InformationTechnolocy";
        //     string role_OfficeUser = "Office";
        //     string role_FactoryUser = "Factory";
        //     string role_Administrator = "Administrator";

        //     // create the default roles (if they doesn't exist yet)
        //     if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));

        //     if (await _roleManager.FindByNameAsync(role_Administrator) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_Administrator));

        //     if (await _roleManager.FindByNameAsync(role_OfficeUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_OfficeUser));

        //     if (await _roleManager.FindByNameAsync(role_FactoryUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_FactoryUser));

        //     if (await _roleManager.FindByNameAsync(role_ITUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_ITUser));

        //     // create a list to track the newly added users
        //     var addedUserList = new List<ApplicationUser>();

        //     // check if the admin user already exist
        //     var email_Admin = "admin@email.com";
        //     if (await _userManager.FindByNameAsync(email_Admin) == null)
        //     {
        //         // create a new admin ApplicationUser account
        //         var user_Admin = new ApplicationUser()
        //         {
        //             SecurityStamp = Guid.NewGuid().ToString(),
        //             UserName = email_Admin,
        //             Email = email_Admin,
        //         };

        //         // insert the admin user into the DB
        //         await _userManager.CreateAsync(user_Admin, "Password!12345");

        //         // assign the "RegisteredUser" and "Administrator" roles
        //         await _userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
        //         await _userManager.AddToRoleAsync(user_Admin, role_Administrator);

        //         // confirm the e-mail and remove lockout
        //         user_Admin.EmailConfirmed = true;
        //         user_Admin.LockoutEnabled = false;

        //         // add the admin user to the added users list
        //         addedUserList.Add(user_Admin);
        //     }

        //     // check if the standard user already exist
        //     var email_User = "user@email.com";
        //     if (await _userManager.FindByNameAsync(email_User) == null)
        //     {
        //         // create a new standard ApplicationUser account
        //         var user_User = new ApplicationUser()
        //         {
        //             SecurityStamp = Guid.NewGuid().ToString(),
        //             UserName = email_User,
        //             Email = email_User
        //         };

        //         // insert the standard user into the DB
        //         await _userManager.CreateAsync(user_User, "MySecr3t$");

        //         // assign the "RegisteredUser" role
        //         await _userManager.AddToRoleAsync(user_User, role_RegisteredUser);

        //         // confirm the e-mail and remove lockout
        //         user_User.EmailConfirmed = true;
        //         user_User.LockoutEnabled = false;

        //         // add the standard user to the added users list
        //         addedUserList.Add(user_User);
        //     }

        //     // if we added at least one user, persist the changes into the DB
        //     if (addedUserList.Count > 0)
        //         await _context.SaveChangesAsync();

        //     return new JsonResult(new
        //     {
        //         Count = addedUserList.Count,
        //         Users = addedUserList
        //     });
        // }
        // #endregion


        // public async Task CreateDefaultRole()
        // {
        //     string role_RegisteredUser = "RegisteredUser";
        //     string role_ITUser = "InformationTechnolocy";
        //     string role_OfficeUser = "Office";
        //     string role_FactoryUser = "Factory";
        //     string role_Administrator = "Administrator";
        //     string role_ReportUser = "ReportUser";

        //     // create the default roles (if they doesn't exist yet)
        //     if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));

        //     if (await _roleManager.FindByNameAsync(role_Administrator) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_Administrator));

        //     if (await _roleManager.FindByNameAsync(role_OfficeUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_OfficeUser));

        //     if (await _roleManager.FindByNameAsync(role_FactoryUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_FactoryUser));

        //     if (await _roleManager.FindByNameAsync(role_ITUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_ITUser));

        //     if (await _roleManager.FindByNameAsync(role_ReportUser) == null)
        //         await _roleManager.CreateAsync(new IdentityRole(role_ReportUser));

        //     await _context.SaveChangesAsync();

        // }
        #endregion
        
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<ApiResult<userDTO>>> Get(
                int pageIndex = 0,
                int pageSize = 10,
                string sortColumn = null,
                string sortOrder = null,
                string filterColumn = null,
                string filterQuery = null)
        {
            // await CreateDefaultRole();
            // return null;
            List<ApplicationUser> userList=await _userManager.Users.ToListAsync();
            List<userDTO> users=new List<userDTO>();
            foreach(var i in userList){
                var user = await _userManager.FindByIdAsync(i.Id);
                var roles = await _userManager.GetRolesAsync(user);
                if (user == null)
                {
                    return NotFound();
                }
                var data = new userDTO();
                data.Id=user.Id;
                data.Email = user.Email;
                //var e=await _roleManager.FindByIdAsync(role.Id.ToString());
                data.role = roles != null ? roles.FirstOrDefault() : "";
                data.password = user.PasswordHash;
                users.Add(data);
                
            }
            IQueryable<userDTO> query=users.AsQueryable<userDTO>();
            
            return await ApiResult<userDTO>.CreateAsync(
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
        public async Task<ActionResult<userDTO>> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
            {
                return NotFound();
            }
            var data = new userDTO();
            data.Email = user.Email;
            //var e=await _roleManager.FindByIdAsync(role.Id.ToString());
            data.role = roles != null ? roles.FirstOrDefault() : "";
            data.password = user.PasswordHash;


            return data;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(string id, userDTO obj)
        {
            var user = await _userManager.FindByEmailAsync(obj.Email);
            var roles = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                var token = _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token.ToString(), obj.password);
                if(roles.Count!=0){
                await _userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault());
                }
                await _userManager.AddToRoleAsync(user, obj.role);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostData(userDTO data)
        {
            var addedUser = new ApplicationUser();
            var email_User = data.Email;
            var password = data.password;
            string role_Administrator = "Administrator";

            if (await _userManager.FindByNameAsync(email_User) == null)
            {
                // create a new standard ApplicationUser account
                var user_User = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_User,
                    Email = email_User
                };

                // insert the standard user into the DB
                await _userManager.CreateAsync(user_User, password);

                // assign the "RegisteredUser" role
                await _userManager.AddToRoleAsync(user_User, role_Administrator);

                // confirm the e-mail and remove lockout
                user_User.EmailConfirmed = true;
                user_User.LockoutEnabled = false;

                // add the standard user to the added users list
                addedUser = user_User;
            }

            // if we added at least one user, persist the changes into the DB
            if (addedUser != null)
                await _context.SaveChangesAsync();

            return addedUser;
        }

        // DELETE: api/Cities/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationUser>> DeleteData(userDTO obj)
        {
            var data = await _context.FindAsync<ApplicationUser>(obj.Id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
