<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MembershipMoreInfo.aspx.cs" Inherits="BizAppDev.MembershipMoreInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1">Membership Tier List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3">
                  <li class="breadcrumb-item">Membership Tier List</li>
                  <li class="breadcrumb-item"><a class="fw-light" href="~/MembershipTierList(employee).aspx">Membership Tier List Information</a></li>
                </ol>
              </nav>
            </div>
          </div>
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:100px;">
                <div class="col-md-6 col-lg-3">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand1" OnUpdateCommand="DataList1_UpdateCommand">
                        <EditItemTemplate>
                            <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1">Membership Tier List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3">
                  <li class="breadcrumb-item">Membership Tier List</a></li>
                  <li class="breadcrumb-item"><a class="fw-light" href="~/MembershipTierList.aspx">Membership Tier List Information</a></li>
                </ol>
              </nav>
            </div>
          </div>
                            <div class="card" style="margin-left:300px;width:500px;">
                            <img class="card-img-top img-fluid" src="https://restrictcontentpro.com/wp-content/uploads/2021/07/What-is-the-Difference-Between-a-Membership-and-a-Subscription-33803.png" alt="Card image cap" height="175" width="349">
                            <br />
                            <table class="w-100">
                                <tr>
                                    <td>Membership Tier ID: </td>
                                    <td>
                                        <asp:Label ID="lbl_tierID" runat="server" Text='<%# Eval("membership_id")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px">Membership Tier Name: </td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="tb_Name" runat="server" Height="23px" Text='<%# Eval("membership_name") %>' Width="161px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Membership Description:</td>
                                    <td>
                                        <asp:TextBox ID="tb_Desc" runat="server" Height="105px" Text='<%# Eval("membership_desc") %>' Width="391px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Membership Benefits:</td>
                                    <td>
                                        <asp:TextBox ID="tb_Benefits" runat="server" Height="102px" Text='<%# Eval("membership_benefits") %>' Width="386px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Membership Price:</td>
                                    <td>
                                        <asp:TextBox ID="tb_Price" runat="server" Text='<%# Eval("membership_price") %>' ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Membership Timeframe:</td>
                                    <td>
                                        <asp:TextBox ID="tb_length" runat="server" Text='<%# Eval("membership_length") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btn_Update" runat="server" class="btn btn-primary" CommandName="update" style="color: white;" Text="Update" />
                                        <asp:Button ID="btn_cancel" runat="server" class="btn btn-primary" CommandName="cancel" style="color: white;" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                                </div>
                            
                        </EditItemTemplate>
            <ItemTemplate>
                
                  <!-- Simple card-->
                  <div class="card" style="margin-left:300px;width:500px;">
                <img class="card-img-top img-fluid" src="https://restrictcontentpro.com/wp-content/uploads/2021/07/What-is-the-Difference-Between-a-Membership-and-a-Subscription-33803.png" alt="Card image cap" height="175" width="349">
                <br />
                <br />
                <br />
                      <div class="card-body">
                      <h5 class="card-title">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("membership_id") %>'></asp:Label>
                            ,
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("membership_name") %>'></asp:Label></h5>
                            <br />
                             <p class="card-text">Membership Tier List Description:
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("membership_desc") %>'></asp:Label></p>
                            <br />
                                 <p class="card-text">
                            Benefits:
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("membership_benefits") %>'></asp:Label></p>
                            <br />
                                     <p class="card-text">
                            Price:
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("membership_price") %>'></asp:Label> </p>
                               <p class="card-text">
                                   Period:
                                   <asp:Label ID="Label6" runat="server" Text='<%# Eval("membership_length") %>'></asp:Label>
                          </p>
                               <asp:Button ID="btn_more" runat="server" Text="Edit"  CommandName="edit" class="btn btn-primary" style="color: white;"/>
                          &nbsp;<a href="/MembershipTierList.aspx" class="btn btn-primary" style="color: white;">Back</a>
                          </div>
                      </div>
                    </div>
                
            </ItemTemplate>
                        
        </asp:DataList>
                     </div>
                </div>
                </div>
                    </section>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Membership] where membership_id = @memberID" CancelSelectOnNullParameter="false">
            <SelectParameters>
                <asp:QueryStringParameter Name="memberID" DbType = "String" Direction = "Input" QueryStringField="memberID" DefaultValue='<%= Request.QueryString["memberID"] %>' />
            </SelectParameters>
        </asp:SqlDataSource>
                 
     
        
        <br />

            </form>
</asp:Content>
