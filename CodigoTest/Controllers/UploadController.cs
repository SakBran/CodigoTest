using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

namespace template.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UploadController : Controller
    {
        // GET: api/upload
        [HttpPost]
        public async Task<HttpResponseMessage> Postupload(String filename)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Request;
                var temp = HttpContext.Request.Query["file"];
                foreach (var file in httpRequest.Form.Files)
                {
                    HttpResponseMessage response =new HttpResponseMessage(HttpStatusCode.Created);


                    var postedFile = httpRequest.Form.Files[0];
                    if (postedFile != null && postedFile.Length > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1000; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".PDF",".pdf",".jpg", ".gif", ".png", ".jpeg", ".svg" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return new HttpResponseMessage(HttpStatusCode.BadRequest);
                        }
                        else if (postedFile.Length > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return new HttpResponseMessage(HttpStatusCode.BadRequest);
                        }
                        else
                        {
                            var filePath = Path.Combine("wwwroot","img",filename);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                 await file.CopyToAsync(stream);
                            }
                            

                        }
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                var res = string.Format(ex.Message.ToString());
                dict.Add("error", res);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                //return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}