<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="department_assign.aspx.cs" Inherits="databaseteam18.department_assign" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/department.css" rel="stylesheet" type="text/css"/>
<main aria-labelledby="admin_home_forms">
        
    <div classname="container">

        <!--Admin Page Introduction-->
        <div class="title-page">
            <video class="fill-container" autoplay="" loop="" muted="">
            <source src="video/admin-page.mp4" type="video/mp4" />
                Your browser does not support the video tag.
            </video>
            <div class="video-text">
            <h1>WELCOME ADMIN.</h1>
            <h2>Department Assign Page</h2>
            </div>
        </div><br/>

        <div class="containerNew2">

            <!--Department Description-->
            <h3 class="text-center mb-3 h3">Departments</h3>
            <p class="text-center text-muted">Select a Department to be assigned to an employee</p>
            <hr class="my-4" />
            <div class="row">
                <div class="col-lg-4 col-md-12 mb-4">
                <h5 class="text-center mb-3 h5">Executive Department</h5>
                <p class="text-muted"> Create And Review Goals For The Company, Oversee All Aspects Of The Business
                </p>
                </div>
                <div class="col-lg-4 col-md-6 mb-4">
                <h5 class="text-center mb-3 h5">Human Resources Department</h5>
                <p class="text-muted">Responsible For Managing The Employee Life Cycle</p>
                </div>
                <div class="col-lg-4 col-md-6 mb-4">
                <h5 class="text-center mb-3 h5">I.T. Department</h5>
                <p class="text-muted">Charged With Establishing, Monitoring And Maintaining Information Technology Systems And Services.</p>
                </div>
            </div>
            <hr class="my-4" />


            <!--User Form To Sign Up Employees To Department-->
           <form>
              <div class="form-group row" style="padding: 10px;">
                <label for="user_login_email_dept" class="col-sm-2 col-form-label">User Login Email*</label>
                <div class="col-sm-6" style="padding: 10px;">
                  <input type="email" class="form-control" id="user_login_email_dept" runat ="server" required>
                </div>
              </div>
              <div class="form-group row">
                <label for="dept_id" class="col-sm-2 col-form-label">Department Type</label>
                <div class="col-sm-6" style="padding: 10px;">
                  <select name="department_id" id="department_id" runat="server">
                      <option value=1>Executive Department</option>
                      <option value=2>Human Ressource Department</option>
                      <option value=3>I.T. Department</option>
                  </select>
                </div>
              </div>

               <div style="padding: 10px;">
                    <button id="userDepartmentAssignmentSubmitButton" type="submit" class="btn btn-primary btn-small" runat="server">Submit</button>
                </div>
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
