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
