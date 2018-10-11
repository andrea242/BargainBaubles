<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddFunds.aspx.cs" Inherits="AddFunds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="row">
                <div class="col-sm-12"><br><br><br><br></div>
    </div>


    <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 w3-green">
                     <br><h3 style="width: 75%; text-align:center; margin: 0 auto;">Add Funds:</h3><br><br>
                    <%if (getHasCard()) //if user already has a card registered in db
                     {
                        %><p style="width: 75%; margin: 0 auto;">Existing Card Number:</p>
                    <%}
                    else //if user has no card in db yet
                    {
                       %><p style="width: 75%; margin: 0 auto;">New Card Number <br>(4 to 8 characters)<br>(Keep note of this number):</p>
                    <%} %>
                     <asp:TextBox style="width: 75%; margin: 0 auto;" ID="cardTB" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <p style="width: 75%; margin: 0 auto;">Amount to add:</p>
                    <asp:TextBox style="width: 75%; margin: 0 auto;" ID="amountTB" runat="server" CssClass="form-control"></asp:TextBox>
                     <br />
                    <br />
                    <p style="width: 75%; margin: 0 auto;">What colour is Santa's suit? (robot test)</p>
                    <asp:TextBox style="width: 75%; margin: 0 auto;" ID="robotTB" runat="server"  CssClass="form-control"></asp:TextBox>
             <p>
                 <br /><br />
                 <asp:Button style="margin:0 auto;" ID="addFundsBtn" runat="server" Text="Add funds" CssClass="form-control" OnClick="addFundsBtn_Click"/></p>
                </div>
                <div class="col-sm-3"></div>
                    </div>




    Click<asp:HyperLink id="go" ClientIDMode="Static" style="color:red" runat="server"> Here </asp:HyperLink>to make Santa run across your screen<br>
    <asp:HyperLink id="stop" ClientIDMode="Static" style="color:red" runat="server">stop</asp:HyperLink> santa from running<br>
    Bring santa <asp:HyperLink id="back" ClientIDMode="Static" style="color:red" runat="server">back</asp:HyperLink>
   <div class="p"><asp:Image ImageUrl="snt.gif" style="width:180px" runat="server" /></div>

<script>
// this alerts the user that they are taken to long to add funds to their account 
    $(document).ready(function () {
        setTimeout(function(){
            alert("You have been trying to add funds for 1 minute!");
        }, 60000);
    })

    // Start animation
    $("#go").click(function () {
        $(".p").animate({ left: "+=500px" }, 2000);
    });

    // Stop animation when button is clicked
    $("#stop").click(function () {
        $(".p").stop();
    });

    // Start animation in the opposite direction
    $("#back").click(function () {
        $(".p").animate({ left: "-=100px" }, 2000);
    });

</script>

    <style>

  .p {
    position: absolute;
    /*background-color: #abc;*/
    left: 0px;
    top: 30px;
    width: 60px;
    height: 60px;
    margin: 5px;
  }
  </style>
</asp:Content>
