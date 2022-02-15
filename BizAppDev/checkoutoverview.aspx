
<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="checkoutoverview.aspx.cs" Inherits="BizAppDev.checkoutoverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <style type="text/css">
        .auto-style2 {
            width: 153px;
        }
        .auto-style3 {
            width: 184px;
        }
        .auto-style4 {
            width: 33%
        }
        .auto-style5 {
            width: 163px;
        }
        .auto-style6 {
            width: 183px;
        }
        .auto-style7 {
            width: 103%
        }
        .ordersum{
            margin-left:75px;
            font-size:18px;
           
        }
        .auto-style8 {
            width: 44px;
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
  <h1>Please check all informations and products are correct</h1>
  <a href="">Order Overview</a>
</div>
 
    <div class="ordersum">
  <div layout="column" layout-fil ng-controller="DemoController as vm">
    <md-toolbar class="md-primary" layout="row" layout-align="start" layout-padding>
      <div class="md-toolbar-tools" layout="row">
        </div>

     
<md-content layout="column" flex md-scroll-y class="md-background md-hue-1">
        <div layout="row" layout-align="center" >
        <md-content layout="column" flex="90" flex-sm="70" flex-md="50" flex-lg="50" flex-gt-lg="40" class="md-whiteframe-2dp">
            <div layout="column" layout-padding layout-align="start">
    <div layout="row" layout-align="start">
        <div class="md-title"> Order Summary - #<asp:Label ID="Labelorderii" runat="server" Text="Label" Width="308px"></asp:Label> <br />
        </div>
                </div>
    </div>
                <br />
                <table class="auto-style4" border="0">
                    <tr>
                        <td class="auto-style5" style="font-size:18px;">QUANTITY</td>
                        <td class="auto-style6"style="font-size:18px;">PRODUCT</td>
                        <td class="auto-style8"style="font-size:18px;"> PRICE</td>
                    </tr>
                </table>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="31%" BorderStyle="None">
                    <ItemTemplate>
                       
                        <table class="auto-style7" border="0">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="quantityLabel" runat="server" style="font-size:18px;" Text='<%# Eval("quantity") %>' />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="Product_NameLabel" runat="server" style="font-size:18px;"  Text='<%# Eval("Product_Name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="priceLabel" runat="server" style="font-size:18px;" Text='<%# Eval("price") %>' />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT [quantity], [Product_Name], [price] FROM [orderdetails] WHERE ([orderid] = @orderid)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="orderid" QueryStringField="orderid" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Label ID="lbldelop" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lbldeldate" runat="server" Text="Label"></asp:Label>
    <br>
                 <td>
                    
                  Grand Total:$ <asp:Label  ID="Labelgg" runat="server" Text="Label"></asp:Label>
                         
                   <br />
                  
                   <asp:Label ID="Labeldisc" runat="server"></asp:Label>
                       <form id="form1">
                        <button type="submit">Pay</button>
                    </form>
                    <script src="https://js.stripe.com/v3/"></script>
                     <script>
                         var stripe = Stripe('pk_test_51KHh6JKpf4tgYB9KQPNyK7sTbJbBHRpAOcPdmWJNcnrOwiTbW1YKi5dTgZpd9FxkCNPlcSw4cURmZQCuH1uLnGvN00UzUnEkXO');
                         var form = document.getElementById("form1");
                        
                         form.addEventListener('submit', function (e){
                             e.preventDefault();

                             stripe.redirectToCheckout({ sessionId: "<%=sessionIds%>" });
                         })
                     </script>
  

</div>
        </md-content>
    </div>
</md-content>
  </div>
</div>
  
 
</asp:Content>