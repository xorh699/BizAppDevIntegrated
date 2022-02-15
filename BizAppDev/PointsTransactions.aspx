<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="PointsTransactions.aspx.cs" Inherits="BizAppDev.PointsTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="PTDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [PointsTransaction] WHERE ([PT_CustID] = @PT_CustID)">
        <SelectParameters>
            <asp:SessionParameter Name="PT_CustID" SessionField="CustID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div style="margin-left:20%;margin-top:20%;">
        <h1>Your points transactions</h1>
    <asp:GridView ID="GridView1" runat="server" style="width:1000px;border:solid 2px black;" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="PTDataSource" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="PTID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="PT_Reason" HeaderText="Reason" />
            <asp:BoundField DataField="PT_Points" HeaderText="Points added/subtracted" />
            <asp:BoundField DataField="PT_Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Transaction" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />

    </asp:GridView>
        </div>
</asp:Content>
