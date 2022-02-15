<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="Rewards.aspx.cs" Inherits="BizAppDev.Rewards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Bootstrap Material Admin by Bootstrapious.com</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="robots" content="noindex">
    <!-- Google fonts - Poppins -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- Choices CSS-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/styles/choices.min.css">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/style.default.premium.2a30c8f8.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/css/custom.0a822280.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/img/favicon.3903ee9d.ico">
    <!-- Tweaks for older IEs--><!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script><![endif]-->
      <style>
          body {
    background-color: #eee

          }

.profilecard {
    background-color: #fff;
    width: 280px;
    border-radius: 33px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    padding: 2rem !important;
    flex-direction:row;
    width:50%;


}

.top-container {
    display: flex;
    align-items: center

}

.profile-image {
    border-radius: 10px;
    border: 2px solid #5957f9
}

.name {
    font-size: 15px;
    font-weight: bold;
    color: #272727;
    position: relative;
    top: 8px
}

.mail {
    font-size: 14px;
    color: grey;
    position: relative;
    top: 2px
}

.middle-container {
    background-color: #eee;
    border-radius: 12px;
    width:70%;
}

.middle-container:hover {
    border: 1px solid #5957f9
}

.dollar-div {
    background-color: #5957f9;
    padding: 12px;
    border-radius: 10px
}

.round-div {
    border-radius: 50%;
    width: 35px;
    height: 35px;
    background-color: #fff;
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center
}

.dollar {
    font-size: 16px !important;
    color: #5957f9 !important;
    font-weight: bold !important
}

.current-balance {
    font-size: 15px;
    color: #272727;
    font-weight: bold
}

.amount {
    color: #5957f9;
    font-size: 16px;
    font-weight: bold
}

.dollar-sign {
    font-size: 16px;
    color: #272727;
    font-weight: bold
}

.recent-border {
    border-left: 2px solid #5957f9;
    display: flex;
    align-items: center
}

.recent-border:hover {
    border-bottom: 1px solid #dee2e6 !important
}

.recent-orders {
    font-size: 16px;
    font-weight: 700;
    color: #5957f9;
    margin-left: 2px
}

.wishlist {
    font-size: 16px;
    font-weight: 700;
    color: #272727
}

.wishlist-border:hover {
    border-bottom: 1px solid #dee2e6 !important
}

.fashion-studio {
    font-size: 16px;
    font-weight: 700;
    color: #272727
}

.fashion-studio-border:hover {
    border-bottom: 1px solid #dee2e6 !important
}
.card{
    min-width:400px;
}
      </style>
  </head>
  <body>
    <div class="page" style="min-width:1700px;">

      <div class="page-content d-flex align-items-stretch" style="margin-top:8%;"> 

        <div class="content-inner w-100">
            <div class="container d-flex justify-content-center mt-5">
    <div class="profilecard">
        <div class="top-container"> <img src="https://i.imgur.com/G1pXs7D.jpg" class="img-fluid profile-image" width="70">
            <div class="ml-3">
                <h5 class="name">
                <asp:Label ID="lbl_Name" runat="server" ></asp:Label></h5>
                <p class="mail">
                    <asp:Label ID="lbl_Email" runat="server" Text="Label"></asp:Label>
                   </p>
            </div>
        </div>
        <div class="middle-container d-flex justify-content-between align-items-center mt-3 p-2">
            <div class="dollar-div px-3">
                <div class="round-div"><i class="fa fa-dollar dollar"></i></div>
            </div>
            <div class="d-flex flex-column text-right mr-2"> <span class="current-balance">Current Points Balance</span> <span class="amount"><span class="dollar-sign"></span><asp:Label ID="lbl_Points" runat="server"> Points</asp:Label>
</span> </div>
        </div>
        <br />
      <div style="font-size:10px; color:gray">
      <span>Your points expire on: &nbsp</span><asp:label id="lbl_Expiry" runat="server" />     </div>   <br />
        <span class="current-balance">Progress to
                <asp:Label ID="lbl_exp" runat="server" Text=""></asp:Label> </span>
                <div class="progress">
                                    <div runat="server" class="progress-bar bg-violet" id="pointBar" role="progressbar" style="height: 15px;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
    </div>
                <div class="col-lg-3 col-12">
                  <div class="card mb-3">
                    <div class="card-body">
                      <div class="d-flex align-items-center">
                        <div class="icon flex-shrink-0 bg-red"><i class="fas fa-tasks"></i></div>
                        <div class="ms-3"><strong class="text-lg d-block lh-1 mb-1">
                            <asp:Label ID="lbl_NoVouchers" runat="server"></asp:Label></strong><small class="text-uppercase text-gray-500 small d-block lh-1">Coupons Available</small><br /><asp:Button ID="btn_Coupons" class="btn btn-primary" runat="server" OnClick="btn_Coupons_Click" Text="View Coupons" /></div>
                      </div>
                    </div>
                  </div>
                  <div class="card mb-3">
                       <div class="card-body">
                      <div class="d-flex align-items-center">
 <div class="d-flex align-items-center">
                        <div class="icon flex-shrink-0 bg-red">
                          <svg class="svg-icon svg-icon-sm svg-icon-heavy">
                            <use xlink:href="#survey-1"> </use>
                          </svg>
                        </div>
                    
                        <div class="ms-3"><strong class="text-lg d-block lh-1 mb-1"><h6 class="h4 fw-light text-gray-600 mb-3">Points Transaction<br> History</h6></></strong>
     <asp:Button ID="btn_PointsHistory" class="btn btn-primary" runat="server" OnClick="btn_PointsHistory_Click" Text="View Transactions" /></div>
</div>
                      </div>
                    </div>
                  </div>

                  <div class="card mb-0">
                    <div class="card-body">
                      <div class="d-flex align-items-center">
                        <div class="icon flex-shrink-0 bg-orange"><i class="far fa-paper-plane"></i></div>
                        <div class="ms-3"><strong class="text-lg d-block lh-1 mb-1"><asp:Label ID="lbl_TierName" runat="server"></asp:Label></strong><asp:Button ID="btn_Perks" class="btn btn-primary" runat="server" OnClick="btn_Perks_Click" Text="View Perks" /></div>
                             <div class="ms-3"><strong class="text-lg d-block lh-1 mb-1"><asp:Label ID="Label1" runat="server"></asp:Label></strong><asp:Button ID="btn_ViewTiers" class="btn btn-primary" runat="server" Text="View Point Tiers" OnClick="btn_ViewTiers_Click" />

</div>
                      </div>
                    </div>
                  </div>

                </div>
</div>
          <!-- Dashboard Counts Section-->
        </div></div>
    </div>
    <!-- JavaScript files-->
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/chart.js/Chart.min.js"></script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/just-validate/js/just-validate.min.js"></script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/vendor/choices.js/public/assets/scripts/choices.min.js"></script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/js/js-cookie.0d5f0e08.js"> </script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/js/demo.bbd40f0c.js"> </script>
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/js/charts-home.36b080a8.js"></script>

    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/js/home-premium.82d409ff.js"> </script>
    <!-- Main File-->
    <script src="https://d19m59y37dris4.cloudfront.net/admin-premium/2-0/js/front.c39dfc0c.js"></script>
    <script>
      // ------------------------------------------------------- //
      //   Inject SVG Sprite - 
      //   see more here 
      //   https://css-tricks.com/ajaxing-svg-sprite/
      // ------------------------------------------------------ //
      function injectSvgSprite(path) {
      
          var ajax = new XMLHttpRequest();
          ajax.open("GET", path, true);
          ajax.send();
          ajax.onload = function(e) {
          var div = document.createElement("div");
          div.className = 'd-none';
          div.innerHTML = ajax.responseText;
          document.body.insertBefore(div, document.body.childNodes[0]);
          }
      }
      // this is set to BootstrapTemple website as you cannot 
      // inject local SVG sprite (using only 'icons/orion-svg-sprite.svg' path)
      // while using file:// protocol
      // pls don't forget to change to your domain :)
      injectSvgSprite('https://bootstraptemple.com/files/icons/orion-svg-sprite.svg'); 
      
      
    </script>
    <!-- FontAwesome CSS - loading as last, so it doesn't block rendering-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
  </body>
</html>
</asp:Content>
