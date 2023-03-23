﻿<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="databaseteam18.About"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/login_signup.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="login">
        <div class="container">
            <div class="login_image">
                <img src="img/login.png" alt="Phone image">
            </div>
            <div class="form_signup">
                <h3>Register</h3>
                <form>
                  <!-- Email input -->
                  <div class="form-outline mb-4">
                    <input type="email" id="users_email" class="form-control form-control-lg"/>
                    <label class="form-label">Email address</label>
                  </div>

                  <!-- Password input -->
                  <div class="form-outline mb-4">
                    <input type="password" id="user_password" class="form-control form-control-lg"/>
                    <label class="form-label">Password</label>
                  </div>

                  <!-- Password input -->
                  <div class="form-outline mb-4">
                    <input type="password" id="user_password_reenter" class="form-control form-control-lg"/>
                    <label class="form-label">Verify Password</label>
                  </div>

                  <!-- Submit button -->
                  <button type="submit" class="btn3">Sign Up</button>
                </form>
            </div>
        </div>
    </main>
</asp:Content>

