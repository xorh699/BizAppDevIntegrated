<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="BizAppDev.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server" style="width:1000px">
    <div class="content-inner w-100" style="width:1000px;">
          <!-- Page Header-->
          <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1">Profile</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3">
                  <li class="breadcrumb-item"><a class="fw-light" href="index.html">Home</a></li>
                  <li class="breadcrumb-item active fw-light" aria-current="page">Profile</li>
                </ol>
              </nav>
            </div>
          </div>
        <div class="container-fluid">

              <div class="row">
                  <div class="col-lg-4" style="width:300px;">
                      <div class="card card-profile">
                    <div class="card-header" style="background-image: url(/Image/backgroundimg.jpg);" style="height: 9rem; background-position: center; background-size: cover;"></div>
                    <div class="card-body text-center"><img class="card-profile-img" src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/avatar-7.9355d8f3.jpg" title="..." style="max-width: 8rem;
    margin-top: -6rem;
    margin-bottom: 1rem;
    border: 3px solid #fff;
    border-radius: 100%;">
                  <asp:DataList ID="DataList2" runat="server" DataKeyField="AdmID" DataSourceID="SqlDataSource1" Width="324px">
                      <ItemTemplate>
                  
                      <h3 class="mb-3" style="margin-right:100px;">
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                        </h3>
                      <p class="mb-4" style="margin-right:80px;">
                          <asp:Label ID="Label2" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </p>
                      <button class="btn btn-outline-dark btn-sm" style="margin-right:100px;"><i class="fab fa-twitter"></i> Follow</button>
                    </div>
                  
        </div>
                          </ItemTemplate>
                      </asp:DataList>
                      </div>
        </div>
                  
        </div>
                  <div class="col-lg-8">
                                    <div class="card">
                    <div class="card-header" style="margin-left:80px;">
                        <asp:DataList ID="DataList1" runat="server" DataKeyField="AdmID" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand">
                            <EditItemTemplate>
                                Employee ID:
                                <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("AdmID") %>'></asp:Label>
                                <br />
                                Employee Name:
                                <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                <br />
                                NRIC:<asp:Label ID="lbl_nric" runat="server" Text='<%# Eval("NRIC") %>'></asp:Label>
                                <br />
                                Birthdate:<asp:TextBox ID="tb_birthdate" runat="server" Text='<%# Eval("Birthdate") %>' TextMode="Date"></asp:TextBox>
                                <br />
                                Gender:<asp:Label ID="lbl_gender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                <br />
                                Contact No.:
                                <asp:TextBox ID="tb_contactno" runat="server" Text='<%# Eval("Contactno") %>' TextMode="Phone"></asp:TextBox>
                                <br />
                                Email:<asp:TextBox ID="tb_email" runat="server" Height="18px" Text='<%# Eval("Email") %>' TextMode="Email" Width="213px"></asp:TextBox>
                                <br />
                                Address:<asp:TextBox ID="tb_address" runat="server" Height="78px" Text='<%# Eval("Address") %>' TextMode="MultiLine" Width="205px"></asp:TextBox>
                                <br />
                                Password:<asp:TextBox ID="tb_password" runat="server" Height="17px" Text='<%# Eval("Password") %>' Width="178px"></asp:TextBox>
                                <br />
                                <asp:Button ID="btn_update" runat="server" CommandName="Update" Text="Update" class="btn btn-primary" style="color: white;"/>
                                <asp:Button ID="btn_back" runat="server" CommandName="cancel" Text="Cancel" class="btn btn-primary" style="color: white;"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                
                                Employee ID:
                                <asp:Label ID="EmpIDLabel" runat="server" Text='<%# Eval("AdmID") %>' />
                                <br />
                                Employee Name:
                                <asp:Label ID="EmpNameLabel" runat="server" Text='<%# Eval("AdmName") %>' />
                                <br />
                                NRIC:
                                <asp:Label ID="NRICLabel" runat="server" Text='<%# Eval("NRIC") %>' />
                                <br />
                                Birthdate:
                                <asp:Label ID="BirthdateLabel" runat="server" Text='<%# Eval("Birthdate") %>' />
                                <br />
                                Gender:
                                <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                                <br />
                                Contactno:
                                <asp:Label ID="ContactnoLabel" runat="server" Text='<%# Eval("Contactno") %>' />
                                <br />
                                Email:
                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                                <br />
                                Address:
                                <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                                <br />
                                Password:
                                <asp:Label ID="PositionLabel" runat="server" Text='<%# Eval("Password") %>' />
                                <br />
                                <asp:Button ID="btn_edit" runat="server" CommandName="edit" Text="Edit" class="btn btn-primary" style="color: white;"/>
<br />
                            </ItemTemplate>
                        </asp:DataList>
                        </div>
                      </div>
            </div>
        
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Admin] WHERE ([AdmName] = @AdmName)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="AdmName" QueryStringField="AdmName" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

    </form>
</asp:Content>
