using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using JobPortal.Models;


namespace JobPortal.Repository
{
    public class JobPortalDatabase
    {
        SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQlcon"].ConnectionString);



        /// <summary>
        /// function for register the user
        /// </summary>
        /// <param name="dbjobportal"></param>
        public void Registration(DBJobPortal dbjobportal)
        {
            SqlCommand com = new SqlCommand("Sp_user", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@firstname", dbjobportal.firstname);
            com.Parameters.AddWithValue("@lastname", dbjobportal.lastname);
            com.Parameters.AddWithValue("@email", dbjobportal.email);
            com.Parameters.AddWithValue("@phone", dbjobportal.phone);
            com.Parameters.AddWithValue("@gender", dbjobportal.gender);
            com.Parameters.AddWithValue("@address", dbjobportal.address);
            com.Parameters.AddWithValue("@dateofbirth", dbjobportal.dateofbirth);
            com.Parameters.AddWithValue("@city", dbjobportal.city);
            com.Parameters.AddWithValue("@district", dbjobportal.district);
            com.Parameters.AddWithValue("@state", dbjobportal.state);
            com.Parameters.AddWithValue("@pincode", dbjobportal.pincode);
            com.Parameters.AddWithValue("@username", dbjobportal.username);
            com.Parameters.AddWithValue("@password", dbjobportal.password);
            com.Parameters.AddWithValue("@user_image", dbjobportal.user_image);
            com.Parameters.AddWithValue("@resume", dbjobportal.resume);
            com.Parameters.AddWithValue("@choice","insert");
            SqlCon.Open();
            com.ExecuteNonQuery();
            SqlCon.Close();
        }




        /// <summary>
        /// user login
        /// </summary>
        /// <param name="dbjobportal"></param>
        /// <returns></returns>
        public DataSet Login(DBJobPortal dbjobportal)
        {
            SqlCommand com = new SqlCommand("Sp_user", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", dbjobportal.username);
            com.Parameters.AddWithValue("@password", dbjobportal.password);
            com.Parameters.AddWithValue("@choice", "login");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }




        /// <summary>
        /// show user details
        /// </summary>
        /// <returns></returns>
        public DataSet Show_users()
        {
            SqlCommand com = new SqlCommand("Sp_user", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@choice", "view");
            SqlDataAdapter sqldataadapter = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            sqldataadapter.Fill(dataset);
            return dataset;

        }



        public DataSet Show_user_byid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_user", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@choice", "viewbyid");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            return dataset;
        }


        public DataSet Show_user_profile(string username)
        {
            SqlCommand com = new SqlCommand("Sp_user", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", username);
            com.Parameters.AddWithValue("@choice", "profile");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            return dataset;
        }



        public void AddJobs(Jobs jobs)
        {
            SqlCommand com = new SqlCommand("Sp_JobDetails", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@job_title", jobs.job_title);
            com.Parameters.AddWithValue("@job_description", jobs.job_description);
            com.Parameters.AddWithValue("@company_name", jobs.company_name);
            com.Parameters.AddWithValue("@location", jobs.location);
            com.Parameters.AddWithValue("@qualification", jobs.qualification);
            com.Parameters.AddWithValue("@vacancy", jobs.vacancy);
            com.Parameters.AddWithValue("@salary", jobs.salary);
            com.Parameters.AddWithValue("@experience", jobs.experience);
            com.Parameters.AddWithValue("@status", jobs.status);
            com.Parameters.AddWithValue("@start_date", jobs.start_date);
            com.Parameters.AddWithValue("@end_date", jobs.end_date);
            com.Parameters.AddWithValue("@choice","insert");
            SqlCon.Open();
            com.ExecuteNonQuery();
            SqlCon.Close();
        }



        public DataSet Show_jobs()
        {
            SqlCommand com = new SqlCommand("Sp_JobDetails", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@choice", "view");
            SqlDataAdapter sqldataadapter = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            sqldataadapter.Fill(dataset);
            return dataset;

        }


        public void delete_jobs(int id)
        {
            SqlCommand com = new SqlCommand("Sp_JobDetails", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@choice", "delete");
            com.Parameters.AddWithValue("@id", id);
            SqlCon.Open();
            com.ExecuteNonQuery();
            SqlCon.Close();
        }


        public void Update_jobs(Jobs jobs)
        {
            SqlCommand com = new SqlCommand("Sp_JobDetails", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", jobs.Id);
            com.Parameters.AddWithValue("@job_title", jobs.job_title);
            com.Parameters.AddWithValue("@job_description", jobs.job_description);
            com.Parameters.AddWithValue("@company_name", jobs.company_name);
            com.Parameters.AddWithValue("@location", jobs.location);
            com.Parameters.AddWithValue("@qualification", jobs.qualification);
            com.Parameters.AddWithValue("@vacancy", jobs.vacancy);
            com.Parameters.AddWithValue("@salary", jobs.salary);
            com.Parameters.AddWithValue("@experience", jobs.experience);
            com.Parameters.AddWithValue("@status", jobs.status);
            com.Parameters.AddWithValue("@start_date", jobs.start_date);
            com.Parameters.AddWithValue("@end_date", jobs.end_date);
            com.Parameters.AddWithValue("@choice", "update");
            SqlCon.Open();
            com.ExecuteNonQuery();
            SqlCon.Close();
        }

        public DataSet Show_jobs_byid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_JobDetails", SqlCon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@choice", "viewbyid");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            return dataset;

        }



      


    }
}