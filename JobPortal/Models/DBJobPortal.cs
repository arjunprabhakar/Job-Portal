using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class DBJobPortal
    {
        public int Id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String gender { get; set; }
        public String dateofbirth { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String district { get; set; }
        public String state { get; set; }
        public String pincode { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String user_image { get; set; }
        public String resume { get; set; }

        public String choice { get; set; }
    }
}