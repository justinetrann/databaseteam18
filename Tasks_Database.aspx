<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks_Database.aspx.cs" Inherits="databaseteam18.Tasks_Database" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Styles/project.css">
    <main aria-labelledby="task_database">
        <p>Current Tasks in Database</p>
        <asp:GridView ID ="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height ="400px" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"  OnRowCancelingEdit = "GridView1_RowCancelingEdit">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />


             <Columns>
             <!-- TASK ID COLUMN-->
            <asp:BoundField DataField="Task ID" HeaderText="Task ID" ReadOnly="true"/>

             <!-- TASK NAME COLUMN-->
            <asp:TemplateField HeaderText="Task Name">
                <ItemTemplate>
                    <asp:Label ID="TaskNameLabel" runat="server" Text='<%# Eval("Task Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TaskNameTextBox" runat="server" Text='<%# Bind("Task Name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <!-- TASK DESCRIPTION COLUMN-->
             <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Duration" HeaderText="Duration" ReadOnly="true" />
            
            <!-- TASK STATUS COLUMN-->
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

            <!-- DEPARTMENT EMPLOYEES COLUMN-->
            <asp:TemplateField HeaderText="Employee">
                <ItemTemplate>
                    <asp:Label ID="EmployeeLabel" runat="server" Text='<%# Eval("Employee") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EmployeeDropDownList" runat="server">
                    </asp:DropDownList> 
                </EditItemTemplate>
            </asp:TemplateField>


            <!-- TASK ASSIGNMENT DATE COLUMN-->
            <asp:BoundField DataField="Assignment Date" HeaderText="Assignment Date" ReadOnly="true"/>


            <!-- TASK CREATION DATE COLUMN-->
            <asp:BoundField DataField="Creation Date" HeaderText="Creation Date" ReadOnly="true"/>
            

            <!-- TASK DEADLINE COLUMN-->
            <asp:TemplateField HeaderText="Deadline">
                <ItemTemplate>
                    <asp:Label ID="DeadlineDateLabel" runat="server" Text='<%# Eval("Deadline") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="DeadlineTextBox" runat="server" Text='<%# Bind("Deadline") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>


            <!-- TASK PRIORITY COLLUMN-->
            <asp:TemplateField HeaderText="Task Priority">
                <ItemTemplate>
                    <asp:Label ID="TaskPriorityLabel" runat="server" Text='<%# Eval("Task Priority") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TaskPriorityTextBox" runat="server" Text='<%# Bind("Task Priority") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true" />
            </Columns>

        </asp:GridView>
    </main>
</asp:Content>
