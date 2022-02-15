<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="BizAppDev.Loginpage" %>
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
                      <p1 style =" font-size:50px;">LOG IN</p1>
                </div>
                  <p style = 'text-align:center; margin-left:150px;'>Welcome to Kim Zua!</p>
                </div>
              </div>
            </div>
            <!-- Form Panel    -->
            <div class="col-lg-6 bg-white">
              <div class="form d-flex align-items-center">
                <div class="content">
              <!-- Form Panel    -->
              <div class="col-lg-6 bg-white">
                <div class="d-flex align-items-center px-4 px-lg-5 h-100">
                  <form class="login-form py-5 w-100" method="get" runat="server">
                    <div class="input-material-group mb-3">
                  
                          Username:
                            <asp:TextBox ID="tb_Username" runat="server" CssClass="input-material"></asp:TextBox>
                            <br />
                        Password:
                            <asp:TextBox ID="tb_Password" runat="server" TextMode="Password" CssClass="input-material"></asp:TextBox>
                            <br />
                    </div>

                       <asp:Button ID="Login_Btn" class="btn btn-primary mb-3" runat="server" Text="Login" OnClick="Login_Btn_Click"/>
                      <br><a class="text-sm text-paleBlue" href="#">Forgot Password?</a><br>
                      <small class="text-gray-500">Do not have an account? </small><a class="text-sm text-paleBlue" href="Signuppage.aspx">Signup</a>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
</body>
</html>
