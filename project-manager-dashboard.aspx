<%@ Page Title="" Language="C#" MasterPageFile="~/project-manager.Master" AutoEventWireup="true" CodeBehind="project-manager-dashboard.aspx.cs" Inherits="databaseteam18.project_manager_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link href="Styles/manager-dashboard.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="project-manager-dashbaord">
        <div classname="containerNew">
           <!--Profile-->
            <div class="manager-profile">
                <div class="row justify-content-md-center">
                <div id="manager-profile" class="col col-lg-2">
                    <p>profile</p>
                </div>
                </div>
            </div><br/>

        <div class="containerNew2">
          <div class="row justify-content-between">
           <!--Manager Project-->

            <div class="project-manager col-md-6">
                <p>hui</p>
            </div>
              <br />
            <!--Calender-->
            <div class="calender col-md-6">
                <p>hu</p>
            </div>

          </div>
        </div>
    </main>
</asp:Content>
