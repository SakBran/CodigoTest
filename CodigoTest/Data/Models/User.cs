using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoTest.Data.Models
{
    public class User
    {
         public int UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool MultiSessionEnable { get; set; }
        public short Status { get; set; }
    }
}