<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="department_assign.aspx.cs" Inherits="databaseteam18.department_assign" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>
<main aria-labelledby="admin_home_forms">
        
    <div className="container">
           <form>
              <div class="form-group row">
                <label for="user_login_email_dept" class="col-sm-2 col-form-label">User Login Email*</label>
                <div class="col-sm-6">
                  <input type="email" class="form-control" id="user_login_email_dept" runat ="server" required>
                </div>
              </div>
              <div class="form-group row">
                <label for="dept_id" class="col-sm-2 col-form-label">department Type</label>
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


   
        

             
    </main>


</asp:Content>
