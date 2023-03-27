<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="admin_home_page.aspx.cs" Inherits="databaseteam18.admin_home_page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>
<main aria-labelledby="user_role_assignment_form">
        <div className="container">
            <form>
              <div class="form-group row">
                <label for="userLoginID" class="col-sm-2 col-form-label">User Login Email*</label>
                <div class="col-sm-6">
                  <input type="email" class="form-control" id="user_login_email" runat ="server" required>
                </div>
              </div>
              <div class="form-group row">
                <label for="roleType" class="col-sm-2 col-form-label">Role Type</label>
                <div class="col-sm-6">
                  <select name="taskPredecessor" id="role_id" runat="server">
                      <option value=2>Manager Role</option>
                      <option value=3 selected>Employee Role</option>
                      <option value=1>Admin Role</option>
                  </select>
                </div>
              </div>
              <!--<div class="form-group row">
                <label for="inputManager">Managers</label>
                <textarea class="form-control" id="inputManager" rows="3" placeholder="Full Name 1,Full Name 2,Full Name 3"></textarea>
              </div>-->
                <button id="userRoleAssignmentSubmitButton" type="submit" class="btn3" runat="server">Submit</button>
                <!-- Error message display -->
                <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    Passwords do not match!
                </div>
                <!-- Success message display -->
                <div id="SuccessMessage" class="alert alert-success" runat ="server" style="display:none;">
                    Passwords do not match!
                </div>
            </form>
            <div class="container">
                <h2>User Roles Descriptions</h2>
                    <ul style="list-style-type:none">
                        <li>EMPLOYEE ROLE: Default role assigned to users after signup. Basic permission to view tasks and profile information.</li>
                        <li>MANAGER ROLE: Manager role assigned to Project Managers. Permission to manage project, tasks, and profile information.</li>
                        <li>ADMIN ROLE: System administrator role.</li>
                    </ul>
                
              </div>
        </div>
    </main>


</asp:Content>