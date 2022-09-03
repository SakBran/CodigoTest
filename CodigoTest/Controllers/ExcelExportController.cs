using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using template.Data;

namespace template
{
    
    public class ExcelExportController<T>
    {
        public async Task<String> ExportToExcelAsync(List<T> dataList)
        {
            string folder = Path.Combine("Excel");
            string excelName = new Guid().ToString()+".xlsx";
            string downloadUrl = Path.Combine(folder,excelName);
            FileInfo file = new FileInfo(Path.Combine(folder, excelName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folder, excelName));
            }

            // query data from database  
            await Task.Yield();

            var list = dataList;
            
            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                list.ForEach(x=>{
                    var i=2;
                    ExcelPicture pic = workSheet.Drawings.AddPicture("pic"+(i-1).ToString(), new FileInfo(Path.Combine("Img")));
                    pic.SetPosition(i, 0, 3, 0);
                    i++;
                });
                
                package.Save();
            }

            return downloadUrl;
        }
    }
}