
<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/default_site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="databaseteam18.signup"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link href="Styles/login_signup.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="login">
        <div class="container">
            <div class="login_image">
                <img src="img/login.png" alt="Phone image">
            </div>
            <div class="form_signup">
                <h3>Register</h3>
                <form>

                <!-- first name input -->
                    <div class="form-outline mb-4">
                    <input type="text" id="first_name" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">First name</label>
                  </div>

                  <!-- last name input -->
                    <div class="form-outline mb-4">
                    <input type="text" id="last_name" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">Last name</label>
                  </div>

                <!-- ssn input -->
                    <div class="form-outline mb-4">
                    <input type="text" id="ssn" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">Social Security #</label>
                  </div>


                <!-- Phone number input -->
                    <div class="form-outline mb-4">
                    <input type="text" id="phone_number" runat ="server" class="form-control form-control-lg" />
                    <label class="form-label">Phone Number</label>
                  </div>


                  <!-- Email input -->
                  <div class="form-outline mb-4">
                    <input type="email" id="users_email" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">Email address</label>
                  </div>

                  <!-- Password input -->
                  <div class="form-outline mb-4">
                    <input type="password" id="user_password" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">Password</label>
                  </div>

                 <div class="form-outline mb-4">
                    <input type="password" id="confirm_password" runat ="server" class="form-control form-control-lg" required/>
                    <label class="form-label">Confirm Password</label>
                 </div>

               



                  <!-- Submit button -->
                    <button id="submitButton" type="submit" class="btn3" runat="server">Sign Up</button>


                    
                    



                  <!-- Error message display -->
                <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    Passwords do not match!
                </div>
                </form>
            </div>
        </div>
    </main>
</asp:Content>


