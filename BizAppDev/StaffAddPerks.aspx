<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StaffAddPerks.aspx.cs" Inherits="BizAppDev.StaffAddPerks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="card-body">
                      <p class="text-sm">Create new perk</p>
                      <form class="form-horizontal" runat="server">

                        <div class="row gy-2 mb-4">
                          <label class="col-sm-3 form-label" for="inputHorizontalElOne">Perk name</label>
                          <div class="col-sm-9">
                              <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control" placeholder="Enter perk name"></asp:TextBox>
                          </div>
                        </div>
                        <div class="row gy-2 mb-4">
                          <label class="col-sm-3 form-label" for="inputHorizontalElTwo">Perk description</label>
                          <div class="col-sm-9">
                              <asp:TextBox ID="tb_desc" runat="server" CssClass="form-control" placeholder="Enter perk description"></asp:TextBox>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-sm-9 ms-auto">
                              <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Submit_Click"/>
                          </div>
                        </div>
                      </form>
                    </div>
</asp:Content>
