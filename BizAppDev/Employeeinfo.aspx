<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Employeeinfo.aspx.cs" Inherits="BizAppDev.Employeeinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
           <header class="bg-white shadow-sm px-4 py-3 z-index-20">
            <div class="container-fluid px-0">
              <h2 class="mb-0 p-1" style="margin-left:30px">Employee List</h2>
            </div>
          </header>
          <!-- Breadcrumb-->
          <div class="bg-white">
            <div class="container-fluid">
              <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 py-3" style="margin-left:30px;">
                  <li class="breadcrumb-item"><a class="fw-light" href="~/EmployeeList.aspx">Employee List</a></li>
              
                  
                </ol>
              </nav>
            </div>
          </div>

         <asp:DataList ID="DataList1" runat="server" onEditCommand="myListEditHandler"  
         onUpdateCommand="myListUpdateHandler" RepeatColumns="3" DataKeyField="EmpID"  onCancelCommand="myListCancelHandler" DataSourceID="SqlDataSource1" OnDeleteCommand="DataList1_DeleteCommand" >

             <ItemTemplate>   
                 <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                      <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." width="170" height="140" style="margin-right:10px;">
                        <div class="ms-3">
                EmpID:
                            <asp:Label ID="EmpIDLabel" runat="server" Text='<%# Eval("EmpID") %>' />
                            <br />
                            EmpName:
                            <asp:Label ID="EmpNameLabel" runat="server" Text='<%# Eval("EmpName") %>' />
                            <br />
                            NRIC:
                            <asp:Label ID="NRICLabel" runat="server" Text='<%# Eval("NRIC") %>' />
                            <br />
                            Birthdate:
                            <asp:Label ID="BirthdateLabel" runat="server" Text='<%# Eval("Birthdate") %>' />
                            <br />
                            Gender:
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                            <br />
                            Contactno:
                            <asp:Label ID="ContactnoLabel" runat="server" Text='<%# Eval("Contactno") %>' />
                            <br />
                            Email:
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                            <br />
                           
                            Address:
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                            <br />
                            <br />
                <asp:Button ID="Linkbutton3" runat="server" class="btn btn-primary btn-sm" commandname="Edit" text=' <%# "Edit" %>' />
          
            </ItemTemplate>
           
                       
            <EditItemTemplate>
          <div class="card" style="margin-right: 30px; width:600px; left: 200px; height:300px;">
                    <div class="card-body">
                      <div class="d-flex align-items-center"><img class="avatar avatar-lg" src="https://medias.spotern.com/spots/w640/95/95891-1532336916.jpg" title="..." width="170" height="140" style="margin-right:10px;">
                        <div class="ms-3">
                            EmpID:
                            <asp:Label ID="EmpIDLabel" runat="server" Text='<%# Eval("EmpID") %>'></asp:Label>
                            <br />
                            EmpName:
                            <asp:TextBox ID="tb_EmpName" runat="server" Text='<%# Eval("EmpName") %>'></asp:TextBox>
                            <br />
                     
                            NRIC:
                            <asp:TextBox ID="tb_NRIC" runat="server" Text='<%# Eval("NRIC") %>'></asp:TextBox>
                            <br />
                            Birthdate:
                            <asp:Label ID="BirthdateLabel" runat="server" Text='<%# Eval("Birthdate") %>'></asp:Label>
                            <br />
                            Gender:
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                            <br />                   
                            Contactno:
                            <asp:TextBox ID="tb_Contactno" runat="server" Text='<%# Eval("Contactno") %>'></asp:TextBox>
                            <br />
                            Email:
                            <asp:TextBox ID="tb_Email" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                            <br />
                            Address:
                            <asp:TextBox ID="tb_Address" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                            <br />
                            <br />
                            <br />
                         

           
               <asp:Button ID="Linkbutton1" class="btn btn-primary btn-sm" CommandName="update" runat="server" text="Update" />
               <asp:Button ID="Linkbutton2" class="btn btn-primary btn-sm" CommandName="cancel" runat="server" text="Cancel" />       
            
            </EditItemTemplate>
            
            
              
             </asp:DataList>
             
              
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>"
            SelectCommand="SELECT * FROM [Employee] WHERE ([EmpID] = @EmpID)">
           
              <SelectParameters>
                  <asp:QueryStringParameter Name="EmpID" QueryStringField="EmpID" Type="String" />
              </SelectParameters>
           
        </asp:SqlDataSource>
              
     </form>
              
</asp:Content>
