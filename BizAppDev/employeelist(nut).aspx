<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="employeelist(nut).aspx.cs" Inherits="BizAppDev.employeelist_nut_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1" style="margin-left:30px">Employee List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3" style="margin-left:30px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/EmployeeList.aspx">Employee List</a></li>
                  
                </ol>
              </nav>
            </div>
          </div>
     <a href="Addemployee.aspx" class="btn btn-primary" style="color: white; margin-left:60px;"><i class="fa fa-plus"></i>Add</a>
    <form id="form1" runat="server">
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                <div class="col-md-6 col-lg-3" >

                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"  DataKeyField="EmpID" style="width:1000px; margin-left:20px; margin-bottom:50px;" OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand">
                        <ItemTemplate>
                            EmpID:
                            <asp:Label ID="lbl_EmpID" runat="server" Text='<%# Eval("EmpID") %>' />
                            <br />
                           
                            EmpName:
                            <asp:Label ID="lbl_EmpName" runat="server" Text='<%# Eval("EmpName") %>' />
                            <br />
                            <br />
                            <asp:Button ID="btn_details" runat="server" Text="Details" CommandName ="edit"/>
                            <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName ="Delete"/>
                            <br />
                                                       
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                  </div>
                </div>
                        </section>


                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>

    </form>
</asp:Content>
