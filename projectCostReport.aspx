<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="projectCostReport.aspx.cs" Inherits="databaseteam18.projectCostReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <link href="Styles/task-database.css" rel="stylesheet" type="text/css" />

    <main aria-labelledby="project_form">
        <div class="containerNew">
            <div>
                <h2>Department Cost Report</h2><br/>
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

            <asp:HiddenField runat="server" ID="departmentName" />
            <asp:HiddenField runat="server" ID="estProjectCost" />
            <asp:HiddenField runat="server" ID="projectCostVariance" />
            <asp:HiddenField runat="server" ID="progressBarColor" />

            <p class="col-form-label" style="text-align: center;">Department Cost Summery</p><br/>
            <div class="row">
                <label for="departmentName" class="col-sm-4 col-form-label">Department Name: <b style="color: #2461BF"><%= departmentName.Value %></b></label>
                <label for="estProjectCost" class="col-sm-4 col-form-label">Department Estimated Cost: <b style="color: #2461BF"><%= estProjectCost.Value %></b>    </label>
                <label for="projectCostVariance" class="col-sm-4 col-form-label">Department Cost variance: <b style="color: #2461BF"><%= projectCostVariance.Value %> </b></label>

            </div>
            <br />
            <div class="row align-items-start">
                <div class="col-sm-3">
                    <asp:HiddenField runat="server" ID="projectCostVariancePercentage" />
                    <label for="projectCostVariancePercentage" class="col-form-label">Project Cost Variance Percentage: </label>
                </div>
                <div class="col-sm-4">
                    <div class="progress" role="progressbar" aria-label="Example with label" aria-valuenow="<%= projectCostVariancePercentage.Value %>" aria-valuemin="0" aria-valuemax="100">
                        <div class="progress-bar progress-bar-striped progress-bar-animated <%= progressBarColor.Value %>% " style="width: <%= projectCostVariancePercentage.Value %>%">
                            <%= projectCostVariancePercentage.Value %>%
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <asp:HiddenField runat="server" ID="actualProjectCost" />
                <label for="actualProjectCost" class="col-sm-4 col-form-label">Project Actual Cost: <b style="color: #2461BF"><%= actualProjectCost.Value %></b> </label>
            </div>
        </div>

        <br />
        <div class="containerNew" style="display: true" id="gridViewContainer">
            <div id="errorMessage" class="alert alert-danger" runat="server" style="display: none;" />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height="200px" AutoGenerateColumns="True">
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
