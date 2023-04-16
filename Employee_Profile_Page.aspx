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
            <h5 class="text-center text-muted mb-3" style=" font-weight:bold; font-size: 15px; font-family:Poppins;">Edit Your Profile</h5>
            <div style="text-align: center;">
              <select>
                <option value="">Select an option</option>
                <option value="optionFN">First Name</option>
                <option value="optionLN">Last Name</option>
                <option value="optionDOB">DOB</option>
                <option value="optionS">Sex</option>
                <option value="optionPN">Phone Number</option>
              </select>
                <asp:TextBox ID="changeText" runat="server" placeholder="Change Attribute..."></asp:TextBox>
                  <button type="submit" class="btn btn-secondary">Change</button>
            </div>
        </div>

        <div class="containerNew">
            <div>
                <% %>
                <div style="display: grid; grid-template-columns: 1fr 1fr; grid-gap: 10px;">
                    <div>
                        <ul style="list-style-type:none">
                            <li>First Name: <p id="first-name">First Name</p></li>
                            <li>Last Name: <p id="last-name">Last Name</p></li>
                            <li>Employee ID: <p id="employee-id">Employee ID</p></li>
                            <li>Date of Birth: <p id="date-of-birth">Birth Date</p></li>
                            <li>Sex: <p id="sex">Sex</p></li>
                            <li>Email: <p id="email">Email</p></li>
                        </ul>
                    </div>
                    <div>
                        <ul style="list-style-type:none">
                            <li>Phone Number: <p id="phone-number">Phone Number</p></li>
                            <li>SSN (Last 4 #'s): <p id="last-4-sn">SSN</p></li>
                            <li>Department Name: <p id="departName">Department Name</p></li>
                            <li>Manager's First Name: <p id="manager-first-name">Manager First Name</p></li>
                            <li>Manager's Last Name: <p id="manager-last-name">Manager Last Name</p></li>
                            <li>Manager's ID: <p id="manager-id">Manager ID</p></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
