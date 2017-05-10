using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RxOutlet.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace RxOutlet.Controllers
{
    public class ContactUSController : Controller
    {
        public ActionResult ContactUS()
        {
            ContactUsModel objSubjectHeading = new ContactUsModel();
            objSubjectHeading.SubjectHeading = PopulateSubjectHeading();
            return View(objSubjectHeading);

          
        }


        // Calling on http post (on Submit)
        [HttpPost]
        public ActionResult ContactUS(ContactUsModel obj)
        {

            //obj.SubjectHeading = PopulateSubjectHeading();
            //var selectedItem = obj.SubjectHeading.Find(p => p.Value == obj.SubjectHeadingID.ToString());
            //if (selectedItem != null)
            //{
            //    selectedItem.Selected = true;
            //    ViewBag.Message = "SubjectHeading: " + selectedItem.Text;  
            //}


            int strDDLValue = Convert.ToInt32(Request.Form["ddlVendor"]);
            List<SelectListItem> dd = PopulateSubjectHeading();

            obj.SubjectHeadingName = dd[strDDLValue].Text.ToString();


            ContactUsModel objreg = new ContactUsModel();
            string result = objreg.InsertRegDetails(obj);
            ViewData["result"] = result;
            ModelState.Clear();

            return View(obj);




        }



        private static List<SelectListItem> PopulateSubjectHeading()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string constr = ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-DDIP9VH\\SQLEXPRESS;Initial Catalog=RxOutlet;Persist Security Info=True;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("GetSubjectHeading", con);
            cmd.CommandType = CommandType.StoredProcedure;        
            con.Open();
                     
            using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["SubjectHeadingName"].ToString(),
                                Value = sdr["SubjectHeadingID"].ToString()
                            });
                        }
                    }
                    con.Close();

            return items;
        }
            }

          
        }





        //[HttpPost]
        //public ActionResult ContactUS(ContactUsModel contactus)
        //{
        //    try
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {



        //        string query = " insert into ContactUS(ContactUsID, SubjectHeading, Email, OrderReference, Message, Status) values(1,'dfsd','dfd','fsdf','sdfg','dsff')";
        //        //query += " SELECT SCOPE_IDENTITY()";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            //    cmd.Parameters.AddWithValue("@ContactUSID", 1);
        //            //    cmd.Parameters.AddWithValue("@SubjectHeading", contactus.SubjectHeading);
        //            //cmd.Parameters.AddWithValue("@Email", contactus.Email);
        //            //cmd.Parameters.AddWithValue("@OrderReference", contactus.OrderReference);
        //            //cmd.Parameters.AddWithValue("@Message", contactus.Message);
        //            //cmd.Parameters.AddWithValue("@Status", contactus.Status);

        //            con.Close();
        //        }
        //    }


        //}
        //    catch (Exception ex)

        //    {

        //    }
        //    return View(contactus);

        //}

