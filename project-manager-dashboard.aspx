<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="project-manager-dashboard.aspx.cs" Inherits="databaseteam18.project_manager_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link href="Styles/manager-dashboard.css" rel="stylesheet" type="text/css"/>
    <main aria-labelledby="project-manager-dashbaord">

        <!--Project Form Introduction-->
        <div class="title-page">
            <video class="fill-container" autoplay="" loop="" muted="">
            <source src="video/video1.mp4" type="video/mp4" />
                Your browser does not support the video tag.
            </video>
            <div class="video-text">
                <div id="manager-profile">
                    <div class="row">
                        <div class="col-md-3">
                            <h4 id="first_name" runat="server">First Name</h4>
                        </div>
                        <div class="col-md-3">
                            <h4 id="last_name" runat="server">Last Name</h4>
                        </div>
                    </div>
                    <h4 id="Department" runat="server">Department Name</h4>
                </div>
            </div>
        </div><br/>

        <div classname="containerNew">
           <!--Profile-->
            <div class="manager-profile">
                <div class="row">
                    <h5 class="text-center mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Find Employee Task In System</h5><br/>
                    <div class="d-flex justify-content-center">
                        <asp:TextBox ID="findEmployee" runat="server" placeholder="Search UID..."></asp:TextBox>
                        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="SubmitFormEmployee" CssClass="btn btn-primary btn-sm" />
                    </div>
                </div>
            </div><br/>
        </div>

         <div class="containerNew">
          <div class="row">
           <!--Manager Project-->

            <div class="project-manager col-md-6">

                <!--Project Ranked By Dates-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Projects In The System</h5>
                <asp:GridView ID ="GridViewManagerProject1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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

                </asp:GridView><br/><br/>

                 <!--Employees In Department-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Employees In Department</h5>
                <asp:GridView ID ="GridViewManagerEmployees1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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

                </asp:GridView><br/><br/>

                <!--Employees Tasks-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Employees And Their Tasks</h5>
                <asp:GridView ID ="GridViewManagerEmployees" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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
              <br/>
            <!--Tasks-->
            <div class="calender col-md-6">

                 <!--Project Completed Tasks Only in Departments-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Completed Tasks In The System</h5>
                <asp:GridView ID ="GridViewManagerTaskC" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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
                </asp:GridView><br/><br/>

                 <!--Project Started Tasks Only in Departments-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Started Tasks In The System</h5>
                <asp:GridView ID ="GridViewManagerTaskS" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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
                </asp:GridView><br/><br/>

                <!--Project Assigned Tasks Only in Departments-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Assigned Tasks In The System</h5>
                <asp:GridView ID ="GridViewManagerTaskA" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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
                </asp:GridView><br/><br/>

                <!--Project Paused Tasks Only in Departments-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Paused Tasks In The System</h5>
                <asp:GridView ID ="GridViewManagerTaskP" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="483px" HorizontalAlign="Center">
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
                </asp:GridView><br/><br/>

            </div>
        </div>
    </div>
    </main>
</asp:Content>
