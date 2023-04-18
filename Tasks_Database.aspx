<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks_Database.aspx.cs" Inherits="databaseteam18.Tasks_Database" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Styles/task-database.css">
    <main aria-labelledby="task_database">
        <div classname="container">
            <!--Tasks Database Introduction-->
            <div class="title-page">
                <video class="fill-container" autoplay="" loop="" muted="">
                    <source src="video/video3.mp4" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <div class="video-text">
                    <h1>Manage Employees Task.</h1>
                </div>
            </div>
            <br />
        </div>

        <div class="containerNew">
            <div id="errorMessage" class="alert alert-danger" runat="server" style="display: none;" />
            <div id="Div1" class="alert alert-danger" runat="server" style="display: none;"></div>

            <div id="successMessage" class="alert alert-success" runat="server" style="display: none;"></div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="Task ID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height="200px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
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

                    <asp:BoundField DataField="Task ID" HeaderText="Task ID" ReadOnly="true" />


                    <asp:TemplateField HeaderText="Task Name">
                        <ItemTemplate>
                            <asp:Label ID="TaskNameLabel" runat="server" Text='<%# Eval("Task Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TaskNameTextBox" runat="server" Text='<%# Bind("[Task Name]") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Duration" HeaderText="Duration" ReadOnly="true" />


                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="StatusDropDownList" runat="server">
                                <asp:ListItem Text="Assigned" Value="assigned"></asp:ListItem>
                                <asp:ListItem Text="Start" Value="Started"></asp:ListItem>
                                <asp:ListItem Text="Pause" Value="Paused"></asp:ListItem>
                                <asp:ListItem Text="Complete" Value="Completed"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Task_Pred_ID" HeaderText="Pred. ID" ReadOnly="true" />


                    <asp:TemplateField HeaderText="Employee">
                        <ItemTemplate>
                            <asp:Label ID="EmployeeLabel" runat="server" Text='<%# Eval("Employee") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="EmployeeDropDownList" runat="server" DataTextField="employee_full_name" DataValueField="employee_id">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>



                    <asp:BoundField DataField="Assignment Date" HeaderText="Assignment Date" ReadOnly="true" />







                    <asp:TemplateField HeaderText="Deadline">
                        <ItemTemplate>
                            <asp:Label ID="DeadlineDateLabel" runat="server" Text='<%# Eval("Deadline","{0:MM/dd/yyyy hh:mm:ss tt}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="DeadlineTextBox" runat="server" Text='<%# Bind("Deadline","{0:MM/dd/yyyy hh:mm:ss tt}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CompletionStatus" HeaderText="Completion" ReadOnly="true" />
                    <asp:BoundField DataField="CompletionDate" HeaderText="Completed On" ReadOnly="true"  DataFormatString="{0:MM/dd/yyyy}"/>


                    <asp:TemplateField HeaderText="Task Priority">
                        <ItemTemplate>
                            <asp:Label ID="TaskPriorityLabel" runat="server" Text='<%# Eval("Task Priority") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="TaskPriorityDropDownList" runat="server">
                                <asp:ListItem Text="Low" Value="low"></asp:ListItem>
                                <asp:ListItem Text="Medium" Value="medium"></asp:ListItem>
                                <asp:ListItem Text="High" Value="high"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>




                    <asp:CommandField ShowEditButton="true" />


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                Text="Delete" CssClass="btn btn-outline-danger btn-sm">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>

    </main>
</asp:Content>
