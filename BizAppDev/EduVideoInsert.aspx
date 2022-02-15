<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="EduVideoInsert.aspx.cs" Inherits="BizAppDev.EduVideoInsert" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Educational Videos</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Category:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="400px">
                    <asp:ListItem>Select a Category</asp:ListItem>
                    <asp:ListItem>Chinese New Year</asp:ListItem>
                    <asp:ListItem>Qing Ming Festival</asp:ListItem>
                    <asp:ListItem>Mid Authumn Festival</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_cat" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Please enter a category" ForeColor="Red" ValidationGroup="insert" InitialValue="Select a Category"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Description:</td>
            <td class="auto-style3">
                <asp:TextBox ID="tb_vidDesc"  runat="server" Height="106px" Width="400px" TextMode="MultiLine" style="resize:none"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_vidDesc" runat="server" ControlToValidate="tb_vidDesc" ErrorMessage="Please enter a description" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Video:</td>
            <td class="auto-style3">
                <asp:FileUpload ID="eduVidUpload" runat="server" Width="400px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Video" runat="server" ControlToValidate="eduVidUpload" ErrorMessage="Select a video file" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                <br />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="File size must not exceed 100MB " ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="insert"></asp:CustomValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <br />
                <asp:Button ID="eduInsert" runat="server" OnClick="eduInsert_Click" Text="Insert Video" Width="150px" ValidationGroup="insert" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
            </td>
        </tr>
        </table>
    <br />
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
        <asp:GridView ID="gv_eduVid" runat="server" AutoGenerateColumns="False" DataKeyNames="VidID" DataSourceID="SqlDataSource3" Width="1000px" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="VidID" HeaderText="Video ID" InsertVisible="False" ReadOnly="True" SortExpression="VidID" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" textmode="MultiLine" style="resize:none" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Width="300px" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                    <video height="250px" width="350px" controls style="display:block">
                        <source src='<%#Eval("Path")%>' type="video/mp4"/>
                    </video>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
          <EmptyDataTemplate>
            <div align="center">No records found.</div>
          </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [EducationVideo] WHERE ([Category] = @Category)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSort" Name="Category" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [EducationVideo]" DeleteCommand="DELETE FROM [EducationVideo] WHERE [VidID] = @VidID" InsertCommand="INSERT INTO [EducationVideo] ([Category], [Description], [Path]) VALUES (@Category, @Description, @Path)" UpdateCommand="UPDATE [EducationVideo] SET [Category] = @Category, [Description] = @Description, [Path] = @Path WHERE [VidID] = @VidID">
            <DeleteParameters>
                <asp:Parameter Name="VidID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Category" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Path" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Category" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Path" Type="String" />
                <asp:Parameter Name="VidID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
