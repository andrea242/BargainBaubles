<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home"  ClientIDMode="Static"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    
    
      <div class="jumbotron w3-red"> 
        <!--
            REFERENCE
            https://stackoverflow.com/questions/957284/whats-the-deal
            -->
        <h1><%= getH1Message() %></h1>


      <p class="lead">We have trees and decorations users sell and buy between each other ect ect.  . . . 

                 When it comes to Christmas, Bargain Baubles are incomparable in terms of quality. Bargain baubles
was founded in 1977. It is a family owned business who thrive themselves providing the finest
quality of trees.
       </p>
       
        
        
        

        <% if (isError())
           {
                %>

                    <!-- 
                        REFERENCE: https://stackoverflow.com/questions/8814472/how-to-make-an-html-back-link
                        -->
                    <p style="text-align:center; margin: 0 auto; width:95%;"><a href="#" onclick="javascript:history.back()" class="btn btn-primary btn-lg w3-green">Go Back &laquo;</a></p>
        <% }




            /*
             * 
             * REFERENCE: https://stackoverflow.com/questions/6086529/how-to-check-user-is-logged-in
             *  
             * 
             */
           else if (!HttpContext.Current.User.Identity.IsAuthenticated) // if not logged in  ('!' is 'not')
           {
                %>
                    <p style="text-align:center; margin: 0 auto; width:95%;"><a href="Account/Register" class="btn btn-primary btn-lg w3-green">Sign up for more &raquo;</a></p>
        <% }
           else if (HttpContext.Current.User.Identity.IsAuthenticated) //if logged in
           {
                %>
                    <p style="text-align:center; margin: 0 auto; width:95%;"><a href="UploadProduct" class="btn btn-primary btn-lg w3-green">Upload a Product &raquo;</a></p>
        <% }
                %>
          </div>
 
    <div id="hideme" style="display:none;">
        <div class="jumbotron w3-khaki">
        <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <h2 style="text-align:center; margin: 0 auto; width:95%;"">Check out our products</h2>
            <p>
                On our site, you can sell baubles for Christmas trees, you can sell stands for Christmas trees, you can
sell lights for Christmas trees and you can sell tinsel for.. yes, you guessed it right… for Christmas
trees.
<br> P.s you can also sell Christmas trees and anything related to Christmas.
            </p>
            <p style="text-align:center; margin: 0 auto; width:95%;">
                <a class="btn btn-primary btn-lg w3-green" href="Products">View Products &raquo;</a><br />
            </p>

            <div class="row">
        <br><br>
        <div class="2"></div>
        <h2 style="text-align:center; margin: 0 auto; width:95%;">View Our Products in a slideshow</h2><br>
         <div class="8">
            <p style="text-align:center; margin: 0 auto; width:95%;"><a href="SampleProducts" class="btn btn-primary btn-lg w3-green">Sample Store Products &raquo;</a></p>
         </div>
        </div>
        </div>
      </div>
      </div>
        </div>      
    
    <p style="text-align:center; margin: 0 auto; width:95%;">
        <asp:HyperLink ID="more" class="btn btn-primary btn-lg w3-green" runat="server">Click here to find out more</asp:HyperLink>
            </p>
  
    
     

         <script>
             $(document).ready(function () {
                 $("#more").click(function () {
                     $("#hideme").show("slow");
                 });
                 //hides button when we click it
                 $('#more').click(function () {
                     $(this).hide();
                 });
             });

            
         </script>

</asp:Content>
