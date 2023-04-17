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
              <select class="form-select-sm">
                <option value="">Select an option</option>
                <option value="optionFN">First Name</option>
                <option value="optionMN">Middle Name</option>
                <option value="optionLN">Last Name</option>
                <option value="optionDOB">DOB</option>
                <option value="optionG">Gender</option>
                <option value="optionPN">Phone Number</option>
              </select>
                <asp:TextBox ID="changeText" runat="server" placeholder="Change Attribute..."></asp:TextBox>
                  <button type="submit" class="btn btn-secondary">Change</button>
            </div>
        </div>

        <div class="containerNew">
            <div style="display: grid; grid-template-columns: 1fr 1fr; grid-gap: 10px;">
                <div>
                    <br/><p>First Name: </p><asp:TextBox ID="first_name" runat="server"></asp:TextBox><br/>
                    <br/><p>Middle Name: </p><asp:TextBox ID="middle_name" runat="server"></asp:TextBox><br/>
                    <br/><p>Last Name: </p><asp:TextBox ID="last_name" runat="server"></asp:TextBox><br/>
                    <br/><p>Employee ID: </p><asp:TextBox ID="employeeID" runat="server"></asp:TextBox><br/>
                    <br/><p>Date of Birth: </p><asp:TextBox ID="date_of_birth" runat="server"></asp:TextBox><br/>
                    <br/><p>Gender: </p><asp:TextBox ID="gender" runat="server"></asp:TextBox><br/>
                    <br/><p>Email: </p><asp:TextBox ID="email_address" runat="server"></asp:TextBox><br/>
                </div>
                <div>
                    <br/><p>Phone Number: </p><asp:TextBox ID="phone_number" runat="server"></asp:TextBox><br/>
                    <br/><p>SSN (Last 4 #'s): </p> <asp:TextBox ID="SSN_num" runat="server"></asp:TextBox><br/>
                    <br/><p>Department Name: </p><asp:TextBox ID="departName" runat="server"></asp:TextBox><br/>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
