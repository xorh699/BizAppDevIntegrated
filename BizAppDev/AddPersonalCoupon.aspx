<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddPersonalCoupon.aspx.cs" Inherits="BizAppDev.AddPersonalCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card mb-0" style="margin-left:40px;margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0" style="margin-left:250px;">Insert Personal Coupon</h1>
                    </div>
   <div class="card-body" >
        <div class="breadcrumb-holder container-fluid" style="font-size:15px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Coupons List</li>
            <li class="breadcrumb-item active">Add Personal Coupon</li>
        </ul>
    </div>
        <form id="form1" runat="server">

            <table class="autoComplete_wrapper">
                <tr>
                    <td style="width: 273px">Coupon Name:</td>
                    <td>
                        <asp:TextBox ID="tb_name" runat="server" Width="268px" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_name" ErrorMessage="Please input a valid coupon name." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px">Coupon Description:</td>
                    <td>
                        <asp:TextBox ID="tb_desc" runat="server" Height="105px" TextMode="MultiLine" Width="372px" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_desc" ErrorMessage="Please input coupon description." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px">Amount of Coupons Available:</td>
                    <td>
                        <asp:TextBox ID="tb_amount" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tb_amount" ErrorMessage="please input a valid number of coupons available (at least 5). " ForeColor="Red" MaximumValue="9999" MinimumValue="5" Type="Integer"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_amount" ErrorMessage="please enter number of coupons available. " ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px">Amount of Points to redeem:</td>
                    <td>
                        <asp:TextBox ID="tb_cost" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_cost" ErrorMessage="please enter no. of points to be redeemed. " ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tb_cost" ErrorMessage="please input a valid number. " Type="Integer" ForeColor="Red" MaximumValue="999" MinimumValue="1"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px; height: 83px;">Discount Amount:</td>
                    <td style="height: 83px">
                        <asp:TextBox ID="tb_discount" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tb_discount" ErrorMessage="please enter a valid discount amount." Type="Double" ForeColor="Red" MaximumValue="1" MinimumValue="0"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_discount" ErrorMessage="please input an amount. " ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px">Valid Days:</td>
                    <td>
                        <asp:TextBox ID="tb_validdays" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tb_validdays" ErrorMessage="please input a valid day in number format (less than 31). " Type="Integer" ForeColor="Red" MaximumValue="31" MinimumValue="1"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_validdays" ErrorMessage="please enter no. of days. " ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px; height: 29px;">Valid Months:</td>
                    <td style="height: 29px">
                        <asp:TextBox ID="tb_validmonths" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="tb_validmonths" ErrorMessage="please input a valid month in number format (less than or equals to 12). " Type="Integer" ForeColor="Red" MaximumValue="12" MinimumValue="1"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_validmonths" ErrorMessage="please enter no. of months." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px; height: 56px;">Valid Years:</td>
                    <td style="height: 56px">
                        <asp:TextBox ID="tb_validyears" runat="server" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="tb_validyears" ErrorMessage="please input a valid no. of years in number format. " Type="Integer" ForeColor="Red" MaximumValue="10" MinimumValue="1"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_validyears" ErrorMessage="please enter no. of years. " ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px; height: 56px;">Category;</td>
                    <td style="height: 56px">
                        <asp:DropDownList ID="ddl_category" runat="server" Width="170px">
                            <asp:ListItem>Joss Money</asp:ListItem>
                            <asp:ListItem>Joss Paper</asp:ListItem>
                            <asp:ListItem>Joss Sticks</asp:ListItem>
                            <asp:ListItem>Candles</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddl_category" ErrorMessage="please select one category that the coupon falls under." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 273px">&nbsp;</td>
                    <td>
                        <br />
                        <asp:Button ID="btn_insert" runat="server" OnClick="btn_insert_Click" Text="Insert" class="btn btn-primary" style="color: white;"/>
&nbsp;<asp:Button ID="btn_view" runat="server" OnClick="btn_view_Click" Text="View Personal Coupons" class="btn btn-primary" style="color: white;" CausesValidation="False"/>
                    </td>
                </tr>
            </table>
            </form>


    </div>
</div>
</asp:Content>





