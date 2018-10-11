using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadProduct : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        /*
             * 
             * REFERENCE: https://stackoverflow.com/questions/6086529/how-to-check-user-is-logged-in
             *  
             * 
             */

        //if not logged in
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home?Error=You_must_log_in_to_upload_products");
            return;
        }

     


    }

    protected void submit_product_Click(object sender, EventArgs e)
    {
        string seller_nameStr = Context.User.Identity.GetUserName();


        string strPrice = price.Text.ToString();
        double num;
        

        /*
         * 
         * 
         * REFERENCE
         * https://stackoverflow.com/questions/894263/how-do-i-identify-if-a-string-is-a-number
         * 
         * 
         */
        bool isValidPrice = double.TryParse(strPrice, out num); //try change price to double

        if (!isValidPrice) //if price isn't valid
        {
            Response.Redirect("~/Home?Error=Enter_valid_price");
            return; //dont read any code after this
        }



        /*
         * 
         * 
         * REFERENCE:
         * method found here: 2nd highest voted answer
         * https://www.youtube.com/watch?v=-mUJq_Ghvko
         * 
         * 
         */
        if (!main_pic.HasFile) //if no image was given
        {
            Response.Redirect("~/Home?Error=Please_go_back_and_upload_image");
            return;
        }
        
        string[] splitFile = main_pic.FileName.Split('.'); //split filename by dot, anything after the dot is [1] and before is [0]


        //if the file extension is not jpg, png, jpeg
        if(!splitFile[1].ToLower().Equals("jpg") && !splitFile[1].ToLower().Equals("png") 
            && !splitFile[1].ToLower().Equals("jpeg"))
            //if file is not any of these
        {

            Response.Redirect("~/Home?Error=Only_jpg_jpeg_png_allowed");
            return;
        }
       
        int piclen = main_pic.PostedFile.ContentLength;
       
        Random ran = new Random();

        //generate random number between 100 and 999999999 to name the image file
        int ranNum = ran.Next(100, 999999999);

        string picName = seller_nameStr + ranNum + "." + splitFile[1]; //picname = username + random number + extension.
        //eg john34243.jpg
        

        main_pic.PostedFile.SaveAs(Server.MapPath(".") + "/images/" + picName); //save the pic in images folder








        //insert the new product details
        var NewItem = new SqlDataSource();
        NewItem.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        NewItem.InsertCommandType = SqlDataSourceCommandType.Text;
        NewItem.InsertCommand = "INSERT INTO product VALUES (@stock, @seller_name, @product_name, @area, @main_pic, @product_info, @price)";
        NewItem.InsertParameters.Add("stock", "In Stock");
        NewItem.InsertParameters.Add("seller_name", seller_nameStr);
        NewItem.InsertParameters.Add("product_name", product_name.Text.ToString());
        NewItem.InsertParameters.Add("area", area.Text.ToString());

        //insert the name of the image in images folder
        NewItem.InsertParameters.Add("main_pic", picName);

        NewItem.InsertParameters.Add("product_info", product_info.Text.ToString());
        NewItem.InsertParameters.Add("price", price.Text.ToString());
        NewItem.Insert();


        Response.Redirect("~/Home?Product_uploaded_successfully");


    }


}