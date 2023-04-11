
<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/default_site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="databaseteam18.signup"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link href="Styles/signup.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="login">
         <!-- NEW SIGNUP-->
        <div class="containerNew">
            <div class="register-content">
                <div class="register-form">
                    <h2 class="form-title">Sign Up</h2>
                    <form method="post" class="register-form" id="register-form">
                        <!-- First Name input -->
                        <div class="form-group">
                            <label for="name" class="icon-lable">
                                <i class="bi bi-person-fill"></i>
                            </label>
                            <input type="text" name="first-name" id="first_name" runat ="server" placeholder="Your First Name" required/>
                        </div>
                        <!-- Last Name input -->
                        <div class="form-group">
                            <label for="name" class="icon-lable">
                                <i class="bi bi-person"></i>
                            </label>
                            <input type="text" name="first-name" id="last_name" runat ="server" placeholder="Your Last Name" required/>
                        </div>
                        <!-- SSN input -->
                        <div class="form-group">
                            <label for="name" class="icon-lable">
                                <i class="bi bi-shield-fill"></i>
                            </label>
                            <input type="text" name="ssn" id="ssn" runat ="server" placeholder="Social Security #" required/>
                        </div>
                        <!-- Phone Number input -->
                        <div class="form-group">
                            <label for="name" class="icon-lable">
                                <i class="bi bi-telephone-fill"></i>
                            </label>
                            <input type="text" name="phone-number" id="phone_number" runat ="server" placeholder="Phone Number" required/>
                        </div>
                        <!-- Email input -->
                        <div class="form-group">
                            <label for="email" class="icon-lable">
                                <i class="bi bi-envelope-fill"></i>
                            </label>
                            <input type="email" name="email" id="users_email" runat ="server" placeholder="Your Email" required/>
                        </div>
                        <!-- Password input -->
                        <div class="form-group">
                            <label for="pass" class="icon-lable">
                                <i class="bi bi-lock-fill"></i>
                            </label>
                            <input type="password" name="pass" id="user_password" runat ="server" placeholder="Password" required/>
                        </div>
                        <div class="form-group">
                            <label for="re_pass" class="icon-lable">
                                <i class="bi bi-lock"></i>
                            </label>
                            <input type="password" name="re_pass" id="confirm_password" runat ="server" placeholder="Repeat Your Password" required/>
                        </div>
                        <div class="form-group">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck1"/>
                            <label class="form-check-label" for="defaultCheck1">
                                I agree all statement in 
                                <a herf="#" class="label-agree-term">Term of service</a>
                            </label>
                        </div>

                        <!-- Submit button -->
                        <button id="submitButton" type="submit" class="btn btn-primary" runat="server">Sign Up</button>

                        <!-- Error message display -->
                        <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                            Passwords do not match!
                        </div>
                    </form>
                </div>
                <div class="register-image">
                    <figure>
                        <img src="img/manage2.jpg" alt="phone_img"/>
                    </figure>
                </div>
            </div>
        </div>
    </main>
</asp:Content>


