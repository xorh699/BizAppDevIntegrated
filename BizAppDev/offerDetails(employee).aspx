<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="offerDetails(employee).aspx.cs" Inherits="BizAppDev.offerDetails_employee_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <form id="form1" runat="server">
        <div class="card mb-0" style="margin-left:40px; height:550px; margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Offers/Events Details</h1>
                    </div>
                    
                        <div class="card-body">
   
        <div class="breadcrumb-holder container-fluid" style="font-size:15px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Offer/ Event List</li>
            <li class="breadcrumb-item">Offer/ Event Details</li>
        </ul>
    </div>
        <br />
        <table class="w-100"  style="font-size:20px; border-collapse:collapse; margin-left:20px;">
            <tr>
                <td style="height: 30px">Offer ID:</td>
                <td style="height: 30px; width: 181px">
                    <asp:Label ID="lbl_offerID" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    <asp:Image ID="img_offer" runat="server" Height="116px" Width="258px" style="margin-left: 112px" />
                </td>
            </tr>
            <tr>
                <td>Offer Name:</td>
                <td style="width: 181px">
                    <asp:Label ID="lbl_offerName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Offer Description:</td>
                <td style="width: 181px">
                    <asp:Label ID="lbl_offerDesc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Offer Start Date:</td>
                <td style="width: 181px">
                    <asp:Label ID="lbl_offerstartDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Offer End Date:</td>
                <td style="width: 181px">
                    <asp:Label ID="lbl_endDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" class="btn btn-primary" style="color: white; margin-left:900px;"/>
                            <br />
                            </div>
            </div>
        
    </form>

</asp:Content>
