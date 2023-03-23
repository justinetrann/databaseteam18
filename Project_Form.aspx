<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project_Form.aspx.cs" Inherits="databaseteam18.About"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="project_form">
        <div className="container">
            <form>
             <div class="form-group row">
                <label for="inputClientID" class="col-sm-2 col-form-label">Client UID</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="inputClientID">
                </div>
              </div>
              <div class="form-group row">
                <label for="projectID" class="col-sm-2 col-form-label">Project ID</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="projectID">
                </div>
              </div>
              <div class="form-group row">
                <label for="projectName" class="col-sm-2 col-form-label">Project Name</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="projectName">
                </div>
              </div>
              <div class="form-group row">
                <label for="inputProjectStartDate" class="col-sm-2 col-form-label">Start Date</label>
                <div class="col-sm-6">
                  <input type="date" class="form-control" id="projectStartDate">
                </div>
              </div>
              <div class="form-group row">
                <label for="inputProjectEndDate" class="col-sm-2 col-form-label">End Date</label>
                <div class="col-sm-6">
                  <input type="date" class="form-control" id="projectEndDate">
                </div>
              </div>
              <div class="form-group row">
                <label for="inputDepartment" class="col-sm-2 col-form-label">Department ID</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="inputDepartment">
                </div>
              </div>
              <div class="form-group row">
                <label for="numberOfManagers" class="col-sm-2 col-form-label">Number of Managers</label>
                <div class="col-sm-6">
                  <input type="number" class="form-control" id="numManager">
                </div>
              </div>
              <div class="form-group row">
                <label for="inputManager">Managers</label>
                <textarea class="form-control" id="inputManager" rows="3" placeholder="Full Name 1,Full Name 2,Full Name 3"></textarea>
              </div>
                <button type="submit" class="btn3">Submit</button>
            </form>
        </div>
    </main>
</asp:Content>