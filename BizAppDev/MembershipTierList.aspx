<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MembershipTierList.aspx.cs" Inherits="BizAppDev.MembershipTierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1">Membership Tier List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/MembershipTierList.aspx">Membership Tier List</a></li>
                  
                </ol>
              </nav>
            </div>
          </div>
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:100px;">
                <div class="col-md-6 col-lg-3">
                    <asp:DataList ID="DataList1" runat="server" OnEditCommand="DataList1_EditCommand" DataKeyField="membership_id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                
                  <!-- Simple card-->
                  <div class="card" style="margin-left:10px;width:349px;height:550px;">
                <img class="card-img-top img-fluid" src="https://restrictcontentpro.com/wp-content/uploads/2021/07/What-is-the-Difference-Between-a-Membership-and-a-Subscription-33803.png" alt="Card image cap" height="175" width="349">
                <br />
                <br />
                <br />
                      <div class="card-body">
                      <h5 class="card-title">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("membership_id") %>'></asp:Label>,
                          <asp:Label ID="lbl_tier" runat="server" Text='<%# Eval("membership_name") %>'></asp:Label>
                          </h5>
                <br />

                <p class="card-text"><asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("membership_desc") %>'></asp:Label></p>
                <br />
                <asp:Button ID="btn_more" runat="server" Text="More Information"  class="btn btn-primary" style="color: white;" OnClick="btn_more_Click"/>
                          </div>
                      </div>
                    </div>
                
            </ItemTemplate>
        </asp:DataList>
                     </div>
                </div>
                </div>
                    </section>

                 
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Membership]"></asp:SqlDataSource>
        <br />

            </form>

</asp:Content>
