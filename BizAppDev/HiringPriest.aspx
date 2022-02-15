<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="HiringPriest.aspx.cs" Inherits="BizAppDev.HiringPriest" %>
 
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 218px;
            height: 31px;
        }
        .auto-style3 {
            width: 218px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
            width: 477px;
        }
        .auto-style7 {
            height: 30px;
            width: 477px;
        }
    </style>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Appointment for Priest</h2>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Customer ID:</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="hireBtn" Width="365px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Input Customer ID" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Location:</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox1" runat="server" Height="86px" Width="365px" TextMode=MultiLine style="resize:none"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Input location" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Date:</td>
            <td class="auto-style7">
                <asp:TextBox ID="TextBox2" runat="server" Width="365px"></asp:TextBox>
                <asp:ImageButton ID="calImg" runat="server" ImageUrl="~/CalenderImg/calendar-image-icon-9.jpg" ImageAlign="AbsBottom" width="32px" Height="33px" OnClick="calImg_Click"/>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Input Date" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style7">
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" ValidationGroup="hireBtn" />
            </td>
            <td class="auto-style4">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="hireBtn" />
            </td>
        </tr>
    </table>
</asp:Content>
