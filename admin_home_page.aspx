<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="admin_home_page.aspx.cs" Inherits="databaseteam18.admin_home_page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/admin.css" rel="stylesheet" type="text/css"/>
<main aria-labelledby="admin_home_forms">
        <div className="container">
            <div class="containerNew" id="desc-format">
                <h2 class="text-center font-weight-bold">User Roles Descriptions</h2>
                <p class="format">EMPLOYEE ROLE: Default role assigned to users after signup. Basic permission to view tasks and profile information.</p>
                <p class="format">MANAGER ROLE: Manager role assigned to Project Managers. Permission to manage project, tasks, and profile information.</p>
                <p class="format">ADMIN ROLE: System administrator role.</p>

            </div><br/>

           




            <div class="containerNew2">
               <form>
                  <div class="form-group row" style="padding: 10px;">
                    <label for="userLoginEmail" class="col-sm-2 col-form-label">User Login Email*</label>
                    <div class="col-sm-6">
                      <input type="email" class="form-control" id="user_login_email" runat ="server" required>
                    </div>
                  </div>
                  <div class="form-group row" style="padding: 10px;">
                    <label for="roleType" class="col-sm-2 col-form-label">Role Type</label>
                    <div class="col-sm-6">
                      <select name="role_id" id="role_id" runat="server">
                          <option value=2>Manager Role</option>
                          <option value=3 selected>Employee Role</option>
                          <option value=1>Admin Role</option>
                      </select>
                    </div>
                  </div>
                   <div style="padding: 10px;">
                       <button id="userRoleAssignmentSubmitButton" type="submit" class="btn btn-secondary btn-small" runat="server">Submit</button>
                    </div>
                </form>
                    </div>
                    <!-- Error message display -->
                    <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
                    </div>
                    <!-- Success message display -->
                    <div id="SuccessMessage" class="alert alert-success" runat ="server" style="display:none;">
            </div><br/>

             <div class="containerTable">
                <p>table goes here: employee and email</p>
            </div><br/>

        </div>
  
    </main>


</asp:Content>