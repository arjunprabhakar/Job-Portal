using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        Repository.JobPortalDatabase dbrepository = new Repository.JobPortalDatabase();
      
        
        
        /// <summary>
        /// Common index page for the job portal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// User index page
        /// </summary>
        /// <returns></returns>
        public ActionResult UserIndex()
        {

            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username; 
                return View(); 
            }
            else
            {
                return RedirectToAction("User_login","Authentication");
            }
        }

        /// <summary>
        /// User index page
        /// </summary>
        /// <returns></returns>
        public ActionResult UserProfile()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                DataSet dataset = dbrepository.Show_user_profile(username);
                ViewBag.user = dataset.Tables[0];
                return View();
            }
            else
            {
                return RedirectToAction("User_login", "Authentication");
            }
        }



        public ActionResult UserJobsView()
        {

            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                DataSet dataset = dbrepository.Show_jobs();
                ViewBag.emp = dataset.Tables[0];
                return View();
            }
            else
            {
                return RedirectToAction("User_login", "Authentication");
            }
        }







 







        /// <summary>
        /// Admin index page
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminIndex()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username; 
                return View();
            }
            else
            {
                return RedirectToAction("User_login", "Authentication");
            }
        }






        /// <summary>
        /// Function for add new jobs
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminAddJobs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAddJobs(FormCollection formcollection )
        {
            Jobs jobs = new Jobs();
            jobs.job_title = formcollection["job_title"];
            jobs.job_description = formcollection["job_description"];
            jobs.company_name = formcollection["job_company"];
            jobs.location = formcollection["job_location"];
            jobs.qualification = formcollection["job_qualification"];
            jobs.vacancy = formcollection["job_vacancy"];
            jobs.salary = formcollection["job_salary"];
            jobs.experience = formcollection["job_experience"];
            jobs.start_date = formcollection["job_startdate"];
            jobs.end_date = formcollection["job_enddate"];
            dbrepository.AddJobs(jobs);
            TempData["msg"] = "Job addedd successfully";
            return View();
        }




        /// <summary>
        /// Admin Can View The Added jobs
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminViewJobs()
        {
            DataSet dataset = dbrepository.Show_jobs();
            ViewBag.emp = dataset.Tables[0];
            return View();
        }



        /// <summary>
        /// function for delete the jobs
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDeleteJobs(int id)
        {
            dbrepository.delete_jobs(id);
            TempData["msg"] = "Job deleted";
            return RedirectToAction("AdminViewJobs");

        }

        
        /// <summary>
        /// Function for update the jobs
        /// </summary>
        /// <param name="Empid"></param>
        /// <returns></returns>
        public ActionResult AdminUpdateJobs(int id)
        {
            DataSet dataset = dbrepository.Show_jobs_byid(id);
            ViewBag.jobrecord = dataset.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult AdminUpdateJobs(int id, FormCollection formcollection)
        {
            Jobs jobs = new Jobs();
            jobs.Id = id;
            jobs.job_title = formcollection["job_title"];
            jobs.job_description = formcollection["job_description"];
            jobs.company_name = formcollection["job_company"];
            jobs.location = formcollection["job_location"];
            jobs.qualification = formcollection["job_qualification"];
            jobs.vacancy = formcollection["job_vacancy"];
            jobs.salary = formcollection["job_salary"];
            jobs.experience = formcollection["job_experience"];
            jobs.start_date = formcollection["job_startdate"];
            jobs.end_date = formcollection["job_enddate"];
            dbrepository.Update_jobs(jobs);
            TempData["msg"] = "Updated";
            return RedirectToAction("AdminViewJobs");

        }


        /// <summary>
        /// Admin can the details of the registerd users list
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminViewUsers()
        {
            DataSet dataset = dbrepository.Show_users();
            ViewBag.user = dataset.Tables[0];
            return View();
        }


        /// <summary>
        /// Admin can view the user details
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminViewUsersDetails(int id)
        {
            DataSet dataset = dbrepository.Show_user_byid(id);
            ViewBag.user = dataset.Tables[0];
            return View();
        }





















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}