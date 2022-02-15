<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerPoints.aspx.cs" Inherits="BizAppDev.CustomerPoints" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            width: 150px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>

    <h1><strong>Your Points</strong><br />
    </h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Points:</td>
            <td class="auto-style4">
                <asp:Label ID="lbl_Points" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Points tier:</td>
            <td>
                <asp:Label ID="lbl_TierName" runat="server"></asp:Label>
&nbsp;<asp:Button ID="btn_Perks" runat="server" OnClick="btn_Perks_Click" Text="View Perks" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Your coupons</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">Available coupons</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
