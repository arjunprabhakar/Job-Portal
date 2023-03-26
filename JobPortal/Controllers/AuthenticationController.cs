using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Data;
using System.IO;

namespace JobPortal.Controllers
{
    public class AuthenticationController : Controller

    {
        Repository.JobPortalDatabase dbrepository = new Repository.JobPortalDatabase();

        // GET: Authentication
        public ActionResult User_Registraion()
        {
            return View();
        }


        [HttpPost]
        public ActionResult User_Registraion(FormCollection formcollection, HttpPostedFileBase image,HttpPostedFileBase resume)
        {
            DBJobPortal dbjobPortal = new DBJobPortal();
            dbjobPortal.firstname = formcollection["firstname"];
            dbjobPortal.lastname = formcollection["lastname"];
            dbjobPortal.email = formcollection["email"];
            dbjobPortal.phone = formcollection["phone"];
            dbjobPortal.gender = formcollection["gender"];
            dbjobPortal.dateofbirth = formcollection["dateofbirth"];
            dbjobPortal.address = formcollection["address"];
            dbjobPortal.city = formcollection["city"];
            dbjobPortal.district = formcollection["district"];
            dbjobPortal.state = formcollection["state"];
            dbjobPortal.pincode = formcollection["pin"];
            dbjobPortal.username = formcollection["username"];
            dbjobPortal.password = formcollection["password"];

            if (image != null && image.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads/images/"), fileName);
                image.SaveAs(path);
                dbjobPortal.user_image = "~/uploads/images/" + fileName;
            }
            if (resume != null && resume.ContentLength > 0)
            {
                var fileName = Path.GetFileName(resume.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads/resume/"), fileName);
                resume.SaveAs(path);
                dbjobPortal.resume = "~/uploads/resume/" + fileName;
            }

            dbrepository.Registration(dbjobPortal);
            TempData["msg"] = "Inserted";
            return View();
        }


        /// <summary>
        /// function for user login
        /// </summary>
        /// <returns></returns>
        public ActionResult User_login()
        {
            Session["username"] = null;
            return View();
        }


        /// <summary>
        /// User login function
        /// </summary>
        /// <param name="formcollection"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult User_login(FormCollection formcollection)
        {

            DBJobPortal dbjobPortal = new DBJobPortal();
            dbjobPortal.username = formcollection["username"];
            dbjobPortal.password = formcollection["password"];
            int count;
            Session["Username"] = null;
            if (dbjobPortal.username == "admin" && dbjobPortal.password == "admin")
            {
                Session["username"] = "admin";
                return RedirectToAction("AdminIndex","Home");
            }
            DataSet dataset = dbrepository.Login(dbjobPortal);
            count = dataset.Tables[0].Rows.Count;

            ViewBag.login = dataset.Tables[0];


            if (count == 1)
            {
                Session["username"] = dataset.Tables[0].Rows[0]["username"];
                TempData["msg"] = " login Successfully";
                return RedirectToAction("UserIndex","Home");
            }
            else
            {
                TempData["msg"] = "Invalid username or password";
                return View();
            }

        }



        /// <summary>
        /// function for logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index","Home");
        }





        // GET: Authentication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authentication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authentication/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authentication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authentication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authentication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authentication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
