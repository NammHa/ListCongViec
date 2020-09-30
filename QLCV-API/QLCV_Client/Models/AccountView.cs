using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCV_Client.Models
{
    public class AccountView
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string issued { get; set; }
        public string expires { get; set; } 
    }

}