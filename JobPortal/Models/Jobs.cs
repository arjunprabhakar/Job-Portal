using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public String job_title { get; set; }
        public String job_description { get; set; }
        public String company_name { get; set; }
        public String location { get; set; }
        public String qualification { get; set; }
        public String vacancy { get; set; }
        public String salary { get; set; }
        public String experience { get; set; }
        public int status { get; set; }
        public String start_date { get; set; }
        public String end_date { get; set; }
        public String choice { get; set; }
    }
}