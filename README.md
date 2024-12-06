# Database Amusement Park Project

This project is the backend for the Amusement Finder application. The frontend for this project can be found [here](https://github.com/4rcher0116/amusement-finder). It is built using ASP.NET Core and Entity Framework Core with a PostgreSQL database.

## Running the Project

### Step 1: Install PostgreSQL

Install PostgreSQL 17 using the following link: [PostgreSQL Download](https://www.postgresql.org/download/).

### Step 2: Set Up the Database

1. Create a PostgreSQL database named `park`.
2. Open `appsettings.Development.json` and update the password to your personal PostgreSQL password.

### Step 3: Run Database Migrations

In Visual Studio, open the Package Manager Console and run the following command to apply the database migrations:

```sh
Update-Database
```

This will create the necessary tables and populate them with initial data.

### Step 4: Start the Backend Server

After the migration is completed, you can run the backend project. This will open up Swagger where you can test the endpoints directly using JSON inputs.

### Step 5: Restore from Backup (Optional)

Alternatively, you can restore the database from a provided backup file:

1. Create the database `park`.
2. Right-click the database, select `Restore`, and choose the backup file.

## Additional Information

- This project uses ASP.NET Core for building the API and Entity Framework Core for database interactions.
- The project structure follows best practices for a scalable and maintainable codebase.
- For more information on how to use ASP.NET Core, refer to the [official documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0).
