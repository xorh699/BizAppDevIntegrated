<%@ Page Title="" Language="C#" MasterPageFile="~/nonmembermaster.Master" AutoEventWireup="true" CodeBehind="nonmembercheckout.aspx.cs" Inherits="BizAppDev.nonmembercheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- Choices CSS-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/styles/choices.min.css">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/style.default.premium.2a30c8f8.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/custom.0a822280.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/favicon.3903ee9d.ico">
   
  
    <style type="text/css">
        .auto-style2 {
            width:741px ;
        }
        .auto-style3 {
            width: 741px;
        }
       .autoComplete_wrapper{
           margin-left:250px;
       }
       .Calendar2{
           margin-left:250px;
       }
    </style>
    
    <table class="autoComplete_wrapper" HorizontalAlign="Center" style="margin-top:120px;">
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Height="104px" Width="1483px" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" ShowFooter="True">
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
                <h3>&nbsp;</h3>
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
</asp:Content>
