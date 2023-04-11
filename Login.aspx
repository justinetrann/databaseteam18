<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/default_site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="databaseteam18.login"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link href="Styles/login.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="login">
        <!-- NEW SIGNIN-->
        <div class="containerNew">
            <div class="login-content">
                <div class="login-form">
                    <h2 class="form-title">Welcome Back</h2>
                    <form method="post" class="sign-form" id="sign-form">
                        <!-- Email input -->
                        <div class="form-group">
                            <label for="email">
                                <i class="bi bi-envelope-fill"></i>
                            </label>
                            <input type="email" name="email" id="login_email" placeholder="Your Email" runat ="server" required/>
                        </div>
                        
                        <!-- Password input -->
                        <div class="form-group">
                            <label for="pass">
                                <i class="bi bi-lock-fill"></i>
                            </label>
                            <input type="password" name="pass" id="login_password" placeholder="Password" runat ="server" required/>
                        </div>
                        
                        <!-- Submit button -->
                        <div class="form-group form-button">
                            <button id="loginButton" type="submit" class="btn btn-primary" runat="server">Sign In</button>
                        </div>
                        
                        <!-- Error message display -->
                        <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                            Passwords do not match!
                        </div>
                            <div id="warningMessage" class="alert alert-warning" runat ="server" style="display:none;">
                    
                        </div>
                        <div id="successMessage" class="alert alert-success" runat ="server" style="display:none;">
                    
                        </div>

                    </form>
                </div>
                <div class="login-image">
                    <!-- Sign Up button -->
                    <figure>
                        <img src="img/manage.jpg" alt="phone_img"/>
                    </figure>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
