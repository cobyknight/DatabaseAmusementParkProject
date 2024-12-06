Database Amusement Park Project
This project is the backend for the Amusement Finder application. The frontend for this project can be found here. It is built using ASP.NET Core and Entity Framework Core with a PostgreSQL database.

Running the Project
Step 1: Install PostgreSQL
Install PostgreSQL 17 using the following link: PostgreSQL Download.

Step 2: Set Up the Database
Create a PostgreSQL database named park.
Open appsettings.Development.json and update the password to your personal PostgreSQL password.

Step 3: Run Database Migrations
In Visual Studio, open the Package Manager Console and run the following command to apply the database migrations:

Update-Database


This will create the necessary tables and populate them with initial data.

Step 4: Start the Backend Server
After the migration is completed, you can run the backend project. This will open up Swagger where you can test the endpoints directly using JSON inputs.

Step 5: Restore from Backup (Optional)
Alternatively, you can restore the database from a provided backup file:

Create the database park.
Right-click the database, select Restore, and choose the backup file.

Additional Information
This project uses ASP.NET Core for building the API and Entity Framework Core for database interactions.
The project structure follows best practices for a scalable and maintainable codebase.
For more information on how to use ASP.NET Core, refer to the official documentation.
