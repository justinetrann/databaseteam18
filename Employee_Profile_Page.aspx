﻿<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/employee_site.Master" AutoEventWireup="true" CodeBehind="Employee_Profile_Page.aspx.cs" Inherits="databaseteam18.Employee_Profile_Page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/employee-profile-page.css" rel="stylesheet" type="text/css" />
    <main aria-labelledby="project_form">
        <div classname="container">
            <!--Employee Profile Page-->
            <div class="title-page">
                <video class="fill-container" autoplay="" loop="" muted="">
                    <source src="video/video3.mp4" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <div class="video-text">
                    <h1>Profile.</h1>
                </div>
            </div>
            <br />
        </div>
        <!-- Error message display -->
        <div id="errorMessage" class="alert alert-danger" runat="server" style="display: none;">
        </div>
        <!-- Success message display -->
        <div id="successMessage" class="alert alert-success" runat="server" style="display: none;">
        </div>
        <div class="containerNew">
            <div style="display: grid; grid-template-columns: 1fr 1fr; grid-gap: 10px;">
                <div>
                    <!--Employee ID-->
                    <br />
                    <p>Employee ID: </p>
                    <asp:TextBox ID="employeeID" runat="server" Enabled="false"></asp:TextBox>
                    <br />
                    <!--First Name-->
                    <br />
                    <p>First Name: </p>
                    <asp:TextBox ID="first_name" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFirstName" runat="server" Text="Change First Name" OnClick="btnChangeFirstName" CssClass="btn btn-primary" />
                    <br />
                    <!--Middle Name-->
                    <br />
                    <p>Middle Name: </p>
                    <asp:TextBox ID="middle_name" runat="server"></asp:TextBox>
                    <asp:Button ID="btnMiddleName" runat="server" Text="Change Middle Name" OnClick="btnChangeMiddleName" CssClass="btn btn-primary" />
                    <br />
                    <!--Last Name-->
                    <br />
                    <p>Last Name: </p>
                    <asp:TextBox ID="last_name" runat="server"></asp:TextBox>
                    <asp:Button ID="btnLastName" runat="server" Text="Change Last Name" OnClick="btnChangeLastName" CssClass="btn btn-primary" />
                    <br />
                    <!--Gender-->
                    <br />
                    <p>Gender: </p>
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem Text="None" Value="N"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnGender" runat="server" Text="Change Gender" OnClick="btnChangeGender" CssClass="btn btn-primary" />
                    <br />
                </div>
                <div>
                     <!--Department Name-->
                    <br />
                    <p>Department Name: </p>
                    <asp:TextBox ID="departName" Width="100%"  runat="server" Enabled="false"></asp:TextBox><br />
                    <!--Email-->
                    <br />
                    <p>Email: </p>
                    <asp:TextBox ID="email_address" runat="server"></asp:TextBox>
                    <asp:Button ID="btnEmail" runat="server" Text="Change Email" OnClick="btnChangeEmail" CssClass="btn btn-primary" />
                    <br />
                    <!--Phone Number-->
                    <br />
                    <p>Phone Number: </p>
                    <asp:TextBox ID="phone_number" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPhoneNumber" runat="server" Text="Change Phone Number" OnClick="btnChangePhoneNumber" CssClass="btn btn-primary" />
                    <br />
                    <!--DOB-->
                    <br />
                    <p>Date of Birth: </p>
                    <asp:TextBox ID="current_date_of_birth" Enabled="false" runat="server"></asp:TextBox>
                    <asp:TextBox ID="date_of_birth" placeholder="YYYY-MM-DD" runat="server" type="date"></asp:TextBox>
                    <asp:Button ID="btnDOB" runat="server" Text="Change DOB" OnClick="btnChangeDOB" CssClass="btn btn-primary" />
                    <br />
                    <!--SSN-->
                    <br />
                    <p>SSN (Last 4 #'s): </p>
                    <asp:TextBox ID="SSN_num" runat="server" Enabled="false"></asp:TextBox><br />
                   
                </div>
            </div>
        </div>
    </main>
</asp:Content>
