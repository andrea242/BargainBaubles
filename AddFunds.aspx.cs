using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddFunds : System.Web.UI.Page
{
    private bool hasCard;
    private string user_name, card_number;
    private double balance;


    protected void Page_Load(object sender, EventArgs e)
    {
        hasCard = false; //set to false until it's found




              /*
             * 
             * REFERENCE: https://stackoverflow.com/questions/6086529/how-to-check-user-is-logged-in
             *  
             * 
             */

        //if not logged in
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home?Error=Log_in_to_add_funds");
            return;
        }




        user_name = Context.User.Identity.GetUserName();
        card_number = "";
        balance = 0; //initialise variables to use further down

        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        SqlCommand command = new SqlCommand("SELECT * FROM credit WHERE user_name='" + user_name + "'", conn);
        try
        {
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) //while it's reading a row that matches the parameters in query ^^
            {
                hasCard = true;
                card_number = reader["card_number"].ToString();
                string strBal = reader["balance"].ToString();
                double.TryParse(strBal, out balance); //set balance variable as a double, for currency eg 26.75
                
            }
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    public bool getHasCard()
    {
        return hasCard; //return whether they have a card in db or not
    }

    protected void addFundsBtn_Click(object sender, EventArgs e)
    {
        string robotAns = robotTB.Text.ToString().ToLower(); // saving the robotQ's answer
        if (!robotAns.Equals("red") && !robotAns.Equals("white") && !robotAns.Equals("red and white") && !robotAns.Equals("red & white")) // ! means if ans is WRONG ? ? ? 
            
        {
            Response.Write("<script>alert('Robots do not celebrate christmas');</script>");
          
            return;
        }

        if (hasCard) //if they have a card record already
        {


            string strCardNum = cardTB.Text.ToString();
            int cardNum = 0;

            if (strCardNum.Length < 4 || strCardNum.Length > 8)
            {
                Response.Redirect("~/Home?Error=Card_must_be_4_to_8_digits");
                return; //kick out of this method
            }



            if (!int.TryParse(strCardNum, out cardNum))
            {   //if cant change card num to int
                Response.Redirect("~/Home?Error=Enter_valid_card_number");
                return;
            }

            string strAmount = amountTB.Text.ToString();
            double amount = 0;

            if (!double.TryParse(strAmount, out amount))
            {   //if cant change card to double, eg 34D3DF is invalid
                Response.Redirect("~/Home?Error=Enter_valid_amount_to_add_to_card");
                return;
            }

            if (amount > 10000)
            {
                Response.Redirect("~/Home?Error=Max_funds_is_10000_at_a_time");
                return;
            }

            HashCard hash = new HashCard(strCardNum); //Instantiate the HashCard class to hash the number

            string strHashed = hash.getCard(); //get the number which is now hashed


            if (!strHashed.Equals(card_number))  //IF ENTERED CARD NUMBER (hashed) DOES NOT MATCH THE (also hashed) ONE IN DB
            {
                Response.Redirect("~/Home?Error=Enter_your_existing_card_number");
                return;
            }

            double newBal = balance + amount;   //new balance is now = old balance + the funds added

            string strNewBal = newBal.ToString(); //everything is inserted to db as string,
            //the db converts to varchar or decimal itself
            


            //UPDATING NEW BALANCE
            var cred = new SqlDataSource();
            cred.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cred.UpdateCommandType = SqlDataSourceCommandType.Text;
            
            
            cred.UpdateCommand = "UPDATE credit SET balance='"+strNewBal+"' WHERE user_name='"+user_name+"'";

            cred.Update();

            Response.Redirect("~/Home?Credit_added_successfully");
        }








        else  //if they dont have a card record already
        {
            string strCardNum = cardTB.Text.ToString();
            int cardNum = 0;

            if (strCardNum.Length < 4 || strCardNum.Length > 8)
            {   
                Response.Redirect("~/Home?Error=Enter_valid_card_number");
                return;
            }



            if (!int.TryParse(strCardNum, out cardNum))
            {   //if card number isnt just numbers
                Response.Redirect("~/Home?Error=Enter_valid_card_number");
                return;
            }

            string strAmount = amountTB.Text.ToString();
            double amount = 0;

            if (!double.TryParse(strAmount, out amount))
            {   //if amount cant be a double (that means it cant be currency)
                Response.Redirect("~/Home?Error=Enter_valid_amount_to_add_to_card");
                return;
            }

            if (amount > 10000)
            {
                Response.Redirect("~/Home?Error=Max_funds_is_10000_at_a_time");
                return;
            }

            HashCard hash = new HashCard(strCardNum); //Instantiate the HashCard class to hash the number

            string strHashed = hash.getCard(); //get the number which is now hashed
         

            //INSERTING NEW CARD
            var cred = new SqlDataSource();
            cred.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cred.InsertCommandType = SqlDataSourceCommandType.Text;
            cred.InsertCommand = "INSERT INTO credit VALUES (@user_name, @card_number, @balance)";

            cred.InsertParameters.Add("user_name", user_name);
            cred.InsertParameters.Add("card_number", strHashed);
            cred.InsertParameters.Add("balance", strAmount);
            cred.Insert();

            Response.Redirect("~/Home?Credit_added_successfully");
        }



    }





}