using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RxOutlet.Models
{
    public class ContactUsModel
    {
        public int ContactUsID { get; set; }
        // public string SubjectHeading { get; set; }
        public List<SelectListItem> SubjectHeading { get; set; }
        public int? SubjectHeadingID { get; set; }
        public string SubjectHeadingName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string OrderReference { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }



        string constr = ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DDIP9VH\\SQLEXPRESS;Initial Catalog=RxOutlet;Persist Security Info=True;Integrated Security=True");
    
        public string InsertRegDetails(ContactUsModel obj)
        {
            SqlCommand cmd = new SqlCommand("InsertContactInfo", con); 
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@SubjectHeading", obj.SubjectHeadingName);       
            cmd.Parameters.AddWithValue("@Email ", obj.Email);    
            cmd.Parameters.AddWithValue("@OrderReference ", obj.OrderReference);
            cmd.Parameters.AddWithValue("@Message ", obj.Message);    
            cmd.Parameters.AddWithValue("@Status ", obj.Status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success";
        }
    }



}




    
    