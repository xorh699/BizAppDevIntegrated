<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerViewCoupon.aspx.cs" Inherits="BizAppDev.CustomerViewCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
            <link rel="stylesheet" href="/css/form.css" type="text/css" />
        @import url('https://fonts.googleapis.com/css?family=Oswald');


section{padding:5% 0;}
.alizarin{background:#e74c3c}
.amethyst{background:#9b59b6}
.emerald{background:#2ecc71}
.midnight-blue{background:#2c3e50}
.peter-river{background:#3498db}
.dl{background:#f0f0f0;padding:30px 0;border-radius:20px;position:relative;display:inline-block;}
.dl:before{content:" ";height:20px;width:20px;background:#ddd;border-radius:20px;position:absolute;left:50%;top:20px;margin-left:-10px}
.dl .brand{text-transform:uppercase;letter-spacing:3px;padding:10px 15px;margin-top:10px;text-align:center;min-height:100px}
.dl .discount{min-height:50px;position:relative;font-size:80px;line-height:80px;text-align:center;font-weight:700;padding:20px 15px 0;color:#f1c40f}
.dl .discount:after{content:" ";border-right:20px solid transparent;border-left:20px solid transparent;position:absolute;bottom:-20px;left:20%}
.dl .discount.alizarin:after{border-top:20px solid #e74c3c}
.dl .discount.peter-river:after{border-top:20px solid #3498db}
.dl .discount.emerald:after{border-top:20px solid #2ecc71}
.dl .discount.amethyst:after{border-top:20px solid #9b59b6}
.dl .discount .type{font-size:20px;letter-spacing:1px;text-transform:uppercase;margin-top:-30px}
.dl .descr{color:#999;margin-top:10px;padding:20px 15px}
.dl .ends{padding:0 15px;color:coral;margin-bottom:10px}
.dl .coupon{min-height:50px;text-align:center;text-transform:uppercase;font-weight:700;font-size:18px;padding:20px 15px}
.dl .coupon a.open-code{color:#16a085}
.dl .coupon .code{letter-spacing:1px;border-radius:4px;margin-top:10px;padding:10px 15px;color:#f1c40f;background:#f0f0f0}
.floatycontain {
    float:left;

}
.brand {
    height:160px;
}

.descr {
    height:160px;
}
.row {
    width: 100%;
    float:right;
    padding: 20px;
}   
.discount alizarin {
}
    </style>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="CouponRetrieve" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" CellPadding="40">
        <ItemTemplate>
        <div class="floatycontain">
<section id="labels">
  <div class="container">
	<div class="row">
        <div class="col-sm-6 col-md-3">
          <div class="dl" style="width:200px;">
            <div class="brand">
                <h2><asp:Label ID="CouponIDLabel" runat="server" Text='<%# Eval("CouponID") %>' />
</h2>
            </div>
            <div class="discount alizarin"><%# Eval("coupDiscount") %>
                <div class="type">off</div>
            </div>
            <div class="descr">
                <span>Expires:</span>
                  <asp:Label ID="expiry" runat="server" Text='<%#Eval("coupexpiry") %>'/>

            </div>
            <div class="ends">
                <small>                  <asp:Label ID="coupQuantityLabel" runat="server" Text='<%#Eval("coupQuantity") %>'/>
* Conditions and restrictions apply.</small>
            </div>
              <div class="coupon midnight-blue">
                  <a data-toggle="collapse" href="#code-1" class="open-code">            <asp:Label ID="CouponCode" runat="server" Text='<%#Eval("code") %>'/>
</a>
                  <br /> <asp:Button ID="btn_Use" runat="server" CommandName="UseCoupon" Text="Use" CssClass ="btn-dark"/>
                  <div id="code-1" class="collapse code"><%#Eval("code") %></div>
              </div>
          </div>

        </div>

	</div>
  </div>
    </div>


        </ItemTemplate>

    </asp:DataList>
            <asp:SqlDataSource ID="CouponRetrieve" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [CustCoupon] WHERE ([Cust_ID] = @Cust_ID)">
                <SelectParameters>
                    <asp:SessionParameter Name="Cust_ID" SessionField="CustID" Type="String" />
                </SelectParameters>
    </asp:SqlDataSource>

<!--NEW DATALIST-->
    <h1>SEASONAL COUPONS</h1>
    <asp:DataList ID="dl_SeasonalCoupon" runat="server" DataSourceID="ds_SeasonalCoupon" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="dl_SeasonalCoupon_ItemCommand" OnSelectedIndexChanged="dl_SeasonalCoupon_SelectedIndexChanged">
        <ItemTemplate>
        <div class="floatycontain">
<section id="labels">
  <div class="container">
	<div class="row">
        <div class="col-sm-6 col-md-3">
          <div  style="width:200px" class="dl">
            <div class="brand">
                <h2><asp:Label ID="Coupon_IDLabel" runat="server" Text='<%# Eval("Coupon_ID") %>' />
</h2>
            </div>
            <div class="discount alizarin"><%# Eval("coupon_Name") %>
                <div class="type"><%#Eval("coup_discountamt") %></div>
            </div>
            <div class="descr">
                                <strong>Start:<asp:Label ID="Label1" runat="server" Text='<%# Eval("coupon_startDate") %>' /></strong><br />

                <strong>End:<asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("coupon_endDate") %>' /></strong><br />
                <span>Description:</span>
                  <asp:Label ID="expiry" runat="server" Text='<%#Eval("coup_Desc") %>'/>
            </div>
            <div class="ends">
                <small>                  <asp:Label ID="coupQuantityLabel" runat="server" Text=''/></small>
            </div>
              <div class="coupon midnight-blue">
                  <a data-toggle="collapse" href="#code-1" class="open-code"></a>
                  Code: <asp:Label ID="Label2" runat="server" Text='<%#Eval("coupon_Name") %>'/>
              </div>
          </div>

        </div>

	</div>
  </div>
    </div>


        </ItemTemplate>

    </asp:DataList>
            <asp:SqlDataSource ID="ds_SeasonalCoupon" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [SeasonalCoupon]">
    </asp:SqlDataSource>



</asp:Content>

