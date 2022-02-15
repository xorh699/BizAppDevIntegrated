<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="orders(lermin)(employee).aspx.cs" Inherits="BizAppDev.orders_lermin__employee_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
        <div class="card mb-0" style="margin-left:40px; width:1000px; margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Order for Products</h1>
                    </div>
                    
                        <div class="card-body">
        
        
            <asp:Label ID="lbl_alert" runat="server" ></asp:Label>
        
        <div class="breadcrumb-holder container-fluid" style="font-size:15px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Order Details</li>
        </ul>
    </div>
        <p>
             <h2 style="margin-left:230px;">Green = Delivered&nbsp;&nbsp;&nbsp;&nbsp; Red = In Progress</h2>
                            <p style="margin-left:150px;">
                                <asp:GridView ID="gv_orders" runat="server" AutoGenerateColumns="False" width="600px" OnRowDataBound="gv_orders_RowDataBound1" style="margin-left:150px;" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="1px" CellPadding="4" GridLines="Horizontal">
                                    <Columns>
                                        <asp:BoundField DataField="order_ID" HeaderText="Order ID" />
                                        <asp:BoundField DataField="prod_id" HeaderText="Product Name" />
                                        <asp:BoundField DataField="order_Quantity" HeaderText="Quantity " />
                                        <asp:BoundField DataField="order_Date" HeaderText="Delivery Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:BoundField DataField="status" HeaderText="status" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                            </p>
                            </div>
            </div>

     </form>



</asp:Content>
