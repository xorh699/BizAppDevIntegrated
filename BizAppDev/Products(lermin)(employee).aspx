<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Products(lermin)(employee).aspx.cs" Inherits="BizAppDev.Products_lermin__employee_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1" style="text-align:center;">Product List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3" style="margin-left:30px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/Products(lermin).aspx">Product List</a></li>
                  
                </ol>
                  
              </nav>
            </div>
          </div>
                    <section style="margin-top:10px;">
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:10px;">
                <div class="col-md-6 col-lg-3">
                    <table style="width: 1309px;">
                        <tr>
                            <td><asp:DropDownList ID="ddl_sortproduct" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sortproduct_SelectedIndexChanged" Width="271px">
                                    <asp:ListItem>Highest to Lowest(unit price)</asp:ListItem>
                                    <asp:ListItem>Lowest to Highest (unit price)</asp:ListItem>
                                    <asp:ListItem>Highest to Lowest (stock level)</asp:ListItem>
                                    <asp:ListItem>Lowest to Highest (stock level)</asp:ListItem>
                                </asp:DropDownList>
&nbsp;&nbsp; <asp:TextBox ID="tb_search" runat="server" Width="251px" style="margin-left:820px;" OnTextChanged="tb_search_TextChanged"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-secondary" style="color:white;" OnClick="Button4_Click"/></td>
                        </tr>
                    
                    
                        </table>
                    <br />

                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand" OnItemCommand="DataList1_ItemCommand1" OnDeleteCommand="DataList1_DeleteCommand" RepeatColumns="3" Height="1103px" CellPadding="5" >
                        <EditItemTemplate>
                            <div class="card" style="margin-left:30px;width:349px;">
                      <asp:Image class="card-img-top img-fluid" runat="server" width="170px" style="margin-left:80px; " ID="img_product" ImageUrl='<%# "/images/" + Eval("Product_Image") %>' />
                        <div class="card-body">
                            <h4 class="card-title">

                                <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("Product_ID") %>'></asp:Label>
                                ,
                                <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label></h4>
                                <p class="card-text">
                                    <b>Product Description:</b>
                                    <asp:TextBox ID="tb_desc" runat="server" Height="112px" Text='<%# Eval("Product_Desc") %>' TextMode="MultiLine" Width="303px"></asp:TextBox>
                            <p class="card-text">
                                <b>Product Price:</b>
                                <asp:TextBox ID="tb_price" runat="server" Text='<%# Eval("Unit_Price") %>'></asp:TextBox>
                            </p>
                            <p class="card-text">
                                <b>Stock Level:</b>
                                <asp:Label ID="lbl_stock" runat="server" Text='<%# Eval("Stock_Level") %>'></asp:Label>
                            </p>
                            <p class="card-text">
                                <b>Supplier Name:</b>
                                <asp:TextBox ID="tb_supplname" runat="server" Text='<%# Eval("supplierName") %>'></asp:TextBox>
                            </p>
                            <p class="card-text">
                                <b>Supplier Email:</b>
                                <asp:TextBox ID="tb_supplemail" runat="server" Height="19px" Text='<%# Eval("supplierEmail") %>' Width="203px"></asp:TextBox>
                            </p>
                            <p class="card-text">
                                <asp:Button ID="btn_update" runat="server" class="btn btn-primary" CommandName="update" style="color: white;" Text="Update" />
                                <asp:Button ID="btn_cancel" runat="server" class="btn btn-primary" CommandName="cancel" style="color: white;" Text="Cancel" />
                            </p>
                            </div>
                                </div>
                           
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="card" style="margin-left:30px;width:349px;padding-top:0px;height:580px;">
                      <asp:Image class="card-img-top img-fluid" runat="server" width="170px" height="140px" style="margin-left:80px; padding:0px 0px 0px 0px; " ID="Image1" ImageUrl='<%# "/images/" + Eval("Product_Image") %>' />
                        <div class="card-body">
                            <h4 class="card-title">

                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Product_ID") %>'></asp:Label>
                                ,
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label></h4>
                                <p class="card-text">
                                   <b>Product Description:</b>
                                    <asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("Product_Desc") %>'></asp:Label>
                                
                                </p>
                                

                                <p class="card-text">
                                    <b>Product Price:</b>
                                    <asp:Label ID="lbl_price" runat="server" Text='<%# Eval("Unit_Price") %>'></asp:Label>
                                </p>
                                <p class="card-text">
                                    <b>Stock Level:</b><asp:Label ID="Label3" runat="server" Text='<%# Eval("Stock_Level") %>'></asp:Label>
                                </p>
                                <p class="card-text">
                                    <b>Supplier Name:</b>
                                    <asp:Label ID="lbl_supplname" runat="server" Text='<%# Eval("supplierName") %>'></asp:Label>
                                </p>
                                <p class="card-text">
                                     <b>Supplier Email:</b>
                                    <asp:Label ID="lbl_supplemail" runat="server" Text='<%# Eval("supplierEmail") %>'></asp:Label>
                                </p>
                            <br />
                                <p class="card-text">
                                    <asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" class="btn btn-primary" style="color: white;"/>
                                </p>
                                
                            
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                  </div>
                </div>

          
                    <hr style="border-top:1px solid gray; width:1200px;" />
    
              <h3 class="mb-0 p-1" style="margin-left:600px;">Package</h3>
            
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3" style="margin-left:30px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/Products(lermin).aspx">Package</a></li>
                    <li class="breadcrumb-item">
                        
                    </li>
                  
                </ol>
              </nav>
            </div>
          </div>
                        <table style="width: 1309px;">
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="234px">
                                    <asp:ListItem>Highest to Lowest (unit price)</asp:ListItem>
                                    <asp:ListItem>Lowest to Highest (unit price)</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="tb_name2" runat="server" Width="251px" style="margin-left:820px;" OnTextChanged="tb_name2_TextChanged"></asp:TextBox><asp:Button ID="btn_search2" runat="server" Text="Search" class="btn btn-secondary" style="color:white;" OnClick="Button5_Click"/></td>
                        </tr>
                    
                    
                        </table>
                    <section>
            <div class="container-fluid" id="div_package">
              <div class="row" style="margin-left:10px;">
                <div class="col-md-6 col-lg-3">
                    
                    <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" DataKeyField="package_Name" OnCancelCommand="DataList2_CancelCommand" OnEditCommand="DataList2_EditCommand" OnUpdateCommand="DataList2_UpdateCommand" RepeatColumns="3" OnDeleteCommand="DataList2_DeleteCommand" >
                        <EditItemTemplate>
                            <div class="card" style="margin-left:30px;width:360px;">
                      <asp:Image class="card-img-top img-fluid" runat="server" width="170px" height="140px" style="margin-left:80px; " ID="Image2" ImageUrl='<%#"/images/" + Eval("package_Image") %>' />
                        <div class="card-body">
                            <h4 class="card-title">
                            
                            <br />
                            <b>Package Name:</b>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("package_Name") %>'></asp:Label> </h4>
                            <br />
                            <b>Package Item:</b>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("package_Items") %>'></asp:Label>
                            <br />
                            <b>Package Description:</b>
                            <asp:TextBox ID="TextBox1" runat="server" Height="91px" Text='<%# Eval("package_Desc") %>' Width="274px" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <b>Package Price:</b>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("package_Price") %>'></asp:TextBox>
                            <br />
                            <b>Package Festival:</b>&nbsp;<asp:TextBox ID="tb_festival" runat="server" Text='<%# Eval("package_festival") %>'></asp:TextBox>
                            <br />
                            <asp:Button ID="Button1" runat="server" CommandName="update" Text="Update" class="btn btn-primary" style="color: white;" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CommandName="cancel" Text="Cancel" class="btn btn-primary" style="color: white;"/>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="card" style="margin-left:30px;width:349px;height:630px;">
                      <asp:Image class="card-img-top img-fluid" runat="server" width="170px" height="140px" style="margin-left:80px; " ID="Image3" ImageUrl='<%# "/images/" + Eval("package_Image") %>' />
                        <div class="card-body">
                            <h4 class="card-title">
                            
                           
                            <asp:Label ID="package_NameLabel" runat="server" Text='<%# Eval("package_Name") %>' /></h4>
                            <p class="card-text">
                            <br /><b>Items:</b> 
                            <asp:Label ID="package_ItemsLabel" runat="server" Text='<%# Eval("package_Items") %>' /></p>
                            <br />
                            <p class="card-text">
                            <b>package Description:</b>
                            <asp:Label ID="package_DescLabel" runat="server" Text='<%# Eval("package_Desc") %>' /></p>
                            <br />
                            <p class="card-text">
                            <b>package Price:</b>
                            <asp:Label ID="package_PriceLabel" runat="server" Text='<%# Eval("package_Price") %>' /></p>
                            <p class="card-text">
                                <b>Package Festive:</b>
                                <asp:Label ID="package_festive" runat="server" Text='<%# Eval("package_festival") %>'></asp:Label>
                            </p>
                            <br />
                            <br />
                            <asp:Button ID="Button3" runat="server" Text="Edit" CommandName="edit" class="btn btn-primary" style="color: white;" />
                            
                            <br />
                            </div>
                                </div>

                        </ItemTemplate>
                        
                    </asp:DataList>
                    </div>
                  </div>
                </div>
                        </section>
                
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Package]"></asp:SqlDataSource>
                  

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>


    </section>
    </form>



</asp:Content>
