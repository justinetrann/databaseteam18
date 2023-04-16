<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/employee_site.Master" AutoEventWireup="true" CodeBehind="Employee_Profile_Page.aspx.cs" Inherits="databaseteam18.Employee_Profile_Page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/employee-profile-page.css" rel="stylesheet" type="text/css"/>
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
            </div><br/>
        </div>
        <div class="containerNew">
            <div>
                <% %>
                <ul style="list-style-type:none">
                    <li>First Name: </li>
                    <li>Last Name: </li>
                    <li>Employee ID: </li>
                    <li>Date of Birth: </li>
                    <li>Sex: </li>
                    <li>Email: </li>
                    <li>Phone Number: </li>
                    <li>SSN (Last 4 #'s): </li>
                    <li>Department Name: </li>
                    <li>Manager's First Name: </li>
                    <li>Manager's Last Name: </li>
                    <li>Manager's ID: </li>
                </ul>
            </div>
        </div>
    </main>
</asp:Content>
