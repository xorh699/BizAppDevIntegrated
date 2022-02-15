<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Orderstatus.aspx.cs" Inherits="BizAppDev.Orderstatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Processing Order</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb" style="left: 0px; top: 0px">
            <li class="breadcrumb-item">Order management</li>
            <li class="breadcrumb-item active"><a href="Orderstatus.aspx">Processing Order</a></li>
        </ul>
    </div>
     <form id="form1" runat="server">
                  
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                <div class="col-md-6 col-lg-3" >
                    <h2>&nbsp;</h2>
                    
                    <div style="margin-left:20px; align-items:flex-start;"> &nbsp;&nbsp;&nbsp;Order Status: <asp:DropDownList ID="ddl_Orderstatus" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="All" Value="" />
                    <asp:ListItem Text="Accepted" Value="Accepted" />
                    <asp:ListItem Text="In preparation" Value="In preparation" />
                    <asp:ListItem Text="Out for delivery" Value="Out for delivery" />
                    <asp:ListItem Text="Delivered" Value="Delivered" />
                     </asp:DropDownList></div><br />
                    
        
                    <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2"  DataKeyField="OrderID" style="width:1500px; margin-left:20px; margin-bottom:50px;" OnDeleteCommand="DataList2_DeleteCommand" OnEditCommand="DataList2_EditCommand">
                        <ItemTemplate>
                            <div class="card">
                            <div class="card-body">
                            OrderID:
                            <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                            <br />                          
                            Delivery Date:
                            <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("deliverydate") %>' />
                            <br />                         
                            OrderStatus:
                            <asp:Label ID="OrderStatusLabel" runat="server" Text='<%# Eval("OrderStatus") %>' />
                            <br />
                            <br />
                              <asp:Button ID="btn_details" runat="server" class="btn btn-primary btn-sm" Text="Details" CommandName ="edit"/>
                            <asp:Button ID="btn_delete" runat="server" class="btn btn-primary btn-sm" Text="Delete" CommandName ="Delete" OnClientClick="if (!confirm('Would you like to delete?')) return false;"/>
                               </div>
                                </div>
                            </ItemTemplate>
                  
                              </asp:DataList>
                            <br />

                      
             <asp:SqlDataSource id="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM Orderdetails WHERE OrderStatus != 'Pending'" FilterExpression="OrderStatus='{0}'">
                <FilterParameters>
                    <asp:ControlParameter Name="OrderStatus" ControlId="ddl_Orderstatus" PropertyName="SelectedValue"/>
                </FilterParameters>
            </asp:SqlDataSource>
                    
                    </div>
                  </div>
                </div>
    </form>
</asp:Content>

