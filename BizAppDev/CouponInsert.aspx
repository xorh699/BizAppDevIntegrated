<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CouponInsert.aspx.cs" Inherits="BizAppDev.CouponInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="card mb-0" style="margin-left:40px;margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0" style="margin-left:250px;margin-top:40px; margin-bottom:40px;">Insert Seasonal Coupon</h1>
                    </div>
   <div class="card-body" >
        <div class="breadcrumb-holder container-fluid" style="font-size:15px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Coupons List</li>
            <li class="breadcrumb-item active">Add Seasonal Coupon</li>
        </ul>
    </div>
        <form id="form1" runat="server">
        <table class="w-100" style="">
            <tr>
                <td>Coupon Name:</td>
                <td>
                    <asp:TextBox ID="tb_name" runat="server" CausesValidation="True"></asp:TextBox>
             
                &nbsp;<br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_name" ErrorMessage="Please enter your coupon name." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Coupon Start Date:</td>
                <td>
                    <asp:Calendar ID="calendar_startDate" runat="server" OnDayRender="cal_delivery_DayRender" OnSelectionChanged="calendar_startDate_SelectionChanged" ></asp:Calendar>
                                    </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="tb_startdate" runat="server" ></asp:TextBox>
                                    <br/>
                                    </td>
            </tr>
            <tr>
                <td>Coupon End Date:</td>
                <td>
                    <asp:Calendar ID="calendar_endDate" runat="server" OnDayRender="cal_delivery_DayRender" OnSelectionChanged="calendar_endDate_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="tb_enddate" runat="server"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="start date is supposed to be lesser than the end date." ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    
                    <br />
                    
                </td>
            </tr>
            <tr>
                <td>Coupon Description:</td>
                <td>
                    <asp:TextBox ID="tb_desc" runat="server" Height="143px" Width="450px" CausesValidation="True"></asp:TextBox>
                    
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_desc" ErrorMessage="Please enter the coupon description." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 29px">Coupon Amount:</td>
                <td style="height: 29px">
                    <asp:TextBox ID="tb_amt" runat="server"></asp:TextBox>
                    
                    <br />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tb_amt" ErrorMessage="please input a valid number " ForeColor="Red" MaximumValue="1" MinimumValue="0.01"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_amt" ErrorMessage="please input an amount." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_Insert" runat="server" Text="Insert" OnClick="btn_Insert_Click" class="btn btn-primary" style="color: white;"/>
                    <asp:Button ID="btn_view" runat="server" Text="View List" OnClick="btn_view_Click" class="btn btn-primary" style="color: white;" CausesValidation="false"/>
                    
                </td>
            </tr>
        </table>
            </form>
       </div>
             </div>
       





</asp:Content>
