*************************
How To Run Project
*************************
1. Install PostgreSQL 17 using this link https://www.postgresql.org/download/
2. Create PostgreSQL database named "park"
3. For API set up we used Visual Studio, so this tutorial will be specific to that
4. Open appsettings.Development.json
5. Update password to personal postgresql password
6. Go into Package Manager Console and use the command "Update-Database"
This will run the database migrations to create the tables, and fill them with data
7. After the migration is completed you can run the backend for the project
8. This will open up swagger where you can test the endpoints directly using json inputs

Alternitiveley I will provide the Database Backup file. You can create the database "park" Then right click the database
then his restore and select the backup.
