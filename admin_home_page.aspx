<%@ Page Title="Project Management System - ADMIN Home" Language="C#" MasterPageFile="~/admin_site.Master" AutoEventWireup="true" CodeBehind="admin_home_page.aspx.cs" Inherits="databaseteam18.admin_home_page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/admin.css" rel="stylesheet" type="text/css"/>
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
                <h2>Role Assign Page</h2>
                </div>
            </div><br/>


            <div class="containerNew2">

                <!--User Role Description-->
                <h3 class="text-center mb-3 h3">User Roles</h3>
                <p class="text-center text-muted">Select a role to be assigned to an employee</p>
                <hr class="my-4" />
                <div class="row">
                  <div class="col-lg-4 col-md-12 mb-4">
                    <h5 class="text-center mb-3 h5">Employee Role</h5>
                    <p class="text-muted"> Default Role Assigned To Users After Signing Up, Basic Permission To View And Profile Information
                    </p>
                  </div>
                  <div class="col-lg-4 col-md-6 mb-4">
                    <h5 class="text-center mb-3 h5">Manager Role</h5>
                    <p class="text-muted">Manger Role Assigned To Project Managers, Permission To Manage Project, Tasks, And Profile Information</p>
                  </div>
                  <div class="col-lg-4 col-md-6 mb-4">
                    <h5 class="text-center mb-3 h5">Admin Role</h5>
                    <p class="text-muted">System Admin Role The Authority To Assign Roles And Department To Other Users</p>
                  </div>
                </div>
                <hr class="my-4" />

                <!--User Form To Sign Up Employees-->
                <form>
                    <div class="form-group row" style="padding: 10px;">
                    <label for="userLoginEmail" class="col-sm-2 col-form-label">User Login Email*</label>
                    <div class="col-sm-6">
                        <input type="email" class="form-control" id="user_login_email" runat ="server" required>
                    </div>
                    </div>
                    <div class="form-group row" style="padding: 10px;">
                    <label for="roleType" class="col-sm-2 col-form-label">Role Type</label>
                    <div class="col-sm-6">
                        <select name="role_id" id="role_id" runat="server">
                            <option value=2>Manager Role</option>
                            <option value=3 selected>Employee Role</option>
                            <option value=1>Admin Role</option>
                        </select>
                    </div>
                    </div>
                    <div style="padding: 10px;">
                        <button id="userRoleAssignmentSubmitButton" type="submit" class="btn btn-primary btn-small" runat="server">Submit</button>
                    </div>
                </form>
                    </div>
                    <!-- Error message display -->
                    <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
                    </div>
                    <!-- Success message display -->
                    <div id="SuccessMessage" class="alert alert-success" runat ="server" style="display:none;">
            </div><br/>
                
            <!-- List of Current Users in System -->
            <div class="containerTable">
                <h5 class="text-center text-muted mb-3 h5">Current Users In System</h5>
                <asp:GridView ID ="GridViewAdmin" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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

    </div>
    </main>


</asp:Content>