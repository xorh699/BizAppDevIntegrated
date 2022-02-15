<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Eproductcust.aspx.cs" Inherits="BizAppDev.Eproductcust" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Product Customization</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Order management</li>
            <li class="breadcrumb-item active"><a href="Eproductcust.aspx">Product Customization</a></li>
        </ul>
    </div>
     <form id="form1" runat="server">
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                  <br />
                  <br />
                
                  <br />
                  <br />
                   
   
                    <asp:DataList ID="DataList8" runat="server" DataSourceID="SqlDataSource8"  DataKeyField="custID" OnDeleteCommand="DataList8_DeleteCommand" OnEditCommand="DataList8_EditCommand" style="width:1000px;">
                        <ItemTemplate>
                             <div class="card">
                            <div class="card-body">
                            Order ID:
                            <asp:Label ID="CustIDLabel" runat="server" Text='<%# Eval("CustID") %>' />
                            <br />                          
                            Preferred Date:
                            <asp:Label ID="PreferDateLabel" runat="server" Text='<%# Eval("date") %>' />
                            <br />                         
                            Collection Status:
                            <asp:Label ID="CollectStatusLabel" runat="server" Text='<%# Eval("status") %>' />
                            <br />
                            <br />
                              <asp:Button ID="btn_details" runat="server" class="btn btn-primary btn-sm" Text="Details" CommandName ="edit"/>
                            <asp:Button ID="btn_delete" runat="server" class="btn btn-primary btn-sm" Text="Delete" CommandName ="Delete" OnClientClick="if (!confirm('Would you like to delete?')) return false;"/>
                              </div>
                                 </div>
                            </ItemTemplate>
                  
                              </asp:DataList>
                          </p>
                          </div>
                    </div>
                            <br />

                      
             <asp:SqlDataSource id="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [ProductCust]">
           
            </asp:SqlDataSource>
                    
                    </div>
    </form>
</asp:Content>

