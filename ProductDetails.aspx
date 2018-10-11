<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [product] WHERE ([product_id] = @product_id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="product_id" QueryStringField="product_id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [feedback] WHERE ([feedback_for] = @seller_name)">
        <SelectParameters>
            <asp:QueryStringParameter Name="seller_name" QueryStringField="seller_name" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

  
    
    <asp:Repeater ID="Repeater" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                 <h3><%# Eval("product_name") %></h3><br>
              
                  <img class="previewim" id="img1" src="images/<%# Eval("main_pic") %>"  alt="Image" style="width: 50%; margin-bottom: 10px; height: 124px;"/>
                  <br />
    
                  <p>Seller: <%# Eval("seller_name") %></p>
                  <p><br><%# Eval("product_name") %> is in <%# Eval("area") %></p>
      
                 <p>&euro;<%# Eval("price") %></p>
                <p>Availability: <%# Eval("stock") %></p>
                <p>Product Information: <%# Eval("product_info") %></p>

            </div>
            <div class="col-sm-4"></div>
                </div>

            
            
             
        </ItemTemplate>


        

    </asp:Repeater>

            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                  
                    <asp:Button style="margin:0 auto;" OnClick="purchaseBtn_Click" ID="purchaseBtn" runat="server" Text="Buy Product" CssClass="form-control" />

                </div>
                <div class="col-sm-4"></div>
            </div>
        <br><br>
    <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 w3-khaki">
                     <br><h3 style="margin:0 auto; text-align:center;">Leave feeback for <%=getFeedbackUsername()%></h3><br><br>
                     <asp:TextBox style="width: 95%; margin: 0 auto;" ID="reviewTB" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
             <p>
                 <br />
                 <asp:Button style="margin:0 auto;" ID="reviewBtn" runat="server" Text="Submit Review"  CssClass="form-control" OnClick="reviewBtn_Click"/></p>
                </div>
                <div class="col-sm-3"></div>
                    </div>
        <br /><br />

    <div id="flip" class="btn btn-primary btn-lg w3-green">Click to see feedback</div>
    <div id="panel" style="display:none;">

     <div class="row"><br><br>
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <h2>Reviews:</h2>
            </div>
         <div class="col-sm-4"></div>
                
     </div>

    
    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
           <ItemTemplate>
                <br><br>
               <div id="nosee">
                <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 w3-red">
                     <h5>Feedback for <%# Eval("feedback_for") %> given by <%# Eval("feedback_from") %></h5>
                     <p class="w3-opacity"><%# Eval("comment") %></p> 
                    <p style="text-align:right; margin: 0 auto; width:95%;"><asp:HyperLink ID="hidey" server" ClientIDMode="static" >Click here to hide</asp:HyperLink></p>
                </div>
                <div class="col-sm-3"></div>
                   
                    </div>
                  </div>
           </ItemTemplate>

       
        <AlternatingItemTemplate>

         
            <br><br>
                <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 w3-green">
                     <h5>Feedback for <%# Eval("feedback_for") %> given by <%# Eval("feedback_from") %></h5>
                     <p class="w3-opacity"><%# Eval("comment") %></p>
                    <p class="w3-text-white" style="text-align:right; margin: 0 auto; width:95%;"><asp:HyperLink ID="hidey" server" ClientIDMode="static" >Click here to hide</asp:HyperLink></p>
                </div>
                <div class="col-sm-3"></div>
                    </div>

                


            </AlternatingItemTemplate>


                 

        </asp:Repeater>
        </div>

 



                


    <script>
        //this hides every review of a product until the button is clicked
        $(document).ready(function () {
            $("#flip").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
        // this removes a review from the list until the page is refreshed - it has a pop up to tell the user it's hidden
        $(document).ready(function () {
            $("#hidey").click(function () {
                $("#nosee").hide("slow", function () {
                    alert("This review is now hidden");
                });
            });
        });
    </script>

</asp:Content>
