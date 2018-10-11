<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeleteRecords.aspx.cs" Inherits="DeleteRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <br><br>
                <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 w3-gr">
                     <br><h3 style="margin:0 auto; text-align: center"><b>Delete Record by:</b> (only fill 1 field)</h3><br><br>


                    

                     <br><p style="width: 95%; text-align:center; margin: 0 auto;">Product ID</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="prodId" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><p style="width: 95%; text-align:center; margin: 0 auto;">Product Name</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="prodName" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><p style="width: 95%; text-align:center; margin: 0 auto;">Product Seller</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="prodSeller" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><p style="width: 95%; text-align:center; margin: 0 auto;">Feedback ID</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="feedId" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><p style="width: 95%; text-align:center; margin: 0 auto;">Feedback For</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="feedFor" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><p style="width: 95%; text-align:center; margin: 0 auto;">Feedback From</p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="feedFrom" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <br><br><br><p style="width: 95%; text-align:center; margin: 0 auto;"><b>Delete user account by username:</b></p><br>
                     <asp:TextBox style="width: 70%; margin: 0 auto;" ID="userBox" runat="server" CssClass="form-control"></asp:TextBox><br><br>

                    <p>
                 <br />
                 <asp:Button style="margin:0 auto; width:50%; color:red; font-weight:bolder" ID="deleteBtn" runat="server" Text="Delete Record" CssClass="form-control" OnClick="deleteBtn_Click"/></p>
                </div>
                <div class="col-sm-3"></div>
                    </div>

</asp:Content>

