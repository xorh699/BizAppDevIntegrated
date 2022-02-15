<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeListMoreInfo.aspx.cs" Inherits="BizAppDev.EmployeeListMoreInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1" style="text-align:center;">Employee List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3" style="margin-left:100px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/EmployeeList.aspx">Employee List</a></li>
                  <li class="breadcrumb-item">Employee More Info</li>
                  
                </ol>
              </nav>
            </div>
          </div>
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:100px;">
                <div class="col-md-6 col-lg-3" style="left: 0px; top: 0px; height: 516px">
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="EmpID" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand">
                        <EditItemTemplate>
                            <div class="card" style="margin-right: 30px; width:600px; height:423px; left: 0px; top: 0px;">
                    <div class="card-body">
                      <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." width="170" height="140" style="margin-right:10px;">
                        <div class="ms-3">
                            EmpID:
                            <asp:Label ID="EmpIDLabel" runat="server" Text='<%# Eval("EmpID") %>' />
                            <br />
                            EmpName:
                            <asp:Label ID="EmpNameLabel" runat="server" Text='<%# Eval("EmpName") %>' />
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
                            Position:
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Priest</asp:ListItem>
                                <asp:ListItem>Advisor</asp:ListItem>
                                <asp:ListItem>Packer</asp:ListItem>
                                <asp:ListItem>Customer Support</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            Password:
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" class="btn btn-secondary" style="color: white;"/> 
                            &nbsp;

                            <asp:Button ID="Button1" runat="server" CommandName="cancel" Text="Cancel" class="btn btn-secondary" style="color: white;"/>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="card" style="margin-right: 30px; width:600px; height:300px;">
                    <div class="card-body">
                      <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." width="170" height="140" style="margin-right:10px;">
                        <div class="ms-3">
                            EmpID:
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpID") %>' />
                            <br />
                            EmpName:
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("EmpName") %>' />
                            <br />
                            NRIC:
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("NRIC") %>' />
                            <br />
                            Birthdate:
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Birthdate") %>' />
                            <br />
                            Gender:
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Gender") %>' />
                            <br />
                            Contactno:
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Contactno") %>' />
                            <br />
                            Email:
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Email") %>' />
                            <br />
                            Address:
                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Address") %>' />
                            <br />
                            Position:
                            <asp:Label ID="PositionLabel" runat="server" Text='<%# Eval("Position") %>' />
                            <br />
                            Password:
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            <br />
                            <asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="edit" class="btn btn-secondary" style="color: white;"/> <a href="EmployeeList.aspx" class="btn btn-primary" style="color: white;">Back</a>
                            </div>
                          </div>
                        </div>
                                </div>
                            
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                  </div>
                </div>
                        </section>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Employee] WHERE ([EmpID] = @EmpID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="EmpID" QueryStringField="employeeID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

    </form>



</asp:Content>
