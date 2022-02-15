<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustViewOrders.aspx.cs" Inherits="BizAppDev.CustViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
   .tabset{
    margin-left:20%;
    margin-top:10%;
}
.tabset > input[type="radio"] {
  position: absolute;
  left: -200vw;
}

.tabset .tab-panel {
  display: none;
}

.tabset > input:first-child:checked ~ .tab-panels > .tab-panel:first-child,
.tabset > input:nth-child(3):checked ~ .tab-panels > .tab-panel:nth-child(2),
.tabset > input:nth-child(5):checked ~ .tab-panels > .tab-panel:nth-child(3),
.tabset > input:nth-child(7):checked ~ .tab-panels > .tab-panel:nth-child(4),
.tabset > input:nth-child(9):checked ~ .tab-panels > .tab-panel:nth-child(5),
.tabset > input:nth-child(11):checked ~ .tab-panels > .tab-panel:nth-child(6) {
  display: block;
}

/*
 Styling
*/
body {
  font: 16px/1.5em "Overpass", "Open Sans", Helvetica, sans-serif;
  color: #333;
  font-weight: 300;
}

.tabset > label {
  position: relative;
  display: inline-block;
  padding: 15px 15px 25px;
  border: 1px solid transparent;
  border-bottom: 0;
  cursor: pointer;
  font-weight: 600;
}

.tabset > label::after {
  content: "";
  position: absolute;
  left: 15px;
  bottom: 10px;
  width: 22px;
  height: 4px;
  background: #8d8d8d;
}

.tabset > label:hover,
.tabset > input:focus + label {
  color: #06c;
}

.tabset > label:hover::after,
.tabset > input:focus + label::after,
.tabset > input:checked + label::after {
  background: #06c;
}

.tabset > input:checked + label {
  border-color: #ccc;
  border-bottom: 1px solid #fff;
  margin-bottom: -1px;
}

.tab-panel {
  padding: 30px 0;
  border-top: 1px solid #ccc;
  min-width:900px;
}

/*
 Demo purposes only
*/
*,
*:before,
*:after {
  box-sizing: border-box;
}



.tabset {
  max-width: 65em;
}
    </style>
<!-- 
  
  Radio version of tabs.

  Requirements:
  - not rely on specific IDs for CSS (the CSS shouldn't need to know specific IDs)
  - flexible for any number of unkown tabs [2-6]
  - accessible

  Caveats:
  - since these are checkboxes the tabs not tab-able, need to use arrow keys

  Also worth reading:
  http://simplyaccessible.com/article/danger-aria-tabs/
-->


    
    
    <asp:SqlDataSource ID="Accepted" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [orderdetails] WHERE (([Cust_ID] = @Cust_ID) AND ([OrderStatus] = @OrderStatus))">
        <SelectParameters>
            <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
            <asp:Parameter DefaultValue="Accepted" Name="OrderStatus" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="InPreparation" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [orderdetails] WHERE (([Cust_ID] = @Cust_ID) AND ([OrderStatus] = @OrderStatus))">
        <SelectParameters>
            <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
            <asp:Parameter DefaultValue="In preparation" Name="OrderStatus" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="Delivered" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [orderdetails] WHERE (([Cust_ID] = @Cust_ID) AND ([OrderStatus] = @OrderStatus))">
        <SelectParameters>
            <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
            <asp:Parameter DefaultValue="Delivered" Name="OrderStatus" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="ParentDS" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [orderdetails] WHERE (([Cust_ID] = @Cust_ID) AND ([OrderStatus] = @OrderStatus))">
        <SelectParameters>
            <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
            <asp:Parameter DefaultValue="Out for delivery" Name="OrderStatus" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
<div class="tabset">

  <!-- Tab 1 -->
  <input type="radio" name="tabset" id="tab1" aria-controls="marzen" checked>
  <label for="tab1">Accepted</label>
  <!-- Tab 2 -->
  <input type="radio" name="tabset" id="tab2" aria-controls="rauchbier">
  <label for="tab2">In Preparation</label>
      <!-- Tab 3 -->

      <input type="radio" name="tabset" id="tab3" aria-controls="expired">
  <label for="tab3">Out for delivery</label>

          <input type="radio" name="tabset" id="tab4" aria-controls="delivered">
  <label for="tab4">Delivered</label>

  
  <div class="tab-panels">
    <section id="marzen" class="tab-panel">
    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="serialno" DataSourceID="Accepted" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="orderid" SortExpression="orderid" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product_ID" SortExpression="Product_ID" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            <asp:BoundField DataField="deliveryoption" HeaderText="deliveryoption" SortExpression="deliveryoption" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" SortExpression="deliverydate" />
            <asp:BoundField DataField="grandtotal" HeaderText="grandtotal" SortExpression="grandtotal" />
            <asp:BoundField DataField="discountedtotal" HeaderText="discountedtotal" SortExpression="discountedtotal" />
            <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" SortExpression="OrderStatus" />
            <asp:BoundField DataField="serialno" HeaderText="serialno" InsertVisible="False" ReadOnly="True" SortExpression="serialno" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

  </section>
      <section id="inpreparation" class="tab-panel">
           
     <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="serialno" DataSourceID="InPreparation" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="orderid" SortExpression="orderid" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product_ID" SortExpression="Product_ID" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            <asp:BoundField DataField="deliveryoption" HeaderText="deliveryoption" SortExpression="deliveryoption" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" SortExpression="deliverydate" />
            <asp:BoundField DataField="grandtotal" HeaderText="grandtotal" SortExpression="grandtotal" />
            <asp:BoundField DataField="discountedtotal" HeaderText="discountedtotal" SortExpression="discountedtotal" />
            <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" SortExpression="OrderStatus" />
            <asp:BoundField DataField="serialno" HeaderText="serialno" InsertVisible="False" ReadOnly="True" SortExpression="serialno" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
      </section>
    <section id="outfordelivery" class="tab-panel">
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="serialno" DataSourceID="ParentDS" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="orderid" SortExpression="orderid" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product_ID" SortExpression="Product_ID" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            <asp:BoundField DataField="deliveryoption" HeaderText="deliveryoption" SortExpression="deliveryoption" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" SortExpression="deliverydate" />
            <asp:BoundField DataField="grandtotal" HeaderText="grandtotal" SortExpression="grandtotal" />
            <asp:BoundField DataField="discountedtotal" HeaderText="discountedtotal" SortExpression="discountedtotal" />
            <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" SortExpression="OrderStatus" />
            <asp:BoundField DataField="serialno" HeaderText="serialno" InsertVisible="False" ReadOnly="True" SortExpression="serialno" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
  </section>
    <section id="delivered" class="tab-panel">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="serialno" DataSourceID="Delivered" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="orderid" SortExpression="orderid" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product_ID" SortExpression="Product_ID" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            <asp:BoundField DataField="deliveryoption" HeaderText="deliveryoption" SortExpression="deliveryoption" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" SortExpression="deliverydate" />
            <asp:BoundField DataField="grandtotal" HeaderText="grandtotal" SortExpression="grandtotal" />
            <asp:BoundField DataField="discountedtotal" HeaderText="discountedtotal" SortExpression="discountedtotal" />
            <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" SortExpression="OrderStatus" />
            <asp:BoundField DataField="serialno" HeaderText="serialno" InsertVisible="False" ReadOnly="True" SortExpression="serialno" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </section>

  </div>
  
</div>

</asp:Content>

   
