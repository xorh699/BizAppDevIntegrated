<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="HiringAdvisor.aspx.cs" Inherits="BizAppDev.HiringAdvisor" %>
 
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 251px;
        }
        .auto-style3 {
            width: 251px;
            height: 44px;
        }
        .auto-style4 {
            height: 44px;
        }
        .auto-style5 {
            width: 458px;
        }
        .auto-style6 {
            height: 44px;
            width: 458px;
        }
        .auto-style7 {
            width: 251px;
            height: 33px;
        }
        .auto-style8 {
            width: 458px;
            height: 33px;
        }
        .auto-style9 {
            height: 33px;
        }
    </style>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Hire an Advisor</h2>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Customer ID:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Customer ID" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Description of Issue(s):</td>
            <td class="auto-style5">
                <asp:TextBox ID="tbAdDesc" runat="server" Height="150px" Width="400px" TextMode=MultiLine style="resize:none"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbAdDesc" ErrorMessage="Issue(s) faced" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Mode:</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlAdMode" runat="server" Width="410px">
                    <asp:ListItem Value="0" Text="Select Mode"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Online"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Physical"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAdMode" ErrorMessage="Select a mode of appointment" ForeColor="Red" InitialValue="0" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Date:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tbAdDate" runat="server" Width="400px"></asp:TextBox>
                <asp:ImageButton ID="calImg" runat="server" ImageUrl="~/CalenderImg/calendar-image-icon-9.jpg" ImageAlign="AbsBottom" width="32px" OnClick="calImg_Click" Height="33px"/>
                <asp:Calendar ID="AdvisorDate" runat="server" Height="250px" Width="300px" OnSelectionChanged="AdvisorDate_SelectionChanged" OnDayRender="AdvisorDate_DayRender" ></asp:Calendar>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbAdDate" ErrorMessage="Select a date" ForeColor="Red" ValidationGroup="hireBtn"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">
                <br />
                <asp:Button ID="hireBtn" runat="server" OnClick="hireBtn_Click" Text="Submit" Width="150px" ValidationGroup="hireBtn" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="hireBtn" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
