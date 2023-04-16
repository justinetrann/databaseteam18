<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects_Database.aspx.cs" Inherits="databaseteam18.Projects"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link rel="stylesheet" href="Styles/project.css"/>

    <main aria-labelledby="project_database">
        <p>My Current Projects </p>

        <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
             </div>
        <asp:GridView ID ="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height ="400px" AutoGenerateColumns="false" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating"  OnRowCancelingEdit = "GridView2_RowCancelingEdit" OnRowDeleting ="GridView2_RowDeleting">
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
             
            <asp:BoundField DataField="Project ID" HeaderText="Project ID" ReadOnly="true"/>

            
            <asp:TemplateField HeaderText="Project Name">
                <ItemTemplate>
                    <asp:Label ID="ProjectNameLabel" runat="server" Text='<%# Eval("Project Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="ProjectNameTextBox" runat="server" Text='<%# Bind("[Project Name]") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

           
              <asp:BoundField DataField="Start" HeaderText="Start" ReadOnly="true" />

                <asp:TemplateField HeaderText="Deadline">
                    <ItemTemplate>
                        <asp:Label ID="DeadlineLabel" runat="server" Text='<%# Eval("Deadline") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="DeadlineTextBox" runat="server" Text='<%# Bind("[Deadline]") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            
           
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="StatusDropDownList" runat="server">
                        <asp:ListItem Text="Resume" Value="ONGOING"></asp:ListItem>
                        <asp:ListItem Text="Pause" Value="PAUSED"></asp:ListItem>
                        <asp:ListItem Text="Complete" Value="COMPLETED"></asp:ListItem>
                    </asp:DropDownList> 
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Completion Date" HeaderText="Completion Date" ReadOnly="true"/> 

            <asp:TemplateField HeaderText="Est. Cost">
                    <ItemTemplate>
                        <asp:Label ID="EstCostLabel" runat="server" Text='<%# Eval("Est Cost") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EstCostTextBox" runat="server" Text='<%# Bind("[Est Cost]") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Est. Effort">
                    <ItemTemplate>
                        <asp:Label ID="EstEffortLabel" runat="server" Text='<%# Eval("Est Effort") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EstEffortTextBox" runat="server" Text='<%# Bind("[Est Effort]") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Tot. Cost">
                    <ItemTemplate>
                        <asp:Label ID="TotCostLabel" runat="server" Text='<%# Eval("Tot Cost") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TotCostTextBox" runat="server" Text='<%# Bind("[Tot Cost]") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Tot. Effort">
                    <ItemTemplate>
                        <asp:Label ID="TotEffortLabel" runat="server" Text='<%# Eval("Tot Effort") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TotEffortTextBox" runat="server" Text='<%# Bind("[Tot Effort]") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

           
            <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="true"/>


            
            <asp:BoundField DataField="Assign Status" HeaderText="Assign Status" ReadOnly="true"/>
                         


            <asp:CommandField ShowEditButton="true"/>

                 
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this record?');"
                            Text="Delete" CssClass="btn btn-outline-danger btn-sm" >
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
           
            
            </Columns>

        </asp:GridView>
    </main>
</asp:Content>