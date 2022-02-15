<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="BizAppDev.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style2 {
            width:741px ;
        }
        .auto-style3 {
            width: 741px;
        }
       .autoComplete_wrapper{
           margin-left:100px;
       }
       .Calendar2{
           margin-left:100px;
       }


.box {
  width: 40%;
  margin-right:200px;
  background: rgba(255,255,255,0.2);
  padding: 8px;
  border: 2px solid #fff;
  border-radius: 20px/50px;
  background-clip: padding-box;
  text-align: center;
}

.button {
  font-size: 1em;
  padding: 10px;
  color: rgba(0, 0, 0, 0.7);
  border: 2px solid rgba(0, 0, 0, 0.7);
  border-radius: 20px/50px;
  text-decoration: none;
  cursor: pointer;
  transition: all 0.3s ease-out;
  float:left;

}
.button:hover {
  background: #9c9c9c;
}

.overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: rgba(0, 0, 0, 0.7);
  transition: opacity 500ms;
  visibility: hidden;
  opacity: 0;
}
.overlay:target {
  visibility: visible;
  opacity: 1;
}

.popup {
  margin: 70px auto;
  padding: 20px;
  background: #fff;
  border-radius: 5px;
  width: 30%;
  position: relative;
  transition: all 5s ease-in-out;

}

.popup h2 {
  margin-top: 0;
  color: #333;
  font-family: Tahoma, Arial, sans-serif;
}
.popup .close {
  position: absolute;
  top: 20px;
  right: 30px;
  transition: all 200ms;
  font-size: 30px;
  font-weight: bold;
  text-decoration: none;
  color: #333;
}
.popup .close:hover {
  color: #06D85F;
}
.popup .content {
  max-height: 30%;
  overflow: scroll;
}

@media screen and (max-width: 700px){
  .box{
    width: 70%;
  }
  .popup{
    width: 70%;
  }
}
    </style>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- Choices CSS-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/styles/choices.min.css">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/style.default.premium.2a30c8f8.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/custom.0a822280.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/favicon.3903ee9d.ico">
    <link rel="stylesheet" href="css/home.css" />
    <div class="header">
    <h1>Select Delivery Option Before Paying
        </h1>
        <a href="checkout.aspx">CheckOut</a>
        </div>
    <table class="autoComplete_wrapper" HorizontalAlign="Center">
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Height="104px" Width="1068px" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" ShowFooter="True" >
                    <Columns>
                        <asp:ImageField DataImageUrlField="images" DataImageUrlFormatString="/images/{0}" ControlStyle-Width="100" ControlStyle-Height = "100">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Product_ID" HeaderText="ID" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product" />
                        <asp:BoundField DataField="quantity" HeaderText="quantity" />
                        <asp:BoundField DataField="Unit_Price" HeaderText="Unit Price" />
                        <asp:BoundField DataField="total" HeaderText="Total Price" />
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3" class="auto-style3">
                <asp:Calendar ID="Calendar2" runat="server" Height="280px"  OnDayRender="Calendar1_DayRender" Width="741px" CaptionAlign="NotSet">
                    <DayHeaderStyle HorizontalAlign="Center" />
                    <TitleStyle HorizontalAlign="Center" />
                </asp:Calendar>
            </td>
            <td class="auto-style2">
                <h3>Total</h3>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="183px">
                    <asp:ListItem>Door-Step</asp:ListItem>
                    <asp:ListItem>In-Store</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="tb_discountcode0" runat="server" placeholder="Enter Code(Optional)"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" BackColor="#333333" ForeColor="White" Height="28px" OnClick="Button1_Click" Text="Apply" Width="61px" />
                 <h2>Select owned coupon</h2>
<div class="box">
	<a class="button" href="#popup1">See list of Coupons</a>
</div>

<div id="popup1" class="overlay" >
	<div class="popup" style="min-width:1000px;" >
		<h2>Your owned coupons</h2>
		<a class="close" href="#">&times;</a>
		<div class="content" style="overflow:scroll; max-height:550px; min-width:900px;">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="AsgnID" DataSourceID="PersonalCoup" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="20" style="float:left;" OnItemCommand="DataList1_ItemCommand" >
                <ItemTemplate>
                    <div class="card" style="min-width:400px;">
                    <div class="card-body">
                      <h4 class="card-title"><asp:Label ID="coupNameLabel" runat="server" Text='<%# Eval("coupName") %>' /></h4>
                      <p class="card-text"><asp:Label ID="categoryLabel" runat="server" Text='<%# Eval("category") %>' />
                                                <p class="card-text">Discount: <asp:Label ID="discountLabel" runat="server" Text='<%# Eval("coupDiscount") %>' />%</p>


                      <p class="card-text"><asp:Label ID="AsgnIDLabel" runat="server" Text='<%# Eval("coupDesc") %>' />
</p>                                                        <asp:Button class="btn btn-outline-primary" runat="server" Text="Apply Coupon" ID="btn_Personal" CommandName="UseCoupon" />

                    <br /> <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />

                    </div>

                    <div class="card-footer text-muted">Expires: <asp:Label ID="Cust_IDLabel" runat="server" Text='<%# Eval("coupExpiry") %>' />
                        <asp:Label ID="coupQuantityLabel" runat="server" Text='<%# Eval("coupQuantity") %>' />

</div>
                  </div>



                </ItemTemplate>
    </asp:DataList>		</div>
	</div>
</div>
                <br />
                <asp:Label ID="lbl_couponcode" runat="server" Width="248px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <h3>OrderID:<asp:Label ID="lbl_orderid" runat="server" Text="Label"></asp:Label></h3>
                <h3>Order Date:<asp:Label ID="lbl_orderDate" runat="server" Text="Label"></asp:Label></h3>
                <h3>Delivery Date:<asp:Label ID="DeliveryDate" runat="server" Text="Label"></asp:Label></h3>
                <br />
                 <h3>GST(7%):   $<asp:Label ID="Labelgst" runat="server"></asp:Label>
                </h3>
                <h3>Grand Total:$<asp:Label ID="Labelgrandtotal" runat="server" Height="33px" Text="total" Width="185px"></asp:Label>   
                    
                </h3>
                <h3>Discounted Total:$<asp:Label ID="lbl_discountedprice" runat="server"></asp:Label>      </h3>
                
               <asp:Button ID="btn_pay" runat="server" Text="Pay" BackColor="#333333" ForeColor="White" Width="100px" OnClick="btn_pay_Click" />
            </td>
        </tr>
    </table>
       <asp:SqlDataSource ID="PersonalCoup" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [CustCoupon] WHERE (([Cust_ID] = @Cust_ID) AND ([coupQuantity] &gt; @coupQuantity))">
           <SelectParameters>
               <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
               <asp:Parameter DefaultValue="0" Name="coupQuantity" Type="Int32" />
           </SelectParameters>

    </asp:SqlDataSource>
</asp:Content>