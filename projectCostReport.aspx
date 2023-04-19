<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="projectCostReport.aspx.cs" Inherits="databaseteam18.projectCostReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <link href="Styles/task-database.css" rel="stylesheet" type="text/css" />

    <main aria-labelledby="project_form">
        <div class="containerNew">
            <div>
                <h2>Project Cost Report</h2>
                <!-- Report Employee_ID -->
                <div class="form-group text-left">
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="department-employees">Project Name</label>
                            <asp:DropDownList ID="department_employees" runat="server"  CssClass="form-control bi bi-chevron-down"></asp:DropDownList>
                            
                        </div>
                    </div>
                </div>
                <!-- Start Date and End Date inputs -->
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-6">
                            <label for="start-date">Start Date</label>
                            <input type="date" name="start-date" id="report_start_date" runat="server" class="form-control" />
                        </div>
                        <div class="col-sm-6">
                            <label for="end-date">End Date</label>
                            <input type="date" name="end-date" id="report_end_date" runat="server" class="form-control" />
                        </div>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary" runat="server" id="submitButton">Generate Report</button>
            </div>
        </div>
        <br />
        <div class="containerNew" style="display: true" id="Container">

            <asp:HiddenField runat="server" ID="tasksCompleted" />
            <asp:HiddenField runat="server" ID="tasksCompletedOnTime" />
            <asp:HiddenField runat="server" ID="tasksCompletedLate" />
            <asp:HiddenField runat="server" ID="progressBarColor" />

            <p class="col-form-label" style="text-align: center;">Project Cost Summery</p></br>
            <div class="row">
                <label for="projectName" class="col-sm-4 col-form-label">Project Name: <b style="color: #2461BF"><%  %></b></label>
                <label for="tasksCompleted" class="col-sm-4 col-form-label">Project Estimated Cost: <b style="color: #2461BF"><%= tasksCompleted.Value %></b>    </label>
                <label for="tasksCompletedOnTime" class="col-sm-4 col-form-label">Project Cost variance: <b style="color: #2461BF"><%= tasksCompletedOnTime.Value %> </b></label>
                <!--<label for="tasksCompletedLate" class="col-sm-4 col-form-label">tasksCompletedLate <b style="color: #2461BF"><%= tasksCompletedLate.Value %></b> </label>-->

            </div>
            <br />
            <div class="row align-items-start">
                <div class="col-sm-3">
                    <asp:HiddenField runat="server" ID="tasksCompletionRateValue" />
                    <label for="tasksCompletionRate" class="col-form-label">Project Cost Variance Percentage: </label>
                </div>
                <div class="col-sm-4">
                    <div class="progress" role="progressbar" aria-label="Example with label" aria-valuenow="<%= tasksCompletionRateValue.Value %>" aria-valuemin="0" aria-valuemax="100">
                        <div class="progress-bar progress-bar-striped progress-bar-animated <%= progressBarColor.Value %> " style="width: <%= tasksCompletionRateValue.Value %>%">
                            <%= tasksCompletionRateValue.Value %>%
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <asp:HiddenField runat="server" ID="hoursWorked" />
                <label for="hoursWorked" class="col-sm-4 col-form-label">Project Actual Cost: <b style="color: #2461BF"><%= hoursWorked.Value %></b> </label>
            </div>
        </div>

        <br />
        <div class="containerNew" style="display: true" id="gridViewContainer">
            <div id="errorMessage" class="alert alert-danger" runat="server" style="display: none;" />
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="Task ID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height="200px" AutoGenerateColumns="True">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
        </div>



    </main>
</asp:Content>
