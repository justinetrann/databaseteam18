<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/employee_site.Master" AutoEventWireup="true" CodeBehind="Employee_Profile_Page.aspx.cs" Inherits="databaseteam18.Employee_Profile_Page"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/project_form.css" rel="stylesheet" type="text/css"/>

    <main aria-labelledby="project_form">
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
    </main>
</asp:Content>
