<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StaffAddPointTier.aspx.cs" Inherits="BizAppDev.StaffAddPointTier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div class="card-body">
                      <p class="text-sm">Create points tier</p>
                        <div class="mb-3">
                          <label class="form-label">Tier Name</label>
                            <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                          <label class="form-label">Tier descrription</label>
                            <asp:TextBox ID="tb_descr" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                          <label class="form-label">Point expenditure requirement to reach tier</label>
                            <asp:TextBox ID="tb_price" runat="server" CssClass="form-control" type="number" required="true" ></asp:TextBox>
                            </div>
                                <div class="mb-3">
                          <label class="form-label">Point multiplier</label>
                            <asp:TextBox ID="tb_pointMultiplier" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tb_pointMultiplier" ValidationExpression="^[1-9]\d*(\.\d+)?$" runat="server" ErrorMessage="Enter valid number"></asp:RegularExpressionValidator>

                            </div>

                                                    <div class="mb-3">
                                  <label class="form-label">Perks to be included</label>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="lbl_PerkList" runat="server" Text="List of Perks:" CssClass="card-title"></asp:Label>
                          <asp:DataList ID="DataList1" runat="server" DataKeyField="PerkID" DataSourceID="staffPerkadd" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="20" CellSpacing="-1" Width="1371px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand1">
                              <ItemTemplate>
                      <div style="box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;" class="card-body">
                      <h4 class="card-title"><asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                          <asp:Label ID="Label2" runat="server" Text='<%# Eval("PerkID") %>' />
                          </h4>
                      <p class="card-text"><asp:Label ID="Label1" runat="server" Text='<%# Eval("PDesc") %>' />
                          </p>
                          
                          <asp:CheckBox ID="cb_Perks" runat="server" Text='<%# Eval("PerkID") %>' />
                    </div>
                                  </div>


                        </div>
                  </div>
                  </div>





<br />
                              </ItemTemplate>
        </asp:DataList>
                      <asp:SqlDataSource ID="staffPerkadd" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Perks]"></asp:SqlDataSource>
                                                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Submit_Click1" />

                        </div>
                    </div>
</form>
</asp:Content>
