<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departmentReport.aspx.cs" Inherits="databaseteam18.departmentReport"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="project_form">
        <h2>Department Report</h2>
        <div className="container">
              <div class="form-group row">
                <label for="taskPredecessor" class="col-sm-2 col-form-label">Year</label>
                <div class="col-sm-3">
                  <select name="year" id="year">
                      <option value=NULL selected>Select Year</option>
                      <option value=2016>2016</option>
                      <option value=2017>2017</option>
                      <option value=2018>2018</option>
                      <option value=2019>2019</option>
                      <option value=2020>2020</option>
                      <option value=2021>2021</option>
                      <option value=2022>2022</option>
                      <option value=2023>2023</option>
                      <option value=2024>2024</option>
                      <option value=2025>2025</option>
                  </select>
                </div>
              </div>
                <button type="submit" class="btn3">Generate Report</button>
        </div>
        <div style="display: flex; flex-wrap: wrap;">
            <div style="flex: 64; text-align: left">
                <label for="projectsComplete" class="col-form-label">Tasks Completed: </label>
            </div>
            <div style="flex: 64; text-align: left">
                <label for="projectsLate" class="col-form-label">Tasks Late: </label>
            </div>
            <div style="flex: 64; text-align: left">
                <label for="projectsRate" class="col-form-label">Completion Rate: </label>
            </div>
        </div>
        <div style="display: flex; flex-wrap: wrap;">
            <div style="flex: 64; text-align: left">
              <label for="projectsCost" class="col-form-label">Total Cost: </label>
            </div>
            <div style="flex: 64; text-align: left"></div>
            <div style="flex: 64; text-align: left">
              <label for="projectsEffort" class="col-form-label">Total Effort: </label>
            </div>
        </div>
    </main>
</asp:Content>
