<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addemployee.aspx.cs" Inherits="BizAppDev.Addemployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Add Employee Form</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Employee management</li>
            <li class="breadcrumb-item active"><a href="Addemployee.aspx">Add Employee Form</a></li>
        </ul>
        <br />
    </div>

              <div class="row" style="margin-left:30px; ">
        
    <form runat="server">
    <p>
        Employee name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_EmpName" runat="server" required="required"></asp:TextBox>
    </p>
   
    <p>
        Employee NRIC:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_NRIC" runat="server" required="required"></asp:TextBox>
    </p>
        <p>
            Staff/Admin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownPosition" runat="server" required="required">
                <asp:ListItem>Staff</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>
    </p>
    Birthdate:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Calendar ID="cal_Birthdate" runat="server" required="required"></asp:Calendar>
    <br />
    <br />
    Gender:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButtonList ID="rbl_Gender" runat="server" required="required">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
    <br />
    Contact number:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tb_Contactno" runat="server" required="required"></asp:TextBox>
    <br />
    <br />
    Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tb_Email" runat="server" type="email" required="required"></asp:TextBox>
    <br />
    <br />
    Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tb_Address" runat="server"  required="required"></asp:TextBox>
    <br />
        <br />
        Default Password:&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Password" runat="server" Text="Default@123"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btn_Add" class="btn btn-primary btn-sm" runat="server" OnClick="Button1_Click" Text="Add" />
    <br />
    <br />
        </form>
                    </div>
               
</asp:Content>
