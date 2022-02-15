<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Eorderinfo.aspx.cs" Inherits="BizAppDev.Eorderinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Processing Order</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Customer management</li>
            <li class="breadcrumb-item active"><a href="Eorderstatus.aspx">Processing Order</a></li>
        </ul>
    </div>
     <form id="form1" runat="server">
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                <div class="col-md-6 col-lg-3" >

                    <asp:DataList ID="DataList2" runat="server" onEditCommand="myListEditHandler"  
         onUpdateCommand="myListUpdateHandler" RepeatColumns="3" DataKeyField="OrderID"  onCancelCommand="myListCancelHandler" DataSourceID="SqlDataSource2" OnDeleteCommand="DataList2_DeleteCommand" >

                        <ItemTemplate>
                             <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                     
                        <div class="ms-3">
                               OrderID:
                               <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                               <br />
                               ProductID:
                               <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("Product_ID") %>' />
                               <br />
                               ProductName:
                               <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("Product_Name") %>' />
                               <br />
                               Price:
                               <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("price") %>' />
                               <br />
                               Quantity:
                               <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                               <br />
                               TotalPrice:
                               <asp:Label ID="TotalPriceLabel" runat="server" Text='<%# Eval("grandtotal") %>' />
                               <br />
                               OrderDate:
                               <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("deliverydate") %>' />
                               <br />
                               DeliveryOptions:
                               <asp:Label ID="DeliveryOptionsLabel" runat="server" Text='<%# Eval("deliveryoption") %>' />
                               <br />
                               OrderStatus:
                             <asp:Label ID="OrderStatusLabel" runat="server" Text='<%# Eval("OrderStatus") %>' />
                             <br />
                            <br />
                                    <asp:Button ID="Linkbutton3" runat="server" class="btn btn-primary btn-sm" commandname="Edit" text=' <%# "Edit" %>' />                    
                        </ItemTemplate>

                          <EditItemTemplate>
          <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                     
                        <div class="ms-3">
                            OrderID:
                               <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                               <br />
                               ProductID:
                               <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("Product_ID") %>' />
                               <br />
                               ProductName:
                               <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("Product_Name") %>' />
                               <br />
                               Price:
                               <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("price") %>' />
                               <br />
                               Quantity:
                               <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                               <br />
                               TotalPrice:
                               <asp:Label ID="TotalPriceLabel" runat="server" Text='<%# Eval("grandtotal") %>' />
                               <br />
                               OrderDate:
                               <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("deliverydate") %>' />
                               <br />
                               DeliveryOptions:
                               <asp:Label ID="DeliveryOptionsLabel" runat="server" Text='<%# Eval("deliveryoption") %>' />
                               <br />
                               OrderStatus:
                                 <asp:DropDownList ID="DropDownList2" runat="server">
                                   <asp:ListItem>Accepted</asp:ListItem>
                                   <asp:ListItem>In preparation</asp:ListItem>
                                   <asp:ListItem>Out for delivery</asp:ListItem>
                                   <asp:ListItem>Delivered</asp:ListItem>
                               </asp:DropDownList>
                               <br />
                               <br />                                        

               <asp:Button ID="Linkbutton1" CommandName="update" runat="server" class="btn btn-primary btn-sm" text="Update" />
               <asp:Button ID="Linkbutton2" CommandName="cancel" runat="server" class="btn btn-primary btn-sm" text="Cancel" />       
             </EditItemTemplate>
            
                    </asp:DataList>
                    </div>
                  </div>
                </div>
                        </section>


                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Orderdetails] WHERE ([OrderID] = @OrderID)">
                        <SelectParameters>
                  <asp:QueryStringParameter Name="OrderID" QueryStringField="OrderID" Type="String" />
              </SelectParameters>
                    </asp:SqlDataSource>

    </form>
     
</asp:Content>

