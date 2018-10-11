using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Purchases : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        //if not logged in
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home?Error=Only_admin_can_view_purchases");
            return;
        }

        //if not admin
        if (!Context.User.Identity.GetUserName().Equals("admin"))
        {
            Response.Redirect("~/Home?Error=Only_admin_can_view_purchases");
            return;
        }


      
    }




}