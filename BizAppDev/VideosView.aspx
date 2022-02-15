<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="VideosView.aspx.cs" Inherits="BizAppDev.VideosView" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Educational Videos</h2>
    <p>&nbsp;Filter By:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlSort" runat="server">
        <asp:ListItem Value="Default">Default</asp:ListItem>
        <asp:ListItem Value="Chinese New Year">Chinese New Year</asp:ListItem>
        <asp:ListItem>Mid Authumn Festival</asp:ListItem>
        <asp:ListItem>Qing Ming Festival</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit " />
    </p>

    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VidID" DataSourceID="SqlDataSource1" Width="1000px" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="VidID" HeaderText="Video ID" InsertVisible="False" ReadOnly="True" SortExpression="VidID" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ItemStyle-Width="300px" />
            <asp:TemplateField>
            <ItemTemplate>
                <video height="250px" width="350px" controls style="display:block">
                    <source src='<%#Eval("Path")%>' type="video/mp4"/>
                </video>
            </ItemTemplate>
        </asp:TemplateField>        
        </Columns>
        <EmptyDataTemplate>
            <div align="center">No records found.</div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [EducationVideo]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [EducationVideo] WHERE ([Category] = @Category)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSort" Name="Category" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
