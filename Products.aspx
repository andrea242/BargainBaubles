<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <% 
                iterate();//go up by one for each product
                
                %>
            <% if (getIter() % 3 == 0) //if x product is divisible by 3, then do a row

                    //every 3 products, do a row (on the 3rd, 6th, 9th, 12th, etc product, do a row)

                 //eg if its the 5th product, its not divisible by 3, but if its the 27th it is so do a row

                {%>
            <div class="row">
            <% }%>
                 <div class="col-sm-4">
                 <h3><%# Eval("product_name") %></h3><br>

                                       <!-- Show picture: images/file name from db -->
                  <img class="previewim" id="btn1" src="images/<%# Eval("main_pic") %>"  alt="Image" style="width: 50%; margin-bottom: 10px; height: 124px;"/>
                  <br />
                    <br><p><%# Eval("stock") %></p><br>
                  <p><%# Eval("area") %></p>
      
                 <p>&euro;<%# Eval("price") %></p>
                <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-info w3-red" 
                    NavigateUrl='<%# String.Format("~/ProductDetails?product_id={0}&seller_name={1}", Eval("product_id"), Eval("seller_name")) %> '>
                    Details
                </asp:HyperLink>

              </div>

            <% if (getIter() % 3 == 0 || getIter()==Repeater1.Items.Count) //end row every 3 products
                   
                {%>
                </div> 
            <% }%>


        </ItemTemplate>
    </asp:Repeater>

    <style>
        #toTop {
    padding: 9px 5px;
    background: #4cff00;
    color:red;
    position: fixed;
    bottom: 0;
    right: 5px;
    display: none;
}
    </style>

    <div id='toTop'><span class="glyphicon glyphicon-hand-up"></div>

    <script>
        $(window).scroll(function () {
            if ($(this).scrollTop()) {
                $('#toTop').fadeIn();
            } else {
                $('#toTop').fadeOut();
            }
        });

        $("#toTop").click(function () {
            $("html, body").animate({ scrollTop: 0 }, 1000);
        });
    </script>

</asp:Content>


