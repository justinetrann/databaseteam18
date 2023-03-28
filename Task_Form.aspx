<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task_Form.aspx.cs" Inherits="databaseteam18.Task_Form"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="project_form">
        <div className="container">
            <form>
              <div class="form-group row">
                <label for="taskName" class="col-sm-2 col-form-label">Task Name</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="task_Name" runat ="server">
                </div>
              </div>
              <div class="form-group row">
                <label for="taskEmployee" class="col-sm-2 col-form-label">Task Employee</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="task_employees" runat="server"> </asp:DropDownList>
                </div>
              </div>
              <div class="form-group row">
                <label for="taskDescription" class="col-sm-2 col-form-label">Task Description</label>
                <div class="col-sm-6">
                  <input type="text" class="form-control" id="task_Description" runat ="server">
                </div>
              </div>
              <div class="form-group row">
                <label for="taskPredecessor" class="col-sm-2 col-form-label">Task Predecessor</label>
                <div class="col-sm-3">
                  <%--<select name="taskPredecessor" id="task_predecessor">
                      <option value=NULL>Select Predecessor</option>
                      <option value=NULL selected>N/A - None</option>
                  </select>--%>
                <asp:DropDownList ID="task_results" runat="server"> </asp:DropDownList>
                </div>
              </div>
              <div class="form-group row">
                <label for="estimatedDuration" class="col-sm-2 col-form-label">Estimated Duration</label>
                <div class="col-sm-6">
                  <input type="number" class="form-control" id="estimated_duration" runat ="server">
                </div>
              </div>
                <button type="submit" id ="submitButton" runat ="server" class="btn3">Submit</button>
            </form>


            <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
                </div>
                <div id="successMessage" class="alert alert-success" runat ="server" style="display:none;">
                    
                </div>
        </div>
    </main>
</asp:Content>
