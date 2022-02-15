<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="BizAppDev.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1" style="text-align:center;">Add Product </h2>
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
                    <section>
            <div class="container-fluid" id="div_Membership">
              <div class="row" style="margin-left:10px;">
                <div class="col-md-6 col-lg-3">

                    <table class="autoComplete_wrapper">
                        <tr>
                            <td>Product Name:</td>
                            <td>
                                <asp:TextBox ID="tb_name" runat="server" CausesValidation="True"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_name" ErrorMessage="please enter the product name. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Description:</td>
                            <td>
                                <asp:TextBox ID="tb_desc" runat="server" Height="118px" TextMode="MultiLine" Width="332px" CausesValidation="True"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_desc" ErrorMessage="please enter product description." ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Unit Price: </td>
                            <td>
                                <asp:TextBox ID="tb_price" runat="server" CausesValidation="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tb_price" ErrorMessage="please enter a unit price" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tb_price" ErrorMessage="please input a value more than 0." ForeColor="Red" MaximumValue="1000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 78px">Product Image:</td>
                            <td style="height: 78px">
                                <asp:FileUpload ID="fu_image" runat="server" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="fu_image" ErrorMessage="please upload a product image" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Stock Level:</td>
                            <td>
                                <asp:TextBox ID="tb_stock" runat="server" CausesValidation="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tb_stock" ErrorMessage="please input a valid stock number of more than 0." ForeColor="Red" MaximumValue="999999" MinimumValue="0"></asp:RangeValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_stock" ErrorMessage="please input a valid stock level. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Supplier Name:</td>
                            <td>
                                <asp:TextBox ID="tb_supplname" runat="server" Width="297px" CausesValidation="True"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_supplname" ErrorMessage="please input the supplier name. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Supplier Email: </td>
                            <td>
                                <asp:TextBox ID="tb_supplemail" runat="server" TextMode="Email" Width="299px" CausesValidation="True"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_supplemail" ErrorMessage="please input the supplier email. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Category: </td>
                            <td>
                                <asp:DropDownList ID="ddl_category" runat="server" Width="241px">
                                    <asp:ListItem>Joss Money</asp:ListItem>
                                    <asp:ListItem>Joss Paper</asp:ListItem>
                                    <asp:ListItem>Joss Sticks </asp:ListItem>
                                    <asp:ListItem>Candles </asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddl_category" ErrorMessage="Please choose one of the category stated above. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Keywords Used for Search:</td>
                            <td>
                                <asp:TextBox ID="tb_keywords" runat="server" Width="294px"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tb_keywords" ErrorMessage="please enter some keywords that customer might use to search. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btn_edit" runat="server" OnClick="btn_edit_Click" Text="Insert" class="btn btn-primary" style="color: white; " />
&nbsp;<asp:Button ID="btn_view" runat="server" OnClick="btn_view_Click" Text="view product list" class="btn btn-primary" style="color: white; " CausesValidation="False"/>
                            </td>
                        </tr>
                    </table>
</section>
    </form>


</asp:Content>
