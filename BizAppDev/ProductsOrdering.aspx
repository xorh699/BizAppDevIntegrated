<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ProductsOrdering.aspx.cs" Inherits="BizAppDev.ProductsOrdering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="card mb-0" style="margin-left:40px; height:500px; margin-left:150px;">
                
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Product Ordering Page</h1>
                    </div>
                    
                        <div class="card-body">
        <form id="form1" runat="server">

            <table class="autoComplete_wrapper">
                <tr>
                    <td rowspan="6" style="width: 399px">Delivery Date:
                    <asp:Calendar ID="cal_delivery" runat="server" SelectionMode="Day" OnDayRender="cal_delivery_DayRender"></asp:Calendar>
                    </td>
                    <td>Product Purchasing:
                    <asp:Label ID="lbl_product" runat="server" ></asp:Label>
                    ,<asp:Label ID="lbl_id" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Supplier Name:
                    <asp:Label ID="lbl_supplid" runat="server" style="margin-top: 12px" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 43px">Supplier Email:<asp:Label ID="lbl_supplemail" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px">Amount of Stocks to order:<asp:TextBox ID="tb_quantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 74px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_quantity" ErrorMessage="Please input an amount of stock you want to order." ForeColor="Red" style="margin-top: 20px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tb_quantity" ErrorMessage="Please input at least 10 stocks to order. " ForeColor="Red" MaximumValue="999999" MinimumValue="10"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 44px">
                    <asp:Button ID="btn_place" runat="server" Text="Place Order" OnClick="btn_place_Click" class="btn btn-primary" style="color: white;"/>
                    </td>
                </tr>
            </table>
            <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
        </form>
                    
               

</div>
    </div>




</asp:Content>
