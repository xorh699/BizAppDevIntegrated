<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="BizAppDev.CustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br/>


    <div class="card">
                    <div class="card-body" style="width:1920px">
                      <h3 class="card-title">Your Profile</h3>
                      <div class="row gy-4">
                        <div class="col-sm-6 col-sm-6">
                          <label class="form-label">Username</label>               

                <asp:Label ID="lbl_Username" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-sm-6 col-sm-6">
                          <label class="form-label">Email address</label>
                <asp:Label ID="lbl_Email" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                          <label class="form-label">First Name</label>
                <asp:Label ID="lbl_FirstName" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                          <label class="form-label">Last name</label>
                <asp:Label ID="lbl_LastName" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-md-6">
                          <label class="form-label">Address</label>
                <asp:Label ID="lbl_Address" runat="server" class="form-control"></asp:Label>
                        </div>
                                                  <div class="col-md-6">
                          <label class="form-label">Date of Birth</label>
                <asp:Label ID="lbl_DOB" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-sm-6 col-md-4">
                          <label class="form-label">Phone number</label>
                <asp:Label ID="lbl_PhoneNo" runat="server" class="form-control"></asp:Label>
                        </div>
                        <div class="col-sm-6 col-md-3">
                          <label class="form-label">Gender</label>
                <asp:Label ID="lbl_Gender" runat="server" class="form-control"></asp:Label>
                        </div>

                        
                      </div></div>
                    <div class="card-footer text-end">
                        <asp:Button ID="btn_Edit" OnClick="btn_Edit_Click" class="btn btn-primary" runat="server" Text="Edit Profile" />
                    </div>
                  </div>

</asp:Content>
