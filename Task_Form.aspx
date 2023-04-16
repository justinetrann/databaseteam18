<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Task_Form.aspx.cs" Inherits="databaseteam18.Task_Form"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link href="Styles/tasks_form.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="task_form">
        <div classname="container">
           <!--Manager Page Introduction-->
            <div class="title-page">
                <video class="fill-container" autoplay="" loop="" muted="">
                <source src="video/video2.mp4" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <div class="video-text">
                <h1>Create Tasks.</h1>
                </div>
            </div><br/>

        <!--New Task Form-->
        <div class="form-container">
            <div class="container">
                <div class="row justify-content-center">
                <!--Form-->
                <div class="col-md-6">
                    <div class="form-content text-left">
                        <h2>Task Form</h2>
                            <form method="post" class="project-form" id="project-form">
                                <!-- Task Name input -->
                                <div class="form-group text-left">
                                    <label for="task-name">
                                        <i class="bi bi-gear-fill"></i>
                                    </label>
                                    <input type="text" id="task_name" placeholder="Task Name" runat ="server"/>
                                </div>

                                <!-- Task Description input -->
                                <div class="form-group text-left">
                                    <label for="task-description">
                                        <i class="bi bi-pen-fill"></i>
                                    </label>
                                    <input type="text" id="task_description" placeholder="Task Description" runat ="server"/>
                                </div>

                                <!-- Estimated Duration input -->
                                <div class="form-group text-left">
                                    <label for="estimated-duration">
                                        <i class="bi bi-alarm-fill"></i>
                                    </label>
                                    <input type="number" id="estimated_duration" placeholder="0" runat ="server"/>
                                </div>

                                <p>Task Employee</p>
                                <!-- Task Employee -->
                                <div class="form-group text-left">
                                    <div class="row">
                                      <div class="col-sm-2" style="flex: 0 0 auto; width: 2%;">
                                        <label for="task-employee">
                                          <i class="bi bi-person-fill"></i>
                                        </label>
                                      </div>
                                      <div class="col-sm-3">
                                        <asp:DropDownList ID="task_employees" runat="server" style="width: 100%; margin-left: 10px;" ></asp:DropDownList>
                                      </div>
                                    </div>
                                </div>
                                <!-- Task Predecessor -->
                                <p>Task Predecessor</p>
                                <div class="form-group text-left">
                                    <div class="row">
                                      <div class="col-sm-2" style="flex: 0 0 auto; width: 5%;">
                                        <label for="task-predecessor">
                                          <i class="bi bi-list-task"></i>
                                        </label>
                                      </div>
                                      <div class="col-sm-3">
                                        <div class="col-sm-3">
                                          <%--<select name="taskPredecessor" id="task_predecessor">
                                              <option value=NULL>Select Predecessor</option>
                                              <option value=NULL selected>N/A - None</option>
                                          </select>--%>
                                        <asp:DropDownList ID="task_results" runat="server"></asp:DropDownList>
                                        </div>
                                      </div>
                                    </div>
                                </div>
                                 <p>Task Deadline</p>
                                <!-- Task Deadline-->
                                <div class="form-group text-left">
                                    <label for="Deadline-date">
                                        <i class="bi bi-calendar-check-fill"></i>
                                    </label>
                                    <input type="date" id="task_deadline" runat="server"/>
                                </div>
                                <button type="submit" id ="submitButton" runat ="server" class="btn btn-primary">Submit</button>
                            </form>

                         <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;"/>
                        <div id="successMessage" class="alert alert-success" runat ="server" style="display:none;"/>
                    </div>
                </div>

                <!--Employees and Projects-->
                <div class="col-md-6">
                    <div class="project-content">
                        <h2>Employees Current Tasks</h2>
                        <div class="containerTable">
                            <asp:GridView ID ="GridViewEmployeesAssignedProjects" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Right">
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
                    </div>
                </div>

                </div>
            </div>
        </div>
    </main>
</asp:Content>
