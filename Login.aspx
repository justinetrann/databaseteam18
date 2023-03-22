<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="databaseteam18.About"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/login.css" rel="stylesheet" type="text/css"/>
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
                    <input type="email" id="users_email" class="form-control form-control-lg"/>
                    <label class="form-label" for="form1Example13">Email address</label>
                  </div>

                  <!-- Password input -->
                  <div class="form-outline mb-4">
                    <input type="password" id="user_password" class="form-control form-control-lg"/>
                    <label class="form-label" for="form1Example23">Password</label>
                  </div>

                  <!-- Submit button -->
                  <button type="submit" class="btn3">Login</button>

                </form>
            </div>
        </div>
    </main>
</asp:Content>
