<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="PriestsView.aspx.cs" Inherits="BizAppDev.PriestsView" %>
 
    <style type="text/css">
        .auto-style1 {
            margin-right: 80px;
        }
    </style>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Booking Details</h2>
    <p>
        <asp:GridView ID="gvPriest" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gvPriest_RowCancelingEdit" OnRowDeleting="gvPriest_RowDeleting" OnRowEditing="gvPriest_RowEditing" OnRowUpdating="gvPriest_RowUpdating" CssClass="auto-style1" Width="1000px" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" ReadOnly="True" />
                <asp:BoundField DataField="ID" HeaderText="Booking ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Location">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" width="400px" height="200px" TextMode=MultiLine style="resize:none" Text ='<%# Bind("Location") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" width="400px" Text='<%# Bind("Location") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div align="center">No records found.</div>
                <div style="text-align:center"><asp:HyperLink runat="server" NavigateUrl="HiringPriest.aspx" Text="Hire a Priest?"></asp:HyperLink></div>
        </EmptyDataTemplate>
        </asp:GridView>
    </p>
</asp:Content>
