# DeskReg-Management

Internet Management System currently used by the college and the IT department to manage all wired internet connections.
DeskReg interfaces with a SQL database using C#'s Entity Framework libraries. Much of the application is powered by LINQ statements to pull in and populate the necessary user data.
The system currently manages over 5000 devices. The system connects with a Servershare to transport a text file with device information for those devices. From there, the servershare communicates with the router
to grant internet access.
