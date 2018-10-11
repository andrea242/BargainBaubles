using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{

    private string url;
    protected void Page_Load(object sender, EventArgs e)
    {



        /*
         * 
         * 
         * REFERENCE:   https://stackoverflow.com/questions/19739690/how-to-get-url-path-in-c-sharp
         * 
         * 
         */

       
        //GET CURRENT URL
        url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
    }

    public string getH1Message()
    {

        if (url.ToLower().Contains("home?error="))
        {   //if theres an error
            
            string[] urlArray = url.Split('='); //split the url in half with '=' being the splitter

            return urlArray[1].Replace('_', ' '); //replace all '_' in 2nd half of url with ' '

            //that becomes message on home screen

        }
        else if (url.Contains("Home?"))
        {   //if not an error
            
            string[] urlArray = url.Split('?'); //split the url in half with '?' being the splitter

            return urlArray[1].Replace('_', ' '); //replace all '_' in 2nd half of url with ' '

            //that becomes message on home screen
            
        }


        

        else
        {
            //otherwise the message is just:
            return "Welcome to Bargain Baubles";
        }

    }





    public bool isError()
    {
        //returns true if URL has 'error=' and false if not
        return url.ToLower().Contains("error=");

    }

}

