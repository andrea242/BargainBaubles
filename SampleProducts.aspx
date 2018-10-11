<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SampleProducts.aspx.cs" Inherits="SampleProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    
    <div class="row">
        <div class="2"></div>
        <h2 style="text-align:center; margin: 0 auto; width:95%;"><br><br>Our Products in Action</h2><br>
         <div class="8" style="text-align:center; margin: 0 auto; width:95%;">

             <div id="sample-products" style="text-align:center; margin: 0 auto; width:95%;">
                 <div><asp:Image Imageurl="images/treeshow1.jpg" runat="server" /></div>
                 <div><asp:Image ImageUrl="images/treeshow2.jpg" runat="server" /></div>
                 <div><asp:Image ImageURl="images/treeshow3.jpg" runat="server" /></div>
             </div>

         </div>
         <div class="2"></div>
    </div>

    <script> 

        ///jQuery for Slideshow *****************************
         $(document).ready(function () {
            $("#flip").click(function () {
                $("#product").slideToggle("slow");
            });
        });
        $("#sample-products > div:gt(0)").hide();

        setInterval(function () {
            $('#sample-products > div:first')
                .fadeOut(1000)
                .next()
                .fadeIn(1000)
                .end()
                .appendTo('#sample-products');
        }, 3000);//3 seconds
</script>

</asp:Content>

