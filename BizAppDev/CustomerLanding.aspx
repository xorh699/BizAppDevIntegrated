<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMain.Master" AutoEventWireup="true" CodeBehind="CustomerLanding.aspx.cs" Inherits="BizAppDev.CustomerLanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="card">
                    <div class="card-body">
                      <h3 class="card-title">Edit Profile</h3>
                      <div class="row gy-4">
                        <div class="col-md-5">
                          <label class="form-label">Company</label>
                          <input class="form-control" type="text" placeholder="Company" value="Nathan &amp; Nathan">
                        </div>
                        <div class="col-sm-6 col-md-3">
                          <label class="form-label">Username</label>
                          <input class="form-control" type="text" placeholder="Username" value="nathan">
                        </div>
                        <div class="col-sm-6 col-md-4">
                          <label class="form-label">Email address</label>
                          <input class="form-control" type="email" placeholder="Email">
                        </div>
                        <div class="col-sm-6">
                          <label class="form-label">First Name</label>
                          <input class="form-control" type="text" placeholder="First Name">
                        </div>
                        <div class="col-sm-6">
                          <label class="form-label">Last name</label>
                          <input class="form-control" type="text" placeholder="Last name">
                        </div>
                        <div class="col-md-12">
                          <label class="form-label">Address</label>
                          <input class="form-control" type="text" placeholder="Home address">
                        </div>
                        <div class="col-sm-6 col-md-4">
                          <label class="form-label">City</label>
                          <input class="form-control" type="text" placeholder="City">
                        </div>
                        <div class="col-sm-6 col-md-3">
                          <label class="form-label">ZIP</label>
                          <input class="form-control" type="number" placeholder="ZIP">
                        </div>
                        <div class="col-md-5">
                          <label class="form-label">Country</label>
                          <select class="profile-country-choices" data-customclass="form-select">
                            <option value="uk">UK</option>
                            <option value="us">US</option>
                          </select>
                        </div>
                        <div class="col-md-12">
                          <label class="form-label">About Me</label>
                          <textarea class="form-control" rows="5" placeholder="Here can be your description" value="Mike">The bedding was hardly able to cover it and seemed ready to slide off any moment. His many legs, pitifully thin compared with the size of the rest of him, waved about helplessly as he looked. &quot;What's happened to me?&quot; he thought. It wasn't a dream.</textarea>
                        </div>
                      </div>
                    </div>
                    <div class="card-footer text-end">
                      <button class="btn btn-primary" type="submit">Update Profile</button>
                    </div>
                  </form>
</asp:Content>

