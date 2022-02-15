<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="BizAppDev.EditOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <table class="auto-style1">
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
