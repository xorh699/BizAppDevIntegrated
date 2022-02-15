<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StaffViewTier.aspx.cs" Inherits="BizAppDev.StaffViewTier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="btn_Back" runat="server" CssClass="btn-info" OnClick="btn_Back_Click" Text="Back" />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="pointTierID" DataSourceID="ViewTiers" CellPadding="20" RepeatDirection="Horizontal" CellSpacing="20" RepeatColumns="5" OnItemCommand="DataList1_ItemCommand" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnCancelCommand="DataList1_CancelCommand" OnUpdateCommand="DataList1_UpdateCommand" OnEditCommand="DataList1_EditCommand">
        <EditItemTemplate>
            <div class="card" style="width:240px;">
                <div class="card-header">
                    ID:
                    <asp:Label ID="pointTierIDLabel" runat="server" Text='<%# Eval("pointTierID") %>' />
                </div>
                <div class="card-body">
                    <h4 class="card-title">

                        <asp:Label ID="lbl_Name" runat="server" Text="Edit Tier" style="text-decoration:underline"/>
                        <br />
                        <br />
                                                  <label class="form-label">Name</label>
                        <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                                <br />                          <label class="form-label">description</label>

                        <asp:TextBox ID="tb_descr" runat="server" CssClass="form-control"></asp:TextBox>
                                                <br />
                                                  <label class="form-label">Price</label>

                        <asp:TextBox ID="tb_Price" runat="server" CssClass="form-control"></asp:TextBox>
                                                                  <label class="form-label">Point multiplier</label>

                        <asp:TextBox ID="tb_pointMultiplier" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:CheckBoxList ID="cbl_EditPerks" runat="server" DataSourceID="PointTierPerksList" DataTextField="PerkID" DataValueField="PerkID">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="PointTierPerksList" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT [PerkID] FROM [PointTiersPerks] WHERE ([pointTierID] = @pointTierID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="pointTierIDLabel" Name="pointTierID" PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                                                <br />
                        </div>
                    </h4>
                    <p class="card-text">
                        <br />
                        <asp:Button ID="btn_Update" runat="server" CommandArgument='<%# Eval("pointTierID")%>' CommandName="update" CssClass="btn btn-dark" Text="Update" />
                        <asp:Button ID="btn_Delete" runat="server" CommandArgument='<%# Eval("pointTierID")%>' CommandName="cancel" CssClass="btn btn-danger" OnClientClick="return confirm('Cancel without making any changes?')" Text="Cancel" />
                    </p>
                    <br />
                </div>
            </div>
        </EditItemTemplate>
        <ItemTemplate>
                        <div class="card" style="width:240px;">
            <div class="card-header">ID:  <asp:Label ID="pointTierIDLabel" runat="server" Text='<%# Eval("pointTierID") %>' /></div>
            <div class="card-body">
                <h4 class="card-title">Name: <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br /></h4>
                <p class="card-text">Description:<asp:Label ID="descrLabel" runat="server" Text='<%# Eval("descr") %>' />

          </p>
                <p class="card-text">Price: 
                    <asp:Label ID="lbl_Price" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                    <br />
                    <asp:Button ID="btn_Edit" runat="server" CommandArgument='<%# Eval("pointTierID") %>' CommandName="edit" CssClass="btn btn-dark" Text="Edit" />
                    <asp:Button ID="btn_Delete" runat="server" CommandArgument='<%# Eval("pointTierID") %>' CommandName="deleteTier" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this Tier?')" Text="Delete" />
                </p>
<br />
                            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="ViewTiers" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [PointTiers]"></asp:SqlDataSource>
          
</form>


