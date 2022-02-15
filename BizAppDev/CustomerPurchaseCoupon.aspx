<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerPurchaseCoupon.aspx.cs" Inherits="BizAppDev.CustomerPurchaseCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="CouponPurchase">
    </asp:DataList>
    <asp:SqlDataSource ID="CouponPurchase" runat="server"></asp:SqlDataSource>
</asp:Content>
