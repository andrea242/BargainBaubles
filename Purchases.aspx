<%@ Page Title="Purchases" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Purchases.aspx.cs" Inherits="Purchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="row">
        <div class="col-sm-12"><br><br><br>
            <h1 style="text-align:center; margin: 0 auto; width:95%;"><b>All Purchases</b></h1>
        </div>
    </div>

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [purchase]"></asp:SqlDataSource>

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            
            <div class="row">
          <div class="col-sm-2"></div>
                 <div class="col-sm-8" style="text-align:center; margin: 0 auto; width:95%;">
                 <h3><br>Product Name: </b><%# Eval("product_name") %></h3><br>
                  
                  <br />
                    <br><p>Product ID: <%# Eval("product_id") %></p><br />
                  <p>Seller: <%# Eval("seller_name") %></p><br>
                     <p>Buyer: <%# Eval("buyer_name") %></p><br>
      
      
                 <p>Purchase cost: &euro;<%# Eval("price") %></p><br>
                

              </div>
                <div class="col-sm-2"></div>
                </div>

           


        </ItemTemplate>
    </asp:Repeater>



</asp:Content>


