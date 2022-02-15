<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Coupons(lermin)(employee).aspx.cs" Inherits="BizAppDev.Coupons_lermin__employee_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
       
                  <div class="card mb-0" style="margin-left:40px; margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                      </div>
                     <h1 class="h4 mb-0">Coupons</h1>
                    </div>
                    
                        <div class="card-body">
        
            <asp:Label ID="lbl_alert" runat="server" ></asp:Label>
            <div class="breadcrumb-holder container-fluid" style="padding:0px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item active">Coupons List</li>
        </ul>
    </div>
                             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">Seasonal Coupons</asp:ListItem>
                                <asp:ListItem value="2">Personal Coupons</asp:ListItem>
                            </asp:DropDownList>

            <h2 class="h4 mb-0" style="margin-bottom:20px; text-align:center;">Red = Past                                  Green = Ongoing</h2>
                            <br />
                            <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lb_upcoming_coupons" runat="server" OnClick="lb_upcoming_coupons_Click">upcoming coupons</asp:LinkButton>
&nbsp;&nbsp; <asp:LinkButton runat="server"  OnClick="filter_click" BorderStyle="None" BorderWidth="10px" >valid coupons</asp:LinkButton>  &nbsp;&nbsp;
                                <asp:LinkButton ID="lb_past_coupons" runat="server" OnClick="lb_past_coupons_Click">past coupons</asp:LinkButton>
                                &nbsp;  <asp:LinkButton runat="server" OnClick="Unnamed1_Click" >back to the list</asp:LinkButton></td>
                        </tr>
                               
                             
                    
                        </table>
                    
                            
                            <table >
                                <tr>
                                    <td><asp:GridView ID="gvCoupons" runat="server" Width="1000px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCoupons_SelectedIndexChanged" OnRowDeleting="gvCoupons_RowDeleting"  OnRowCancelingEdit="gvCoupons_RowCancelingEdit" OnRowEditing="gvCoupons_RowEditing" OnRowUpdating="gvCoupons_RowUpdating" OnRowDataBound="gvCoupons_RowDataBound1"  DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#336666"  BorderWidth="1px" CellPadding="7" GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="couponID" HeaderText="coupon ID" />
                    
                    <asp:BoundField DataField="couponName" HeaderText="coupon Name" HeaderStyle-Width="200px">
<HeaderStyle Width="200px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="couponstartDate" HeaderText="coupon start date" HeaderStyle-Width="200px" DataFormatString="{0:dd/MM/yyyy}">
<HeaderStyle Width="200px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="couponendDate" HeaderText="coupon end date" HeaderStyle-Width="200px" DataFormatString="{0:dd/MM/yyyy}">
<HeaderStyle Width="200px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="couponAmt" HeaderText="coupon amount" />
                    <asp:CommandField ShowSelectButton="True" ShowEditButton="True">
                    <HeaderStyle Width="250px" />
                    <ItemStyle Width="55px" />
                    </asp:CommandField>
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
            </asp:GridView></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project%>" SelectCommand="SELECT [coupon_startDate], [coupon_endDate] FROM [Coupons]"></asp:SqlDataSource>
            </div>
                        </div>
                      
       
        
       </form>



</asp:Content>
