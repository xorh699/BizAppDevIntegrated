<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerViewPerks.aspx.cs" Inherits="BizAppDev.CustomerViewPerks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    <div style="margin-left:10%; margin-top:10%;">
    <h1><strong>Tier Perks:</strong></h1>
    <br />

                <asp:DataList ID="DataList1" runat="server" DataKeyField="PerkID" DataSourceID="PerkSQL">
                    <ItemTemplate>
                        <div class="col-md-4" style="min-width:400px;">
                  <div class="card text-white bg-info" style="min-height:200px;">
                    <div class="card-body">
                      <h5 class="card-title">                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' />
</h5>
                        <hr/>
                      <p class="card-text">                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("PDesc") %>' />
</p>
                    </div>
                  </div>
                </div>

                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="PerkSQL" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT Perks.PerkID, Perks.Name, Perks.PDesc, PointTiersPerks.pointTierID FROM PointTiersPerks INNER JOIN Perks ON PointTiersPerks.PerkID = Perks.PerkID WHERE (PointTiersPerks.pointTierID = @pointTierID)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="pointTierID" QueryStringField="pointTierID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
        </div>
</asp:Content>
