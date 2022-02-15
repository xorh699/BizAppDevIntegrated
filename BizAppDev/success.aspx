<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="BizAppDev.success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<div class="container" style="margin-top:5%;">
	<div class="row">
        <div class="jumbotron" style="box-shadow: 2px 2px 4px #000000;">
            <h2 class="text-center">YOUR ORDER HAS BEEN RECEIVED</h2>
          <h3 class="text-center">Thank you for your payment, it’s processing</h3>
          
          <p class="text-center">Your order # is: 100000023</p>
          <p class="text-center">You will receive an order confirmation email with details of your order and a link to track your process.</p>
            <center><div class="btn-group" style="margin-top:50px;">
                <asp:Button ID="Button_hm" runat="server" Text="Home" CssClass="btn btn-dark" style="scale:150%;" Height="50px" Width="100px" OnClick="Button_hm_Click" />
            </div></center>
        </div>
	</div>
</div>
</asp:Content>
