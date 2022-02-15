<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="CouponsValidity(lermin)(employee).aspx.cs" Inherits="BizAppDev.CouponsValidity_lermin__employee_" %>
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
                                <asp:ListItem Value="1">Seasonal Coupons</asp:ListItem>
                                <asp:ListItem Selected="True" Value="2">Personal Coupons</asp:ListItem>
                            </asp:DropDownList>
                            <br />

            <h2 class="h4 mb-0" style="margin-bottom:20px; text-align:center; margin-top:20px;">Red = Fully claimed                                  Green = Not fully claimed yet</h2>
                            <br />
                          
                            
                            <table >
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Available Coupons</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Fully Redeemed Coupons</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">View All</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666"  BorderWidth="1px" CellPadding="7" DataSourceID="SqlDataSource2" GridLines="Horizontal" Width="1000px" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="couponID" HeaderText="coupon ID" />
                                                <asp:BoundField DataField="couponName" HeaderText="coupon name " />
                                                <asp:BoundField DataField="couponDesc" HeaderText="coupon desc" />
                                                <asp:BoundField DataField="amount" HeaderText="amount of coupons left" />
                                                <asp:BoundField DataField="discount" HeaderText="discount amount " />
                                                <asp:CommandField ShowSelectButton="True" />
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
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Coupon]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                
            
            
            </div>
                        </div>
                      
       
        
       </form>




</asp:Content>
