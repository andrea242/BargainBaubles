using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{

    private int iter = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


   


    public void iterate()
    {
        iter++;//increase iter by 1
    }

    public int getIter()
    {
        return iter; //give the new iter (for num of products on page)
        //to fix the 'row' problem
    }

}