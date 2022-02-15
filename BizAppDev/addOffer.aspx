<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addOffer.aspx.cs" Inherits="BizAppDev.addOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <div class="card mb-0" style="margin-left:40px; margin-left:150px;">
                
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Insert Offers/ Events</h1>
                    </div>
                    
                        <div class="card-body">
        <form id="form1" runat="server">
        <table class="w-100">
            <tr>
                <td>Offer Name</td>
                <td>
                    <asp:TextBox ID="tb_offerName" runat="server" CausesValidation="True"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_offerName" ErrorMessage="Please enter the offer name." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Offer Start Date</td>
                <td>
                    <asp:Calendar ID="calendar_startDate" runat="server" OnDayRender="calendar_startDate_DayRender" OnSelectionChanged="calendar_startDate_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="tb_startdate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Offer End Date</td>
                <td>
                    <asp:Calendar ID="calendar_endDate" runat="server" OnDayRender="calendar_endDate_DayRender" OnSelectionChanged="calendar_endDate_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="tb_enddate" runat="server"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="start date must be lesser than end date. " ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Offer Description</td>
                <td>
                    <asp:TextBox ID="tb_desc" runat="server" CausesValidation="True" Height="92px" TextMode="MultiLine" Width="413px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_desc" ErrorMessage="Please enter offer description" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Offer Image</td>
                <td>
                    <asp:FileUpload ID="fu_image" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fu_image" ErrorMessage="Please upload a file image corresponding to the offer." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Insert" class="btn btn-primary" style="color: white;"/>
                    <asp:Button ID="btn_view" runat="server" Text="View Offer List" class="btn btn-primary" style="color: white;" CausesValidation="false" OnClick="btn_view_Click"/>
                </td>
            </tr>
        </table>
                            

    </form>
            </div>
            </div>
    


    

</asp:Content>
