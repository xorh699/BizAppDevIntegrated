<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="BizAppDev.Customer1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1">Customers</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/Customer.aspx">Customer</a></li>
                  
                </ol>
              </nav>
            </div>
          </div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <div class="col-md-4">
                  <div class="card text-white bg-primary" style="height:270px; width:300px;">
                    
                    <div class="card-body">
                      
                      <p class="card-text">
                          <h5 class="card-title">
                          <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("Cust_ID") %>'></asp:Label>
                          ,
                          <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("First_Name") %>'></asp:Label>
                        </h5>

                          Customer Email:
                          <asp:Label ID="lbl_email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>

                          <p>
                          </p>
                          <p class="card-text">
                              Customer Contact:
                              <asp:Label ID="lbl_contact" runat="server" Text='<%# Eval("PhoneNo") %>'></asp:Label>
                          </p>
                          <p class="card-text">
                              Member status:<asp:Label ID="lbl_member" runat="server"></asp:Label>
                          </p>
                          <p class="card-text">
                              <asp:Button ID="btn_more" runat="server" class="btn btn-secondary" CommandName="View" style="color: white;" Text="More Information" />
                          </p>

                      </p>
                        
                    </div>
                  </div>
                 </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
    </form>
</asp:Content>
