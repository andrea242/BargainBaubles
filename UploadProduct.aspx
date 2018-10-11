<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UploadProduct.aspx.cs" Inherits="UploadProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-xs-6">
        <h2><b>Sell a Product</b></h2>
        <br /> 
        <p>Product name:</p><asp:TextBox ID="product_name"  BorderColor="Green" runat="server" CssClass="form-control"></asp:TextBox>
        <!--<p class="w3-text-red"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your name" ControlToValidate="product_name"></asp:RequiredFieldValidator></p>
        --><br />
        <p>Price:</p><asp:TextBox ID="price" runat="server"  BorderColor="Green" CssClass="form-control"></asp:TextBox>
        <!--<p class="w3-text-red"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Your item must have a price, or else put a 0" ControlToValidate="price"></asp:RequiredFieldValidator></p>
        --><br />
        <p>Product Location:</p><asp:TextBox ID="area"  BorderColor="Green" runat="server" CssClass="form-control"></asp:TextBox>
        <!--<p class="w3-text-red"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your location" ControlToValidate="area"></asp:RequiredFieldValidator></p>
        --><br />
        <p>Product Info:</p><asp:TextBox TextMode="MultiLine"  BorderColor="Green" ID="product_info" runat="server" CssClass="form-control"></asp:TextBox>
        <!--<p class="w3-text-red"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please leave a description to tell us about your product" ControlToValidate="product_info"></asp:RequiredFieldValidator></p>
        --><br /> 
        <p>Upload Product Image</p><asp:FileUpload ID="main_pic"   runat="server" BorderColor="Green"></asp:FileUpload>
        <br />
        
        <br />
        <asp:Button class="btn btn-default" ID="submit_product" style="color:black; font-weight: bold;" runat="server" Text="Upload Product" CssClass="form-control" OnClick="submit_product_Click"/>

        </div>
        <div class="col-sm-3"></div>
        </div>
    
   Don't like the gif below? Click it to make it fade away!
   <p> <asp:Image ID="gif" ImageUrl="spg.gif" Width="200px" runat="server" /></p>
     <asp:HyperLink class="show" runat="server" style="colour:red" ClientIDMode="Static">Click this text and the gif will come back!</asp:HyperLink>
    <script>
        $("p").click(function () {
            $(this).fadeTo("slow", 0.0, function () { });
        });
       
        $(".show").click(function () {
            $("p").fadeTo("slow", 1, function () { });
           });
       
    </script>
</asp:Content>

