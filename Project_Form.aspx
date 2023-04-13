<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project_Form.aspx.cs" Inherits="databaseteam18.Project_Form"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link href="Styles/project_forms.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="project_form">
       <!--Project Form Introduction-->
        <div class="title-page">
            <video class="fill-container" autoplay="" loop="" muted="">
            <source src="video/project-form.mp4" type="video/mp4" />
                Your browser does not support the video tag.
            </video>
            <div class="video-text">
            <h1>Project Form</h1>
            <p>A document that outlines the details and goals of a project, including its</p>
            <p> task, timeline, budget, and estimated efforts.</p>
            </div>
        </div><br/>

        <!--NEW PROJECT FORM-->
        <div class="row"/>
        <div class="col-md-6">
                <div class="containerNew">
                    <div class="project-content">
                        <div class="project-div-form">
                            <h2 class="form-title">Project Form</h2>
                            <form method="post" class="project-form" id="project-form">
                                <!-- Project Name input -->
                                <div class="form-group">
                                    <label for="project-name">
                                        <i class="bi bi-archive-fill"></i>
                                    </label>
                                    <input type="text" name="project-name" id="project_name" placeholder="Project Name" runat ="server"/>
                                </div>
                                 <p>Start Date</p>
                                <!-- Start Date input -->
                                <div class="form-group">
                                    <label for="state-date">
                                        <i class="bi bi-calendar-check"></i>
                                    </label>
                                    <input type="date" name="start-date" id="project_start_date" runat ="server"/>
                                </div>
                                 <p>End Date</p>
                                <!-- End Date input -->
                                <div class="form-group">
                                    <label for="end-date">
                                        <i class="bi bi-calendar-check-fill"></i>
                                    </label>
                                    <input type="date" name="end-date" id="project_end_date" runat ="server"/>
                                </div>
                                <p>Estimated Cost</p>
                                <!-- Estimated Cost -->
                                <div class="form-group">
                                    <label for="estimated-cost">
                                        <i class="bi bi-wallet-fill"></i>
                                    </label>
                                    <input type="number" name="estimated-cost" id="estimated_cost" runat ="server"/>
                                </div>
                                <p>Estimated Effort</p>
                                <!-- Estimated Effort  -->
                                <div class="form-group">
                                    <label for="estimated-cost">
                                        <i class="bi bi-people-fill"></i>
                                    </label>
                                    <input type="number" name="estimated-effort" id="estimated_effort" runat ="server"/>
                                </div>                        
                              <!--<div class="form-group row">
                                <label for="inputManager">Managers</label>
                                <textarea class="form-control" id="inputManager" rows="3" placeholder="Full Name 1,Full Name 2,Full Name 3"></textarea>
                              </div>-->
               
                                <button type="submit" id="submitButton" class="btn btn-primary" runat="server">Submit</button>

                                <%--!-- Error message display -->--%>
                                <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
                                </div>
                                <div id="successMessage" class="alert alert-success" runat ="server" style="display:none;">
                    
                                </div>

                            </form>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
          </div>
        <div class="col-md-6"/>

        <!-- List of Current Users in System -->
        <div class="containerTable">
            <h5 class="text-center text-muted mb-3 h5">Current Projects In System</h5>
            <asp:GridView ID ="GridViewProjectForm" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Right">
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
        </div><br/>
    </main>
</asp:Content>

