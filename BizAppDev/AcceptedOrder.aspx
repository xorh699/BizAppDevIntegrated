<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AcceptedOrder.aspx.cs" Inherits="BizAppDev.AcceptedOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Pending Order</h2>
        </div>
       
    </header>
       
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Order management</li>
            <li class="breadcrumb-item active"><a href="AcceptedOrder.aspx">Pending Order</a></li>
        </ul>
    </div>
    <br />
     <form id="form1" runat="server">
                       <div class="container-fluid" style="min-width:1200px; margin-left:18%; ">
              <div class="row">                 
         <asp:GridView ID="GvOrder" runat="server" AutoGenerateColumns="False" class="table mb-0" style=" border:1.5px solid; " DataKeyNames="OrderID" OnRowEditing="GvOrder_RowEditing1" OnRowDeleting="GvOrder_RowDeleting">           
            <Columns>
      
                 <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />          
                 <asp:BoundField DataField="deliverydate" HeaderText="Delivery Date" SortExpression="deliverydate" />
                 <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" SortExpression="OrderStatus" />
                 <asp:CommandField ShowDeleteButton="True" DeleteText="Reject" EditText="Accept" ShowEditButton="True" />
       
                          </Columns>
         </asp:GridView>     
                        </div>
                      </div>              
        </form>
</asp:Content>
