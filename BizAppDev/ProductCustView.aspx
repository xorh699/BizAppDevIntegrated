<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="ProductCustView.aspx.cs" Inherits="BizAppDev.ProductCustView" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customization Details</h2>
    <asp:GridView ID="gvProdCust" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomizationID" OnRowCancelingEdit="gvProdCust_RowCancelingEdit" OnRowDeleting="gvProdCust_RowDeleting" OnRowEditing="gvProdCust_RowEditing" OnRowUpdating="gvProdCust_RowUpdating" Width="1000px" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="CustID" HeaderText="Customer ID" ReadOnly="True" />
            <asp:BoundField DataField="CustomizationID" HeaderText="Customization ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="Product Category">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_catview" runat="server" Width="110px" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" SelectedValue='<%# Bind("Category") %>' >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [Category] FROM [AvailableCustomization] WHERE ([Category] IS NOT NULL)"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Colour">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_colview" runat="server" Width="100px" DataSourceID="SqlDataSource2" DataTextField="Colour" DataValueField="Colour" SelectedValue='<%# Bind("Colour") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [Colour] FROM [AvailableCustomization]"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Colour") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Scent">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_stview" runat="server" Width="100px" DataSourceID="SqlDataSource3" DataTextField="Scent" DataValueField="Scent" SelectedValue='<%# Bind("Scent") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [Scent] FROM [AvailableCustomization] WHERE ([Scent] IS NOT NULL)"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Scent") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" width="120px" Height="50px" TextMode="MultiLine" style="resize:none" Text='<%# Bind("Fullname") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Fullname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Height="50px" TextMode="MultiLine" style="resize:none" Text='<%# Bind("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Contactno" HeaderText="Contact No" />
            <asp:TemplateField HeaderText="Collection Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                    <asp:Calendar ID="Calendar1" runat="server" Width="226px" OnDayRender="Calendar1_DayRender"></asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
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
            <div style="text-align:center"><asp:HyperLink runat="server" NavigateUrl="ProductCustomization.aspx" Text="Create a Product Customization?"></asp:HyperLink></div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
