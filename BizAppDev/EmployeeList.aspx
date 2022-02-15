<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="BizAppDev.EmployeeList" %>
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
                <ol class="breadcrumb mb-0 py-3" style="margin-left:30px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/EmployeeList.aspx">Employee List For Staff Allocation</a></li>
                  
                </ol>
              </nav>
            </div>
          </div>
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">All</asp:ListItem>
                                <asp:ListItem value="2">Advisor</asp:ListItem>
                                <asp:ListItem value="3">Priest</asp:ListItem>
                                <asp:ListItem value="4">Packer</asp:ListItem>
                                <asp:ListItem value="5">Customer Support</asp:ListItem>
                            </asp:DropDownList>
        <br />
        Total number of staff: <asp:Label ID="lbl_noofstaff" runat="server" Text=""></asp:Label>
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:10px;">
                <div class="col-md-6 col-lg-3">

                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnDeleteCommand="DataList1_DeleteCommand" OnItemCommand="DataList1_ItemCommand" RepeatColumns="3" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div class="card" style="margin-right: 30px; width:400px;">
                    <div class="card-body">
                      <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." style="margin-bottom:90px;">
                        <div class="ms-3">
                          <h4>
                              <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                            </h4>
                          <p>
                              <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EmpID") %>'></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lbl_position" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                            </p>
                            <p class="text-muted mb-0">
                                <asp:Button ID="Button1" runat="server" Text="More Information" CommandName="More" class="btn btn-primary" style="color: white; "/> 
                                <asp:Button ID="LinkBtnDelete" runat="server" class="btn btn-secondary" CommandName="Delete" Text="Delete" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" style="color: white;"/>
                                 </p>
                            <p class="text-muted mb-0">
                                &nbsp;</p>
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


                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>

    </form>



</asp:Content>
