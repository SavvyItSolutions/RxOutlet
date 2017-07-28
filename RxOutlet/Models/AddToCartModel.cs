using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;


namespace RxOutlet.Models
{
   
    public class AddToCartModel
    {
       // public int UserID { get; set; }
        public int DrugID { get; set; }
        public string UserName { get; set; }
        public int Quantity { get; set; }
         

        string constr = ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=108.58.151.10;Initial Catalog=RxOutlet;Persist Security Info=True;User ID=rxadmin;Password=rxadmin");

        public string InsertCartItems(AddToCartModel obj)
        {


        

            SqlCommand cmd = new SqlCommand("InsertCartItems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", HttpContext.Current.User.Identity.GetUserId());
            cmd.Parameters.AddWithValue("@DrugID", obj.DrugID);
            cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);


            //cmd.Parameters.AddWithValue("@DrugName", obj.DrugName);
            //cmd.Parameters.AddWithValue("@SupplierName", obj.SupplierName);
            //cmd.Parameters.AddWithValue("@DrugType", obj.DrugType);
            // cmd.Parameters.AddWithValue("@UserName ", Roles.GetUsersInRole("Account Manager").Select(Membership.GetUser).ToList());
            //cmd.Parameters.AddWithValue("@UserName", HttpContext.Current.User.Identity.Name);
            //cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
            //cmd.Parameters.AddWithValue("@ImageNum", obj.ImageNum);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success";
        }

     




    }
}