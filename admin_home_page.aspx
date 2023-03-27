﻿<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="admin_home_page.aspx.cs" Inherits="databaseteam18.admin_home_page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>
<main aria-labelledby="admin_home_forms">
        <%--<div className="container">
           
        </div>--%>
    <%--<div className="container">
           
        </div>--%>


    <ul class="tabs" data-responsive-accordion-tabs="tabs medium-accordion large-tabs" id="example-tabs">
  <li class="tabs-title is-active"><a href="#panel1" aria-selected="true">User Role Assignment</a></li>
  <li class="tabs-title"><a href="#panel2">Department Assigment</a></li>
    </ul>

    <div class="tabs-content" data-tabs-content="example-tabs">
        <div class="tabs-panel is-active" id="panel1">
             <form>
              <div class="form-group row">
                <label for="userLoginEmail" class="col-sm-2 col-form-label">User Login Email*</label>
                <div class="col-sm-6">
                  <input type="email" class="form-control" id="user_login_email" runat ="server" required>
                </div>
              </div>
              <div class="form-group row">
                <label for="roleType" class="col-sm-2 col-form-label">Role Type</label>
                <div class="col-sm-6">
                  <select name="role_id" id="role_id" runat="server">
                      <option value=2>Manager Role</option>
                      <option value=3 selected>Employee Role</option>
                      <option value=1>Admin Role</option>
                  </select>
                </div>
              </div>
                <button id="userRoleAssignmentSubmitButton" type="submit" class="btn3" runat="server">Submit</button>
                <!-- Error message display -->
                <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
                </div>
                <!-- Success message display -->
                <div id="SuccessMessage" class="alert alert-success" runat ="server" style="display:none;">
                    
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
        <div class="tabs-panel" id="panel2">
             <form>
              <div class="form-group row">
                <label for="user_login_email_dept" class="col-sm-2 col-form-label">User Login Email*</label>
                <div class="col-sm-6">
                  <input type="email" class="form-control" id="user_login_email_dept" runat ="server" required>
                </div>
              </div>
              <div class="form-group row">
                <label for="roleType" class="col-sm-2 col-form-label">Role Type</label>
                <div class="col-sm-6">
                  <select name="department_id" id="department_id" runat="server">
                      <option value=1>Executive Department</option>
                      <option value=2>Human Ressource Department</option>
                      <option value=3>I.T. Department</option>
                  </select>
                </div>
              </div>
                <button id="userDepartmentAssignmentSubmitButton" type="submit" class="btn3" runat="server">Submit</button>
                <!-- Error message display -->
                <div id="errorMessage1" class="alert alert-danger" runat ="server" style="display:none;">
                    
                </div>
                <!-- Success message display -->
                <div id="SuccessMessage1" class="alert alert-success" runat ="server" style="display:none;">
                    
                </div>
            </form>
        </div>
        </div>
    </main>


</asp:Content>