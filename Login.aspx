<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="databaseteam18.login"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/login_signup.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="login">
        <div class="container">
            <div class="login_image">
                <img src="img/login.png" alt="Phone image">
            </div>
            <div class="form_login">
                <h3>Welcome Back</h3>
                <form>
                  <!-- Email input -->
                  <div class="form-outline mb-4">
                    <input type="email" id="login_email" class="form-control form-control-lg" runat ="server" required/>
                    <label class="form-label">Email address</label>
                  </div>

                  <!-- Password input -->
                  <div class="form-outline mb-4">
                    <input type="password" id="login_password" class="form-control form-control-lg" runat ="server" required/>
                    <label class="form-label">Password</label>
                  </div>

                  <!-- Submit button -->
                    <button id="loginButton" type="submit" class="btn3" runat="server">Login</button>


                    <!-- Sign Up button -->
                    <button id="signupButton" type="submit" class="btn3" runat="server">Sign Up</button>

                     <!-- Error message display -->
                <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    Passwords do not match!
                </div>
                </form>
            </div>
        </div>
    </main>
</asp:Content>
