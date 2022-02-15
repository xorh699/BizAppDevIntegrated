<%@ Page Title="" Language="C#" MasterPageFile="~/nonmembermaster.Master" AutoEventWireup="true" CodeBehind="nonmemberproduct_desc.aspx.cs" Inherits="BizAppDev.nonmemberproduct_desc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- Choices CSS-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/styles/choices.min.css">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/style.default.premium.2a30c8f8.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/custom.0a822280.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/favicon.3903ee9d.ico">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
   
    <link rel="stylesheet" href="css/productdesc.css" />
        <style>
.checked {
  color: orange;
}
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
  
   <div class="header" style=" padding: 60px;
  text-align: center;
  background: #FEBBC1;
  color: white;
  font-size: 30px;height:320px;">
 <br />
        <br />
        <h1>Product Description</h1>
 
</div>
    <br />
    <br />
    <br />
    
        <br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Product_ID" DataSourceID="SqlDataSource1" CaptionAlign="Right" CssClass="about" Height="500px" HorizontalAlign="Center" OnItemCommand="DataList1_ItemCommand">
      
        <ItemTemplate>
             <asp:Image ID="Image1" runat="server" Height="175px" ImageAlign="Left" ImageUrl='<%# "/images/" + Eval("Product_Image") %>' />
             <div class="card">
              <h1><asp:Label ID="Product_NameLabel" runat="server" Text='<%# Eval("Product_Name") %>' /></h1>
              <h6>Product ID: <asp:Label ID="Product_IDLabel" runat="server" Text='<%# Eval("Product_ID") %>' /></h6>
              <h7> <asp:Label ID="Product_DescLabel" runat="server" Text='<%# Eval("Product_Desc") %>' /></h7>
              <h5><asp:Label ID="Unit_PriceLabel" runat="server" Text='<%# Eval("Unit_Price", "{0:C}") %>' />     <span class="fa fa-star checked"></span>
                                                                                                                <span class="fa fa-star checked"></span>
                                                                                                                <span class="fa fa-star checked"></span>
                                                                                                                <span class="fa fa-star"></span>
                                                                                                                <span class="fa fa-star"></span> </h5>
             <p>Available Quantity: <asp:Label ID="Stock_LevelLabel" runat="server" Text='<%# Eval("Stock_Level") %>' /></p>
                 <p class="auto-style1">
                     Quantity:&nbsp;
                     <asp:TextBox ID="tb_quantity" runat="server" Height="19px" Width="165px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfv_quantity" runat="server" ErrorMessage="Cannot be Blank" ControlToValidate="tb_quantity" ForeColor="Red"></asp:RequiredFieldValidator>
                 </p>
               <center><asp:Button ID="btn_aDDTOCART" runat="server" Text="Add to Cart" BackColor="Blue" ForeColor="White"  Width="100px" CommandName="addtocart" CommandArgument='<%#Eval("Product_ID")%>'  /></center>
              </div>
           
        </ItemTemplate>
     </asp:DataList>
   
    

     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT * FROM [Products] WHERE ([Product_ID] = @Product_ID)">
         <SelectParameters>
             <asp:QueryStringParameter Name="Product_ID" QueryStringField="id" Type="String" />
         </SelectParameters>
     </asp:SqlDataSource>
</asp:Content>
