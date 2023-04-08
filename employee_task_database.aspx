﻿<%@ Page Title="Project Management System" Language="C#" MasterPageFile="~/employee_site.Master" AutoEventWireup="true" CodeBehind="employee_task_database.aspx.cs" Inherits="databaseteam18.employee_task_database" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Styles/project.css">
    <main aria-labelledby="task_database">
        <div className="container">
            <form>
              <div class="form-group row">
                <label for="projectName" class="col-sm-2 col-form-label">Project Name</label>
                <div class="col-sm-3">
                  <%--<select name="projectName" id="project_name">
                      <option value=NULL>Select Project</option>
                      <option value=NULL selected>N/A - None</option>
                  </select>--%>
                <asp:DropDownList ID="project_name" runat="server"> </asp:DropDownList>
                </div>
              </div>

                <button type="submit" id ="submitButton" runat ="server" class="btn3">View Tasks</button>
            </form>


            <div id="errorMessage" class="alert alert-danger" runat ="server" style="display:none;">
                    
             </div>
            <div id="successMessage" class="alert alert-success" runat ="server" style="display:none;">
                    
             </div>
        </div>
        <p>Current Tasks for Selected Project</p>
        <asp:GridView ID ="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height ="400px">
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
           <%-- <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />--%>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="StatusDropDownList" runat="server">
                        <asp:ListItem Text="Start" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Pause" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Complete" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
        </Columns>

        </asp:GridView>
    </main>
</asp:Content>