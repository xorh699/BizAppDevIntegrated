<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Offers(lermin).aspx.cs" Inherits="BizAppDev.Offers_lermin_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="card mb-0" style="margin-left:40px;  margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Offers/ Events</h1>
                    </div>
                    
                        <div class="card-body">
        
        
            <asp:Label ID="lbl_alert" runat="server" ></asp:Label>
        
        <div class="breadcrumb-holder container-fluid" style="font-size:15px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Offer/ Event List</li>
        </ul>
    </div>
        
             <h2 style=" text-align:center;">Red = Past                             Green = Ongoing</h2>
            <br />
                            <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lb_upcoming_coupons" runat="server" OnClick="lb_upcoming_coupons_Click">upcoming offers</asp:LinkButton>
&nbsp;&nbsp; <asp:LinkButton runat="server"  OnClick="filter_click" BorderStyle="None" BorderWidth="10px" >valid offers</asp:LinkButton>  &nbsp;&nbsp;
                                <asp:LinkButton ID="lb_past_coupons" runat="server" OnClick="lb_past_coupons_Click">past offers</asp:LinkButton>
                                &nbsp;  <asp:LinkButton runat="server" OnClick="Unnamed1_Click" >back to the list</asp:LinkButton></td>
                        </tr>
                               
                             
                    
                        </table>
                           
            <asp:GridView ID="gvOffer" runat="server" AutoGenerateColumns="False"  Width="1000px" OnSelectedIndexChanged="gvOffer_SelectedIndexChanged" OnRowCancelingEdit="gvOffer_RowCancelingEdit" OnRowEditing="gvOffer_RowEditing" OnRowUpdating="gvOffer_RowUpdating" OnRowDataBound="gvOffer_RowDataBound" OnRowDeleting="gvOffer_RowDeleting1" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="1px" CellPadding="4" GridLines="Horizontal" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="offer_ID" HeaderText="offer ID" />
                    <asp:BoundField DataField="offer_Name" HeaderText="offer name" />
                    <asp:BoundField DataField="offer_startDate" HeaderText="offer start date"  DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="offer_endDate" HeaderText="offer end date"  DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this offer?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Offers]"></asp:SqlDataSource>
        </p>
        <p>
            <asp:Button ID="btn_add" runat="server" Text="Add Offers/ Events"  OnClick="btn_add_Click" class="btn btn-primary" style="color: white;"/>
        </p>
                            </div>
            </div>
    </form>



</asp:Content>
