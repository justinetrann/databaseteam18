﻿<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects_Database.aspx.cs" Inherits="databaseteam18.About"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="Styles/project.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="project_database">
        <p>Current Projects in Database</p>
        <asp:GridView ID ="GridView1" AutoGenerateColumns="true" runat="server" Width="100%"  ViewStateMode="Enabled">

        </asp:GridView>
    </main>
</asp:Content>