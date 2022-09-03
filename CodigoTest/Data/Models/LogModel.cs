using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace template.Data.Models
{
    public class LogModel
    {
        [Key]
        //[MaxLength(100)]
        public string logId { get; set; }
        public string logTable { get; set; }
        public string logOldData { get; set; }
        public string logNewData { get; set; }
        public string user { get; set; }
        public DateTime createdDate { get; set; }

    }
}