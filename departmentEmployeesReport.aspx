<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departmentEmployeesReport.aspx.cs" Inherits="databaseteam18.departmentEmployeesReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>


    <link href="Styles/task-database.css" rel="stylesheet" type="text/css" />

    <main aria-labelledby="project_form">
        <div class="containerNew">
            <div>
                <h2>Department Employees Report</h2>
                <!-- Report Employee_ID -->
                <%-- <div class="form-group text-left">
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="department-employees">Employee</label>
                            <asp:DropDownList ID="department_employees" runat="server" CssClass="form-control bi bi-chevron-down"></asp:DropDownList>

                        </div>
                    </div>
                </div>--%>
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

            <asp:HiddenField runat="server" ID="projectsCompleted" />
            <asp:HiddenField runat="server" ID="totalHoursCompleted" />
            <%-- <asp:HiddenField runat="server" ID="tasksCompletedLate" />
            <asp:HiddenField runat="server" ID="progressBarColor" />--%>

            <div class="row">
                <label for="tasksCompleted" class="col-sm-4 col-form-label">Projects Completed: <b style="color: #2461BF"><%= projectsCompleted.Value %></b>    </label>
                <label for="tasksCompletedOnTime" class="col-sm-4 col-form-label">Total Hours Completed: <b style="color: #2461BF"><%= totalHoursCompleted.Value %> </b></label>
                <%--                <label for="tasksCompletedLate" class="col-sm-4 col-form-label">Tasks Completed Late: <b style="color: #2461BF"><%= tasksCompletedLate.Value %></b> </label>--%>
            </div>
            <br />
            <div>
                <div>
                    <asp:HiddenField runat="server" ID="ProjectsHoursValues" />
                    <label for="ProjectsHours" class="col-form-label">Project Hours Repartition: </label>
                </div><br />
                <div class="col-sm-4">
                    <canvas id="myPieChart"></canvas>
                </div>
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

        <script>
            function createPieChart(canvas, data) {
                var ctx = canvas.getContext('2d');
                var chart = new Chart(ctx, {
                    type: 'pie',
                    data: {
                        labels: data.map(d => d.label),
                        datasets: [{
                            data: data.map(d => d.value),
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.5)',
                                'rgba(54, 162, 235, 0.5)',
                                'rgba(255, 206, 86, 0.5)',
                                'rgba(75, 192, 192, 0.5)',
                                'rgba(153, 102, 255, 0.5)',
                                'rgba(255, 159, 64, 0.5)'
                            ]
                        }]
                    }
                });
                return chart;
            }



            var canvas = document.getElementById('myPieChart');
            var data = @Html.Raw(Json.Encode(Model)); // pass the data source from the model to JavaScript
            var chart = createPieChart(canvas, data);

        </script>

    </main>
</asp:Content>
