**Project Management System**

Using ASP.NET and Microsoft SQL, Team 18 has developed a project management system that allows its users to manage projects across departments, track of team members' hours on projects, manage tasks within projects, monitor project status, and generate reports on departmental efforts, costs, and employee productivity. By assigning our users to one of three roles - admin, manager, or employee - we can ensure the success of managing the company.

**Installation**

**Prequisites:**

1. .NET SDK
   a. Visual Studio Installer (2022)
      i. Modify: ASP.NET and Web Development, .NET desktop development, Data storage and processing
2. Microsoft SQL Server
   a. Microsoft Azure SQL Database

**Installation Steps**

1. Clone the repository

    ```
    git clone https://github.com/justinetrann/databaseteam18.git
    ```
	
2. Use Visual Studio 2022

    a. Install the following modifications:
    
        - ASP.NET and Web Development
        
        - .NET desktop development
        
        - Data storage and processing 
		
3. Set up the database by executing the SQL script in the Database folder

    a. Database Connection:
    
        - Open Microsoft SQL Server Management Studio
        
        - Connect to your SQL Server instance by entering the appropriate server name, authentication method, and credentials. (Username and Password given within email)
    
    b. Locate databaseteam10.sln within the databaseteam18 folder
    
        - Open in Visual Studio 2022

**Usage**

There are two ways for deployment:

1. Open your web browser and navigate to https://projectmanagementsystem123.azurewebsites.net/
2. Use the application
	a. In Visual Studio 2022: Press 'Green Play Icon', Start Without Debugging (Ctrl+F5)
_Web Site connected to the Database should deploy_ 


**Website Pages**
Our website contains the following pages:
**admin_home_page**{.aspx,.cs,.aspx.designer.cs} - The Admin Role Assignment Page  <br>
>**Input:** Email and Selected Role  <br>
>**Output:** User account connected to email switches to desired role  <br><br>
**Contact**{.aspx,.cs,.aspx.designer.cs} - An unused page for displaying contact information for the project <br><br>
**Default**{.aspx,.cs,.aspx.designer.cs} - Redirects to the Login page.<br><br>
**department_assign**{.aspx,.cs,.aspx.designer.cs} - The Admin Department Assignment Page<br>
    **Input**: Email and Selected Department<br>
    **Output**: User account connected to email is assigned to selected department<br><br>
**departmentEmployeesReport**{.aspx,.cs,.aspx.designer.cs} - Department Employees Report - Department Performance Report<br>
    **Input**: A start date and an end date<br>
    **Output**: A report over how productive employees in the department were during the selected period of time. Lists number of tasks each employee completed and their percentage on time and late.<br><br>
**departmentReport**{.aspx,.cs,.aspx.designer.cs} - An outdated version of the department cost report<br><br>
**employee-home-site**{.aspx,.cs,.aspx.designer.cs} - Homepage for the Employee Role, displays a video (databaseteam18/video/homepage.mpg4)<br><br>
**Employee_Profile_page**{.aspx,.cs,.aspx.designer.cs} - Displays Employee User Info and Allows the to be Modified<br>
    **Input**: Text (for Names, Email, and Phone Number), Selection (for Gender), or Date (for Date of Birth)<br>
    **Output**: Users info is updated to match newly input information<br>
    **employee_task_database**{.aspx,.cs,.aspx.designer.cs} - Allows employees to manage their tasks<br>
        **Input**: Selected project, selected task status<br>
        **Output**: Selected task's status updates<br><br>
    **employeeReport**{.aspx,.cs,.aspx.designer.cs} - Employee Tasks Report - Employee Productivity Report<br>
        **Input**: Selected employee, start date, and end date<br>
        **Output**: Report over the individual employees ability to complete tasks, including the total amount of tasks completed, the amount completed late, total hours worked, and a list of all tasks the user completed during the time period.<br><br>
   **homepage**{.aspx,.cs,.aspx.designer.cs} - Displays a Video (databaseteam18/video/homepage.mpg4), it's intended to give a brief explanation about the project management system.  <br><br>
    **Login**{.aspx,.cs,.aspx.designer.cs} -Used to authenticate a user's identity and provide access to three different roles: Admin, Manager, Employee<br>
        **Input**: Email and Password<br>
        **Output**: Access to different restricted areas or functionality within a website or application.<br><br>
    **project-dashboard**{.aspx,.cs,.aspx.designer.cs} - Used to search all projects in database by their department, allowing managers to remove them or restore them if removed.<br>
        **Input**: Department Name (to search), Project ID (to remove or restore)<br>
        **Output**: For search, the projects currently being managed by that department are listed. Remove, project is no longer actively listed to users. Restore, project is actively listed to users again.<br><br>
    **project-manager-dashboard**{.aspx,.cs,.aspx.designer.cs} - Allows the user to search the tasks assigned to a user by their employee ID. Additionally allows the user to current employees in the department, current projects in the department, and current tasks in the department.<br>
        **Input**: Employee ID<br>
        **Output**: List of current tasks assigned to employee<br><br>
    **project-manager-site**{.aspx,.cs,.aspx.designer.cs} - Landing/home page for Project Manager Role.<br><br>
    **Project_Form**{.aspx,.cs,.aspx.designer.cs} - Form to input new projects into the database.<br>
        **Input**: Project Name, Start Date, End Date, Estimated Cost, and Estimated Effort.<br>
        **Output**: Project is added to the database and assigned to department.<br><br>
    **projectCostReport**{.aspx,.cs,.aspx.designer.cs} -By selecting a time period, the department estimated cost will be contrasted with the actual cost and display the difference between the two. Additionally, each task is listed alongside its cost, the employee that completed it, and its start and completion dates.<br>
        **Input**: Start Date and End Date<br>
        **Output**: Report over the costs incurred in the department over the period of time.<br><br>
    **Project_database**{.aspx,.cs,.aspx.designer.cs} - Lists projects in entire database. Allows for modification of projects or their deletion.<br>
        **Input**: Project Name Deadline, Status, Est. Cost, Est. Effort, Tot. Cost, Tot.Effort<br>
       **Output**: Modifications occur to selected project.<br><br>
    **Signup**{.aspx,.cs,.aspx.designer.cs} - Allows users to create a new account.<br>
        **Input**: First Name, Last Name, SSN, Phone Number, Email, Password, Verify Password<br>
       **Output**: Access to Employee Webpage<br><br>
    **Task_Form**{.aspx,.cs,.aspx.designer.cs} - Allows the user to input new tasks into the database.<br>
        **Input**: Task Name, Task Description, Estimated Duration, selected Employee, Task Predecessor (optional), and Task Deadline<br>
        **Output**: Selected employee is assigned task in their 'My Tasks' page allowing them to work on it (if predecessor is completed).<br><br>
    **Task_Database**{.aspx,.cs,.aspx.designer.cs} - Lists all tasks in department, allowing for their modification or deletion.<br>
        **Input**: Task name, task description, status, the assigned employee, deadline, cost, and priority<br>
        **Output**: Modifications occur to selected task.<br><br>
    **test**{.aspx,.cs,.aspx.designer.cs} - Unused testing page.<br>

**Contact**

University of Houston Texas College of Natural Sciences and Mathematics - Department of Computer Science
2023SP-16097-COSC3380: Design of File and Database System

If you have any questions or suggestions, please contact us at:
- Demba Diallo: dmdiallo@cougarnet.uh.edu
- James Graham: jdgraha2@cougarnet.uh.edu
- Ahmed Mohammed: ammoha21@cougarnet.uh.edu
- Justine Tran: jytran2@cougarnet.uh.edu

**Acknowledgments**

Professor Uma Ramamurthy
