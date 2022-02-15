<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CouponDetail.aspx.cs" Inherits="BizAppDev.CouponDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="card mb-0" style="margin-left:40px; height:400px; margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Coupon Details</h1>
                    </div>
                    
                        <div class="card-body">
        <table class="w-100" style="font-size:20px; margin-left:50px;" >
            <tr>
                <td>Coupon ID</td>
                <div class="breadcrumb-holder container-fluid" style="font-size:15px; ">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Coupons List</li>
            <li class="breadcrumb-item active">Coupon Details</li>
        </ul>
    </div>
                <td>
                    <asp:Label ID="lbl_couponID" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Coupon Name</td>
                <td>
                    <asp:Label ID="lbl_couponName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 29px">Coupon Start Date</td>
                <td style="height: 29px">
                    <asp:Label ID="lbl_startDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Coupon End Date</td>
                <td>
                    <asp:Label ID="lbl_endDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Coupon Description</td>
                <td>
                    <asp:Label ID="lbl_desc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" class="btn btn-primary" style="color: white; margin-left:900px;"/>
        <br />
                            </div>
            </div>  
        
    </form>



</asp:Content>
