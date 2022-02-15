<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Prodcustdetails.aspx.cs" Inherits="BizAppDev.Prodcustdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header class="page-header">
        <div class="container-fluid">
            <h2 class="no-margin-bottom">Order details</h2>
        </div>
    </header>
    <!-- Breadcrumb-->
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item">Order management</li>
            <li class="breadcrumb-item active"><a href="#">Order status</a></li>
        </ul>
    </div>
     <form id="form1" runat="server">
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:20px; ">
                <div class="col-md-6 col-lg-3" >

                    <asp:DataList ID="DataList2" runat="server" onEditCommand="myListEditHandler"  
         onUpdateCommand="myListUpdateHandler" RepeatColumns="3" DataKeyField="CustID"  onCancelCommand="myListCancelHandler" DataSourceID="SqlDataSource8" OnDeleteCommand="DataList2_DeleteCommand" >

                        <ItemTemplate>
                              <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                     
                        <div class="ms-3">
                             CustID:
                             <asp:Label ID="CustIDLabel" runat="server" Text='<%# Eval("CustID") %>' />
                             <br />
                             CustomizationID:
                             <asp:Label ID="CustomizationIDLabel" runat="server" Text='<%# Eval("CustomizationID") %>' />
                             <br />
                             Category:
                             <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
                             <br />
                             Colour:
                             <asp:Label ID="ColourLabel" runat="server" Text='<%# Eval("Colour") %>' />
                             <br />
                             Scent:
                             <asp:Label ID="ScentLabel" runat="server" Text='<%# Eval("Scent") %>' />
                             <br />
                             Fullname:
                             <asp:Label ID="FullnameLabel" runat="server" Text='<%# Eval("Fullname") %>' />
                             <br />
                             Email:
                             <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                             <br />
                             Contactno:
                             <asp:Label ID="ContactnoLabel" runat="server" Text='<%# Eval("Contactno") %>' />
                             <br />
                             Date:
                             <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                             <br />
                             Status:
                             <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                             <br />
                             <br />
                              <asp:Button ID="Linkbutton3" runat="server" commandname="Edit" class="btn btn-primary btn-sm" text=' <%# "Edit" %>' />                    
                            </div>
                        </div>
                                  </div>
                        </ItemTemplate>

                         <EditItemTemplate>
          <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                     
                        <div class="ms-3">
                              CustID:
                             <asp:Label ID="CustIDLabel" runat="server" Text='<%# Eval("CustID") %>' />
                             <br />
                             CustomizationID:
                             <asp:Label ID="CustomizationIDLabel" runat="server" Text='<%# Eval("CustomizationID") %>' />
                             <br />
                             Category:
                             <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
                             <br />
                             Colour:
                             <asp:Label ID="ColourLabel" runat="server" Text='<%# Eval("Colour") %>' />
                             <br />
                             Scent:
                             <asp:Label ID="ScentLabel" runat="server" Text='<%# Eval("Scent") %>' />
                             <br />
                             Fullname:
                             <asp:Label ID="FullnameLabel" runat="server" Text='<%# Eval("Fullname") %>' />
                             <br />
                             Email:
                             <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                             <br />
                             Contactno:
                             <asp:Label ID="ContactnoLabel" runat="server" Text='<%# Eval("Contactno") %>' />
                             <br />
                             Date:
                             <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                             <br />
                             Collectiob Status:
                                 <asp:DropDownList ID="DropDownList3" runat="server">
                                   <asp:ListItem>Preparing</asp:ListItem>
                                   <asp:ListItem>Ready for collection</asp:ListItem>
                               </asp:DropDownList>
                               <br />
                               <br />                                        

               <asp:Button ID="Linkbutton1" CommandName="update" runat="server" class="btn btn-primary btn-sm" text="Update" />
               <asp:Button ID="Linkbutton2" CommandName="cancel" runat="server" class="btn btn-primary btn-sm" text="Cancel" />       
              </div>
                  </div>
                </div>
            </EditItemTemplate>
            

                    </asp:DataList>
                  
                        </section>


                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [ProductCust] WHERE ([CustID] = @CustID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="CustID" QueryStringField="custID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

    </form>
     
</asp:Content>

