using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

/// <summary>
/// Summary description for HashCard
/// </summary>
public class HashCard
{
    private string card = "";


    public HashCard(string given) //allows to pass in unhashed card with "new HashCard" in AddFunds.aspx.cs
    {
        card = given; //sets the private card to the value passed in from AddFunds.aspx.cs




        /*
         * 
         * 
         * REFERENCE:
         * method found here: 2nd highest voted answer
         * https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp 
         * 
         * 
         */
        using (var sha = new SHA256Managed())
        {   //changes card number to hash eg WPakjwenfwoi9033NfsdfjSLdSkswe
            byte[] cardNumArray = System.Text.Encoding.UTF8.GetBytes(card);
            byte[] hash = sha.ComputeHash(cardNumArray);
            card = BitConverter.ToString(hash).Replace("-", String.Empty);
        }
        



    }

    public string getCard()
    { //returns the card number after it has been hashed
        return card;
    }
}