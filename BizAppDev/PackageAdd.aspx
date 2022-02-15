<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PackageAdd.aspx.cs" Inherits="BizAppDev.PackageAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
    <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0" width="1000px">
              <h2 class="mb-0 p-1" style="text-align:center;">Add Package</h2>
            </div>
        <script text="text/javascript">
        function validatechecklist(source, args) 
        { 
            var chkListModules= document.getElementById ('<%= CheckBoxList1.ClientID %>'); 
            var chkListinputs = chkListModules.getElementsByTagName("input"); 
            for (var i=0;i<chkListinputs .length;i++) 
            { 
                if (chkListinputs [i].checked) 
                { 
                args.IsValid = true; 
                return; 
                } 
            } 
             args.IsValid = false; 
        } 
        </script>
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
              <div class="row" style="margin-left:10px;width:1000px;">
                <div class="col-md-6 col-lg-3" style="margin-left:100px;width:1000px;">

                    <table class="w-100" style="margin-left:100px; width:600px;">
                        <tr>
                            <td style="width: 238px">Package Name:</td>
                            <td>
                                <asp:TextBox ID="tb_name" runat="server" Width="207px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_name" ErrorMessage="please input a name. " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">Package Items:</td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Product_Name" DataValueField="Product_Name">
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT [Product_Name] FROM [Products]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validatechecklist" ErrorMessage="please select at least one input. " ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">Package Descriptions:</td>
                            <td>
                                <asp:TextBox ID="tb_desc" runat="server" Height="91px" TextMode="MultiLine" Width="299px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please input the package description. " ControlToValidate="tb_desc" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">Package Price:</td>
                            <td>
                                <asp:TextBox ID="tb_price" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please input the package price. " ControlToValidate="tb_price" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="please input a valid package price. " ForeColor="Red" MaximumValue="999" MinimumValue="1" ControlToValidate="tb_price"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">Package Keyword: </td>
                            <td>
                                <asp:TextBox ID="td_keyword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="td_keyword" ErrorMessage="Please enter keyword." ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">Package Image: </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="please upload an image for the package. " ControlToValidate="FileUpload1" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 238px">&nbsp;</td>
                            <td>
                                <asp:Button ID="btn_insert" runat="server" OnClick="btn_insert_Click" OnClientClick="" Text="Insert" class="btn btn-primary"/>
&nbsp;<asp:Button ID="btn_view" runat="server" Text="View Package" CausesValidation="False" class="btn btn-primary"/>
                            </td>
                        </tr>
                    </table>
                    </div>
                  </div>
                </div>
                        </section>
    </form>



</asp:Content>
