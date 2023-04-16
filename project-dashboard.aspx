<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="project-dashboard.aspx.cs" Inherits="databaseteam18.project_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link href="Styles/project-dashboardd.css" rel="stylesheet" type="text/css"/>
        <main aria-labelledby="project-dashboard">
           <!--Project Dashboard Introduction-->
            <div class="title-page">
                <video class="fill-container" autoplay="" loop="" muted="">
                <source src="video/phone.mp4" type="video/mp4" />
                Your browser does not support the video tag.
                </video>
                <div class="video-text">
                <h4 class="centered-heading">Search Projects.</h4>
                </div>
            </div><br/>

            <div class="containerTable" style="font-weight: bold;">
                <!--See All Departments-->
                <!--That are not deleted-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Projects In A Department</h5>
                <asp:GridView ID="GridViewDepartment" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
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
            </div><br/>

            <!--Find Department Projects in System-->
            <div class="search-bar">
                <div class="container">
                  <div class="row">
                    <!--Search-->
                    <div class="col-md-6" style="font-weight: bold;">
                        <h5 class="text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Search Department Projects</h5>
                        <div class="findProjDepartment">
                            <asp:TextBox ID="findProjectsDepartment" runat="server" placeholder="Department Project..."></asp:TextBox>
                            <asp:Button ID="FindProjectsDepButton" runat="server" Text="Search" OnClick="FindDepProjects" CssClass="btn btn-primary ml-2" />
                        </div>
                    </div>
                    <div class="col-md-6" style="font-weight: bold;">
                        <!--Remove-->
                        <h5 class="text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Remove Department Project</h5>
                        <div class="findProjectsDepartment">
                            <asp:TextBox ID="removeProjects" runat="server" placeholder="Project ID..."></asp:TextBox>
                            <asp:Button ID="RemoveDepartmentProject" runat="server" Text="Remove" OnClick="RemoveDepProject" CssClass="btn btn-danger ml-2" />
                        </div>

                        <!--Restore-->
                        <h5 class="text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Restore Department Project</h5>
                        <div class="findProjectsDepartment">
                            <asp:TextBox ID="restoreProjects" runat="server" placeholder="Project ID..."></asp:TextBox>
                            <asp:Button ID="RestoreDepartmentProject" runat="server" Text="Recover" OnClick="RestoreDepProject" CssClass="btn btn-success ml-2" />
                        </div>
                    </div>
                  </div>
                </div>
            </div><br/>

            <div class="containerTable" style="font-weight: bold;">
                <!--All Projects in System-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Projects In A Department</h5>
                <asp:GridView ID="GridViewDepartmentProject" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
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
                </asp:GridView><br/>

                 <!--That are deleted-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Deleted Projects In A Department</h5>
                <asp:GridView ID="GridViewDepartmentDeletedProject" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
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
                </asp:GridView><br/><br/><div style="border-top: 1px solid black;"></div><br/><br/>


                <!--All Projects in System-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Current Projects In The System</h5>
                <asp:GridView ID="GridViewManagerProject" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
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
                </asp:GridView><br/>

                 <!--That are deleted-->
                <h5 class="text-center text-muted mb-3 h5" style="font-weight: bold; font-size: 15px; font-family:Poppins;">Deleted Projects In The System</h5>
                <asp:GridView ID="GridViewDeletedProject" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
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

        </main>
</asp:Content>
