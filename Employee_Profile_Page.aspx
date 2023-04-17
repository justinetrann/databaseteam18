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
        <div style="display: grid; grid-template-columns: 1fr 1fr; grid-gap: 10px;">
            <div>
                <!--First Name-->
                <br/><p>First Name: </p><asp:TextBox ID="first_name" runat="server"></asp:TextBox>
                <asp:Button ID="btnFirstName" runat="server" Text="Change First Name" OnClick="btnChangeFirstName" CssClass="btn btn-secondary" />
                <br/>
                <!--Middle Name-->
                <br/><p>Middle Name: </p><asp:TextBox ID="middle_name" runat="server"></asp:TextBox>
                <asp:Button ID="btnMiddleName" runat="server" Text="Change Middle Name" OnClick="btnChangeMiddleName" CssClass="btn btn-secondary" />
                <br/>
                <!--Last Name-->
                <br/><p>Last Name: </p><asp:TextBox ID="last_name" runat="server"></asp:TextBox>
                <asp:Button ID="btnLastName" runat="server" Text="Change Last Name" OnClick="btnChangeLastName" CssClass="btn btn-secondary" />
                <br/>
                <!--Employee ID-->
                <br/><p>Employee ID: </p><asp:TextBox ID="employeeID" runat="server"></asp:TextBox><br/>
                <br/><p>Date of Birth: </p><asp:TextBox ID="date_of_birth" runat="server"></asp:TextBox>
                <asp:Button ID="btnDOB" runat="server" Text="Change DOB" OnClick="btnChangeDOB" CssClass="btn btn-secondary" />
                <br/>
                <!--Gender-->
                <br/><p>Gender: </p><asp:TextBox ID="gender" runat="server"></asp:TextBox>
                <asp:Button ID="btnGender" runat="server" Text="Change Gender" OnClick="btnChangeGender" CssClass="btn btn-secondary" />
                <br/>
                <!--Email-->
                <br/><p>Email: </p><asp:TextBox ID="email_address" runat="server"></asp:TextBox><br/>
            </div>
            <div>
                <!--Phone Number-->
                <br/><p>Phone Number: </p><asp:TextBox ID="phone_number" runat="server"></asp:TextBox>
                <asp:Button ID="btnPhoneNumber" runat="server" Text="Change Phone Number" OnClick="btnChangePhoneNumber" CssClass="btn btn-secondary" />
                <br/>
                <!--SSN-->
                <br/><p>SSN (Last 4 #'s): </p> <asp:TextBox ID="SSN_num" runat="server"></asp:TextBox><br/>
                <!--Department Name-->
                <br/><p>Department Name: </p><asp:TextBox ID="departName" CssClass="full-width" runat="server"></asp:TextBox><br/>
            </div>
        </div>
        </div>
    </main>
</asp:Content>
