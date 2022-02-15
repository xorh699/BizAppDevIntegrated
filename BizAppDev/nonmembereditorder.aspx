<%@ Page Title="" Language="C#" MasterPageFile="~/nonmembermaster.Master" AutoEventWireup="true" CodeBehind="nonmembereditorder.aspx.cs" Inherits="BizAppDev.nonmembereditorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- Choices CSS-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/styles/choices.min.css">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/style.default.premium.2a30c8f8.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/custom.0a822280.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/favicon.3903ee9d.ico">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
      <style type="text/css">
       
    .auto-style1 {
        height: 26px;
    }
    .auto-style2 {
        height: 27px;
        width: 102px;
    }
    .auto-style3 {
        height: 28px;
        width: 102px;
    }
    .auto-style4 {
        height: 28px;
        width: 190px;
    }
    .auto-style5 {
        width: 190px;
    }
       
    </style>
      <div class="header" style="text-align:center;">
         <div class="header" style=" padding: 60px;
  text-align: center;
  background: #FEBBC1;
  color: white;
  font-size: 30px;height:320px;">
 <br />
        <br />
        <h1>Edit Quantity</h1>
 
</div>
    <br />
    <br />
    <br />
    
        <br />
    </div>
    <table class="auto-style1" style="margin-left:825px;margin-top:50px;">
        <tr>
            <td class="auto-style3">Product ID</td>
            <td class="auto-style4">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Product Name</td>
            <td class="auto-style5">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Unit Price</td>
            <td class="auto-style5">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Quantity</td>
            <td class="auto-style5">
                <asp:TextBox ID="tb_quantity" runat="server" OnTextChanged="tb_quantity_TextChanged"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_quantity" ErrorMessage="Please Enter a Quantity" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Total Price</td>
            <td class="auto-style5">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="Button1" runat="server" Text="Save" BackColor="Blue" ForeColor="White" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
