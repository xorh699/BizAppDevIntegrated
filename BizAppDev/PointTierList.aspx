<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="PointTierList.aspx.cs" Inherits="BizAppDev.PointTierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="margin-top:100px;margin-left:100px;" >
        <asp:Panel runat="server" ScrollBars="Horizontal">
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="pointTierID" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" CellPadding="15" RepeatLayout="Flow" OnItemCommand="DataList1_ItemCommand">
                        <ItemTemplate>
                                        <div class="container-fluid">
              <div class="row gx-3">

                <div class="col-sm-6 col-lg-3">
                  <div class="card border-bottom-0 border-start-0 border-end-0 border-4 border-primary" style="min-width:300px;" >
                    <div class="card-body text-center py-5">
                      <div class="text-sm fw-bold text-muted text-uppercase letter-spacing-0"><asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
</div>
                                                  <br />
                          <span style="font-size:15px;">Points required to reach tier:</span>
                      <div class="display-3 my-5">
                        <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />



                      </div>
                      <ul class="list-unstyled mb-5">
                        <li class="text-sm lh-lg"><strong>           <asp:Label ID="pointMultiplierLabel" runat="server" Text='<%# Eval("pointMultiplier") %>' /></strong>x Point Multiplier</li>
                        <li class="text-sm lh-lg">
                            <br />
                                                        <asp:Label ID="descrLabel" runat="server" Text='<%# Eval("descr") %>' />

                        </li>

                      </ul>
                      <div class="text-center">
                                                  <asp:Button ID="btn_viewPerks" class="btn px-4 btn-primary" runat="server" Text="View Perks" commandName="viewPerks"/>

                          </div>
                        <span style="font-size:9px;">              ID:          <asp:Label ID="pointTierIDLabel" runat="server" Text='<%# Eval("pointTierID") %>' />
</span>
                    </div>
                  </div>              </div>

              </div>
            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
            </asp:Panel>
        </div>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [PointTiers] ORDER BY [price]"></asp:SqlDataSource>
  
</asp:Content>
