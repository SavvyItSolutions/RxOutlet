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

            int strDDLValue = Convert.ToInt32(Request.Form["ddlVendor"]);
            List<SelectListItem> dd = PopulateSubjectHeading();
            obj.SubjectHeadingID = Convert.ToInt32(dd[strDDLValue].Value);
            ContactUsModel objreg = new ContactUsModel();
            string result = objreg.InsertRegDetails(obj);
            ViewData["result"] = result;
            ModelState.Clear();
            return View(obj);
        }

        private static List<SelectListItem> PopulateSubjectHeading()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            // string constr = ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
            SqlConnection con = new SqlConnection("Data Source=108.58.151.10;Initial Catalog=RxOutlet;Persist Security Info=True;User ID=rxadmin;Password=rxadmin");
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





      

