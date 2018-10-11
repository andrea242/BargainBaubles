using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        //if not logged in
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home?Error=You_must_be_admin_delete_records");
            return;
        }


        //if username is not admin
        if (!Context.User.Identity.GetUserName().Equals("admin"))
        {
            Response.Redirect("~/Home?Error=You_must_be_admin_delete_records");
            return;
        }

        

    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        int res = 0; //this is going to save whether the record to delete was found or not

        string product_id = prodId.Text.ToString();
        string product_name = prodName.Text.ToString();
        string seller_name = prodSeller.Text.ToString();
        string feedback_id = feedId.Text.ToString();
        string feedback_for = feedFor.Text.ToString();
        string feedback_from = feedFrom.Text.ToString();
        string UserName = userBox.Text.ToString();   //for account deletion

        int emptyCount = 0; //use this to count how many boxes are empty

        if (String.IsNullOrEmpty(product_id)) emptyCount++; //if box is empty increase the emptyCount value
        if (String.IsNullOrEmpty(product_name)) emptyCount++;
        if (String.IsNullOrEmpty(seller_name)) emptyCount++;
        if (String.IsNullOrEmpty(feedback_id)) emptyCount++;
        if (String.IsNullOrEmpty(feedback_for)) emptyCount++;
        if (String.IsNullOrEmpty(feedback_from)) emptyCount++;
        if (String.IsNullOrEmpty(UserName)) emptyCount++;

        if (emptyCount==7) //if 7 are empty, we cant delete anything
        {
            Response.Redirect("~/Home?Error=Please_fill_a_field_to_delete");
            return; //dont read any further
        }

        if (emptyCount<6) //if less than 6 are empty, it means 2 or more are filled, only 1 is allowed to be filled
        {
            Response.Redirect("~/Home?Error=Please_fill_only_one_field_to_delete");
            return; //dont read any further
        }


        //6 boxes were empty for the program to reach this point
        

        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            /*
             * 
             * 
             * REFERENCE:
             * https://www.w3schools.com/sql/sql_delete.asp
             * 
             * 
             */
            


            // '!' means not
            if (!String.IsNullOrEmpty(product_id)) //if the product_id is NOT empty, they want to delete by product_id
            {
                cmd.CommandText = "DELETE FROM product WHERE product_id='" + product_id + "'";

            }

            if (!String.IsNullOrEmpty(product_name))
            {
                cmd.CommandText = "DELETE FROM product WHERE product_name='" + product_name + "'";
            }

            if (!String.IsNullOrEmpty(seller_name))
            {
                cmd.CommandText = "DELETE FROM product WHERE seller_name='" + seller_name + "'";
            }

            if (!String.IsNullOrEmpty(feedback_id))
            {
                cmd.CommandText = "DELETE FROM feedback WHERE feedback_id='" + feedback_id + "'";
            }

            if (!String.IsNullOrEmpty(feedback_for))
            {
                cmd.CommandText = "DELETE FROM feedback WHERE feedback_for='" + feedback_for + "'";
            }

            if (!String.IsNullOrEmpty(feedback_from))
            {
                cmd.CommandText = "DELETE FROM feedback WHERE feedback_from='" + feedback_from + "'";
            }

            if (!String.IsNullOrEmpty(UserName))
            {
                cmd.CommandText = "DELETE FROM AspNetUsers WHERE UserName='" + UserName + "'";
            }
           

        

            res = cmd.ExecuteNonQuery(); //cmd.ExecureNonQuery returns the number of rows affected, which we save in 'res'

            if (res==0)
            {
                //if 0 rows were affected, nothing happened.
                Response.Redirect("~/Home?Error=That_record_is_not_in_our_system");
            }
            else
            {
                //if 1 or more rows were affected, they were was deleted.
                Response.Redirect("~/Home?Deletion_successful");
            }
               
        }//end of try

        finally //after 'try' is done
        {
            conn.Close(); //close the connection
        }

        
  

        
    }
}
 