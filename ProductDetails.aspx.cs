using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    private string user_name;
    protected void Page_Load(object sender, EventArgs e)
    {


        /*
         * 
         * REFERENCE: 
         *  https://stackoverflow.com/questions/8678471/how-to-check-that-request-querystring-has-a-specific-value-or-not-in-asp-net
         * 
         * 
         */
        if (Request.QueryString["product_id"] == null)
        {
            Response.Redirect("~/Home?Error=Choose_product_to_view_details");
        }
        

        

    }

   

    protected void reviewBtn_Click(object sender, EventArgs e)
    {
        string comment = reviewTB.Text.ToString();

        if(comment.Length < 4 || comment.Length > 800)
        {
            Response.Redirect("~/Home?Error=Review_must_be_4_to_800_characters");
            return;
        }

        //seller string
        string slr = getFeedbackUsername();//calls in the method at bottom of this file and saves the result in 'slr'

        //buyer string
        string byr = Context.User.Identity.GetUserName();

        //f for feedback
        var f = new SqlDataSource();
        f.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        f.InsertCommandType = SqlDataSourceCommandType.Text;
        f.InsertCommand = "INSERT INTO feedback VALUES (@feedback_for, @feedback_from, @comment)";
        f.InsertParameters.Add("feedback_for", slr);
        f.InsertParameters.Add("feedback_from", byr);
        f.InsertParameters.Add("comment", comment);

        f.Insert();

        Response.Redirect("~/Home?Feeback_submitted_successfully");


    }

    

    protected void purchaseBtn_Click(object sender, EventArgs e)
    {
        //if not logged in
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home?Error=You_must_log_in_to_purchase_products");
            return;
        }

        user_name = Context.User.Identity.GetUserName(); //get the logged in person's username


        string strId = Request.QueryString["product_id"];
        string product_id = "";
        string product_name = "";
        string seller = "";
        string price = "";
        string buyer = Context.User.Identity.GetUserName();
        string strBal = "";
        string stock = "";


        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //get all product details from db for the current product on ProductDetails page
        SqlCommand command = new SqlCommand("SELECT * FROM product WHERE product_id = '"+strId+"'", conn);
        
        try
        { //try to use db
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                product_id = reader["product_id"].ToString();
                //idInt = int.Parse(strID);
                product_name = reader["product_name"].ToString();
                seller = reader["seller_name"].ToString();
                price = reader["price"].ToString();
                stock = reader["stock"].ToString();


            }
            reader.Close();
        }
        finally //after 'try' is done
        {
            conn.Close();     
        }


        if(stock.Equals("Out of Stock"))
        {
            Response.Redirect("~/Home?Error=This_item_is_out_of_stock");
        }



        //new command
        command = new SqlCommand("SELECT * FROM credit WHERE user_name='"+user_name+"'", conn);

        try
        {
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                strBal = reader["balance"].ToString();


            }
            reader.Close();
        }
        finally
        {
            conn.Close();
        }



        double balance = 0; //we will use this to save user's balance (currency)

        if (!double.TryParse(strBal, out balance))
        {   //if balance is not valid for currency eg: 343J
            Response.Redirect("~/Home?Error=Invalid_balance");
            return;
        }


        double decPrice = 0;

        // '!' is 'not'  , so if it cant change to a double


        if (!double.TryParse(price, out decPrice))
        {   //if price is not valid for currency eg: 432.4K
            Response.Redirect("~/Home?Error=Invalid_price");
            return;
        }


        if (balance < decPrice)
        {   //if user's balance is lower than the price of product (they dont have enough money)
            Response.Redirect("~/Home?Error=Add_funds_to_buy_this_product");
            return;//leave method
        }

        if (seller.Equals(buyer))
        {   
            Response.Redirect("~/Home?Error=You_cant_buy_your_own_product");
            return;//leave method
        }



      

        //insert purchase into purchase table
        var buy = new SqlDataSource();
        buy.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        buy.InsertCommandType = SqlDataSourceCommandType.Text;
        buy.InsertCommand = "INSERT INTO purchase VALUES (@product_id, @product_name, @buyer_name, @seller_name, @price)";
        buy.InsertParameters.Add("product_id", strId);
        buy.InsertParameters.Add("product_name", product_name);
        buy.InsertParameters.Add("buyer_name", buyer);
        buy.InsertParameters.Add("seller_name", seller);
        buy.InsertParameters.Add("price", price);

        buy.Insert();


        var bal = new SqlDataSource();
        bal.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        bal.UpdateCommandType = SqlDataSourceCommandType.Text;

        double dPrice = 0;

        if (!double.TryParse(price, out dPrice))
        {   //if price not valid currency
            Response.Redirect("~/Home?Error=Invalid_price");
            return;
        }

        double newBal = balance - dPrice;
        string strNewBal = newBal.ToString();

        bal.UpdateCommand = "UPDATE credit SET balance='"+strNewBal+"' WHERE user_name='"+user_name+"'";

        bal.Update();



        var prod = new SqlDataSource();
        prod.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        prod.UpdateCommandType = SqlDataSourceCommandType.Text;



        prod.UpdateCommand = "UPDATE product SET stock='Out of Stock' WHERE product_id='" + product_id + "'";

        prod.Update();


        Response.Redirect("~/Home?Product_purchased_successfully");


    }





    public string getFeedbackUsername() //gets the seller_name from product table, because seller = feedback_for
    {
        string strQ = Request.QueryString["product_id"];
        string name = "seller";
        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        SqlCommand command = new SqlCommand("SELECT * FROM product WHERE product_id='"+strQ+"'", conn);
        try
        {
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                name = reader["seller_name"].ToString();


            }
            reader.Close();
        }
        catch
        {
            name = "seller";
        }
        finally
        {
            conn.Close();
        }

        return name; //return the name of seller
        //so when this method is called it will give name of seller

        //eg seller = getFeedbackUsername(); saves the name in a 'seller' variable

    }


}