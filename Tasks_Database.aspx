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
            <asp:BoundField DataField="Task ID" HeaderText="Task ID" ReadOnly="true"/>
            <asp:BoundField DataField="Task Name" HeaderText="Task Name" ReadOnly="true" />
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="true" />
            <asp:BoundField DataField="Duration" HeaderText="Duration" ReadOnly="true" />
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
            <asp:BoundField DataField="Creation Date" HeaderText="Creation Date" ReadOnly="true" />
            <asp:CommandField ShowEditButton="true" />
            </Columns>

        </asp:GridView>
    </main>
</asp:Content>
