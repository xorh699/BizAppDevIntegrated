<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signuppage.aspx.cs" Inherits="BizAppDev.Signuppage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title></title>

     <!-- Bootstrap 4.5.2 CSS -->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/vendor/font-awesome/css/font-awesome.min.css">
    <!-- Fontastic Custom icon font-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/css/fontastic.css">
    <!-- Google fonts - Poppins -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/css/style.default.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/css/custom.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin/1-4-6/img/favicon.ico">
    <link rel="stylesheet" type="text/css" href="https://colorlib.com//polygon/adminty/files/bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="https://colorlib.com//polygon/adminty/files/assets/icon/icofont/css/icofont.css">
    <link rel="stylesheet" href="https://colorlib.com/polygon/octopus/assets/vendor/bootstrap-datepicker/css/datepicker3.css">
    <link rel="stylesheet" href="https://adminlte.io/themes/v3/plugins/daterangepicker/daterangepicker.css">
</head>
   <body>
    <div class="page login-page">
      <div class="container d-flex align-items-center">
        <div class="form-holder has-shadow">
          <div class="row">
            <!-- Logo & Information Panel-->
            <div class="col-lg-6">
              <div class="info d-flex align-items-center">
                <div class="content">
                   <div style = 'text-align:center; margin-left:150px;'>
                      <p1 style =" font-size:50px;">SIGN UP</p1>
                </div>
                     <p style = 'text-align:center; margin-left:150px;'>Welcome to Kim Zua!</p>
                </div>
              </div>
            </div>
            <!-- Form Panel    -->
            <div class="col-lg-6 bg-white">
              <div class="form d-flex align-items-center">
                <div class="content">
                  <form class="form-horizontal "  runat="server">
                
                      First name:
                      <asp:TextBox ID="tb_Firstname" runat="server" CssClass="input-material"></asp:TextBox>   
                        Last name:
                      <asp:TextBox ID="tb_Lastname" runat="server" CssClass="input-material"></asp:TextBox> 
                        Username:    <asp:TextBox ID="tb_username" runat="server" CssClass="input-material"></asp:TextBox> 
                         Date of Birth:<asp:TextBox ID="tb_Birthdate" runat="server" CssClass="input-material"></asp:TextBox>
                        Gender: <br /><asp:RadioButtonList ID="rbl_Gender" runat="server" Cssclass="i-checks">
                            <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                                 </asp:RadioButtonList> 
                         <br />
                         Email Address:<asp:TextBox ID="tb_Email" runat="server" CssClass="input-material"></asp:TextBox>
                         Contact Number:<asp:TextBox ID="tb_Contactno" runat="server" CssClass="input-material"></asp:TextBox>
                         Address:<asp:TextBox ID="tb_Address" runat="server" CssClass="input-material"></asp:TextBox>
                         Password:<asp:TextBox ID="tb_Password" runat="server" CssClass="input-material"></asp:TextBox>
                         Confirm Password:<asp:TextBox ID="tb_CfmPassword" runat="server" CssClass="input-material"></asp:TextBox>
&nbsp;<br />                  
                    <div class="form-group">
                       <asp:Button ID="Register_Btn" class="btn btn-primary mb-3" runat="server" Text="Register" OnClick="Register_Btn_Click"/>
                    </div>
               <small>Already have an account? </small><a href="Loginpage.aspx" class="signup">Login</a>
                           </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
        </div>
</body>
</html>