﻿<%@ Page Title="" Language="C#" MasterPageFile="~/project-manager.Master" AutoEventWireup="true" CodeBehind="project-manager-dashboard.aspx.cs" Inherits="databaseteam18.project_manager_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link href="Styles/manager-dashboard.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="project-manager-dashbaord">
        <div classname="containerNew">
           <!--Profile-->
            <div class="manager-profile">
                <div class="row">
                    <div id="manager-profile" class="col col-lg-2">
                        <img src="img/profile.png" alt="profile-picture" style="width:150px;height:130px; float:left; margin-right: 10px;"/>
                        <div class="inline-div" style="width: calc(100% - 160px);">
                            <h4 id="first_name">First Name</h4>
                            <h4 id="last_name">Last Name</h4>
                        </div>
                    </div>
                </div>
            </div><br/>
        </div>

        <div class="containerNew2">
          <div class="row justify-content-between">
           <!--Manager Project: Project Ranked By Dates-->

            <div class="project-manager col-md-6">


                <h5 class="text-center text-muted mb-3 h5">Current Projects In The System</h5>
                <asp:GridView ID ="GridViewAdminProject1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                </asp:GridView>


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
