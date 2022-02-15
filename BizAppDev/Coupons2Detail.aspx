<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Coupons2Detail.aspx.cs" Inherits="BizAppDev.Coupons2Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="card mb-0" style="margin-left:40px; margin-left:150px;">
                    <div class="card-header">
                      <div class="card-close">
                        <div class="dropdown">
                          <button class="dropdown-toggle text-sm" type="button" id="closeCard1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-ellipsis-v"></i></button>
                          <div class="dropdown-menu dropdown-menu-end shadow-sm" aria-labelledby="closeCard1"><a class="dropdown-item py-1 px-3 remove" href="#"> <i class="fas fa-times"></i>Close</a><a class="dropdown-item py-1 px-3 edit" href="#"> <i class="fas fa-cog"></i>Edit</a></div>
                        </div>
                      </div>
                     <h1 class="h4 mb-0">Coupon Details</h1>
                    </div>
                    <div class="breadcrumb-holder container-fluid" style="padding:0px;">
        <ul class="breadcrumb">
            <li class="breadcrumb-item active">Coupons List</li>
        </ul>
    </div>
                        <div class="card-body" >
                            <asp:DataList ID="DataList1" runat="server" DataKeyField="couponID" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                                <EditItemTemplate>
                                    Coupon ID:
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("couponID") %>'></asp:Label>
                                    <br />
                                    Coupon Name:
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("cName") %>'></asp:Label>
                                    <br />
                                    Coupon Description:
                                    <asp:TextBox ID="TextBox1" runat="server" Height="53px" Text='<%# Eval("cDesc") %>' TextMode="MultiLine" Width="232px"></asp:TextBox>
                                    <br />
                                    Amount of Coupons:<asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("amount") %>'></asp:TextBox>
                                    <br />
                                    Points to Redeem:<asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("cost") %>'></asp:TextBox>
                                    <br />
                                    Discount Amount:<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("discount") %>'></asp:TextBox>
                                    <br />
                                    Valid Days:<asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("validDays") %>'></asp:TextBox>
                                    <br />
                                    Valid Months:<asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("validMonths") %>'></asp:TextBox>
                                    <br />
                                    Valid Years:<asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("validYears") %>'></asp:TextBox>
                                    <br />
                                    Category:
                                    <asp:DropDownList ID="ddl_category" runat="server" Width="137px">
                                        <asp:ListItem>Joss Money</asp:ListItem>
                                        <asp:ListItem>Joss Paper</asp:ListItem>
                                        <asp:ListItem>Joss Sticks</asp:ListItem>
                                        <asp:ListItem>Candles</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" class="btn btn-secondary"/>
                                    <asp:Button ID="btn_cancel" runat="server" CommandName="cancel" Text="Cancel" class="btn btn-secondary"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    couponID:
                                    <asp:Label ID="couponIDLabel" runat="server" Text='<%# Eval("couponID") %>' />
                                    <br />
                                    coupon Name:
                                    <asp:Label ID="cNameLabel" runat="server" Text='<%# Eval("cName") %>' />
                                    <br />
                                    coupon Desc:
                                    <asp:Label ID="cDescLabel" runat="server" Text='<%# Eval("cDesc") %>' />
                                    <br />
                                    amount of coupons:
                                    <asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
                                    <br />
                                    points to redeem:
                                    <asp:Label ID="costLabel" runat="server" Text='<%# Eval("cost") %>' />
                                    <br />
                                    discount amount:
                                    <asp:Label ID="discountLabel" runat="server" Text='<%# Eval("discount") %>' />
                                    <br />
                                    valid Days:
                                    <asp:Label ID="validDaysLabel" runat="server" Text='<%# Eval("validDays") %>' />
                                    <br />
                                    valid Months:
                                    <asp:Label ID="validMonthsLabel" runat="server" Text='<%# Eval("validMonths") %>' />
                                    <br />
                                    valid Years:
                                    <asp:Label ID="validYearsLabel" runat="server" Text='<%# Eval("validYears") %>' />
                                    <br />
                                    Category:&nbsp;<asp:Label ID="lbl_category" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                    <br />
                                    <asp:Button ID="btn_edit" runat="server" CommandName="edit" Text="Edit" class="btn btn-secondary"/>
                                    &nbsp;<br />
                                </ItemTemplate>
                            </asp:DataList>
                            <br />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" class="btn btn-primary"/>
        </div>
            </div>
        
        
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Coupon] WHERE ([couponID] = @couponID)">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="couponID" QueryStringField="couponID" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
        
        
    </form>



</asp:Content>
