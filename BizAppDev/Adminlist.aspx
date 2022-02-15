<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adminlist.aspx.cs" Inherits="BizAppDev.Adminlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Admin List</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Employee management</li>
            <li class="breadcrumb-item active"><a href="Adminlist.aspx">Admin List</a></li>
        </ul>
    </div>
            
    <div style="align-items:flex-start;">
     <a href="Addemployee.aspx" class="btn btn-primary" style="color: white; margin-left:75px;"><i class="fa fa-plus"></i>Add</a><form id="form1" runat="server">         
         <asp:TextBox ID="tb_SearchAdm" style="margin-left: 1200px;" runat="server"></asp:TextBox>
          <asp:Button ID="BtnSearch"  class="btn btn-primary btn-sm" runat="server" Text="Search" OnClick="Button1_Click"/>
       </div>
&nbsp;<br />
&nbsp;<div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                <div class="col-md-6 col-lg-3" >

                    <asp:DataList ID="DataList5" runat="server" DataSourceID="SqlDataSource5"  DataKeyField="AdmID" style="width:1500px; margin-left:20px; margin-bottom:50px;" OnDeleteCommand="DataList5_DeleteCommand" OnEditCommand="DataList5_EditCommand" OnSelectedIndexChanged="DataList5_SelectedIndexChanged">
                        <ItemTemplate>
                            <div class="card">
                            <div class="card-body">
                                <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." style="width: 130px; margin-right:10px; height: 100px">
                             <div class="ms-3">
                            Emp ID:
                            <asp:Label ID="lbl_AdmID" runat="server" Text='<%# Eval("AdmID") %>' />
                            <br />
                           
                            Emp  Name:
                            <asp:Label ID="lbl_AdmName" runat="server" Text='<%# Eval("AdmName") %>' />
                            <br />
                            <br />
                            <asp:Button ID="btn_details" runat="server" class="btn btn-primary btn-sm" Text="Details" CommandName ="edit"/>
                            <asp:Button ID="btn_delete" runat="server" class="btn btn-primary btn-sm" Text="Delete" CommandName ="Delete" OnClientClick="if (!confirm('Would you like to delete?')) return false;"/>
                            <br />
                                 </div>
                                    </div>
                                </div>
                                                       
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                  </div>
                </div>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Admin]"></asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Admin]  WHERE ([AdmID] = @AdmID)"></asp:SqlDataSource>
   

    </form>
</asp:Content>
