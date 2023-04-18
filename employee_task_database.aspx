<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/employee_site.Master" AutoEventWireup="true" CodeBehind="employee_task_database.aspx.cs" Inherits="databaseteam18.employee_task_database" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Styles/employee-task-database.css">
    <main aria-labelledby="task_database">
        <div classname="container">
           <!--Tasks Database Introduction-->
            <div class="title-page">
                <video class="fill-container" autoplay="" loop="" muted="">
                <source src="video/lightbulb.mp4" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <div class="video-text">
                <h1>Manage Your Task.</h1>
                </div>
            </div><br/><br/>

        <!--New Form-->
        <div class="containerNew">
            <form>
            <div class="row">
                <div class="col-md-6" style="margin-left: 100px;">
                 <label for="projectName" class="col-form-label" style="font-weight:bold;">Project Name</label>
                <asp:DropDownList ID="employee_projects" runat="server"></asp:DropDownList>
                </div>
            </div>
            <button type="submit" id="submitButton" UseSubmitBehavior="true" runat="server" class="btn btn-primary" style="font-weight:300;margin-left: 100px; margin-top:20px;">View Tasks</button>
            </form>
            <div id="errorMessage" class="alert alert-danger" runat="server" style="display:none;"></div>
            <div id="successMessage" class="alert alert-success" runat="server" style="display:none;"></div>

        </div>
        <br/><br/>

                    
        

        <div class="containerTable">
            <p style="font-size: 1.5rem; text-align:center;">Current Tasks for Selected Project</p>
            <asp:GridView ID ="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height ="150px"   AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"  OnRowCancelingEdit = "GridView1_RowCancelingEdit">
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


               <Columns>
                <asp:BoundField DataField="Task ID" HeaderText="Task ID" ReadOnly="true"/>
                <asp:BoundField DataField="Task Name" HeaderText="Task Name" ReadOnly="true" />
                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="true" />
           
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="StatusDropDownList" runat="server">
                            <asp:ListItem Text="Start" Value="Started"></asp:ListItem>
                            <asp:ListItem Text="Pause" Value="Paused"></asp:ListItem>
                            <asp:ListItem Text="Complete" Value="Completed"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Assignment Date" HeaderText="Assignment Date" ReadOnly="true" />

                <asp:BoundField DataField="Deadline" HeaderText="Deadline" ReadOnly="true" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}"/>
                <asp:BoundField DataField="CompletionStatus" HeaderText="Completion" ReadOnly="true"  />
                <asp:BoundField DataField="Task Priority" HeaderText="Task Priority" ReadOnly="true" />

                <asp:CommandField ShowEditButton="true" />
            </Columns>

            </asp:GridView>
        </div>
    </div>
    </main>
</asp:Content>

