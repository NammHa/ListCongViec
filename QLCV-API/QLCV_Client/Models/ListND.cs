using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCV_Client.Models
{
    public class GetND
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool? isAdmin { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetListND
    {
        public List<GetND> ListND { get; set; }
    }
}