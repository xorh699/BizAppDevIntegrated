<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="AdvisorsView.aspx.cs" Inherits="BizAppDev.AdvisorsView" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Advisors Appointment</h2>
    <p>
        <asp:GridView ID="gvAdvisor" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gvAdvisor_RowCancelingEdit" OnRowDeleting="gvAdvisor_RowDeleting" OnRowEditing="gvAdvisor_RowEditing" OnRowUpdating="gvAdvisor_RowUpdating" Width="1000px" ShowHeaderWhenEmpty="True" >
            <Columns>
                <asp:BoundField DataField="CustID" HeaderText="Customer ID" ReadOnly="True" />
                <asp:BoundField DataField="ID" HeaderText="Appointment ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" width="300px" Height="200px" TextMode=MultiLine style="resize:none" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" width="300px" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mode">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlMode" runat="server" DataSourceID="SqlDataSource1" DataTextField="Mode" DataValueField="Mode" SelectedValue='<%# Bind("Mode") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [Mode] FROM [AdvisorHire]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Mode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
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
                <div style="text-align:center"><asp:HyperLink runat="server" NavigateUrl="HiringAdvisor.aspx" Text="Hire an Advisor?"></asp:HyperLink></div>
            </EmptyDataTemplate>
        </asp:GridView>
    </p>
</asp:Content>
