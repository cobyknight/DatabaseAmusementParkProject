using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAmusementParkProject.Migrations
{
    /// <inheritdoc />
    public partial class DML_AddDataToThemeParkAndLocationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""ThemeParks_Locations""(
	""Id"", ""LocationId"", ""ThemeParkId"")
	VALUES ('bbc0829e-131c-44f4-bd51-618cc786dfc2', 'f685d29e-d9ef-4d7c-8f18-97e59fe37caf', 'f7067fb4-71f7-4f8c-adca-131898e03bd8'),
	('8dd52a66-b9f3-4da1-a366-c879f1a67760', 'f685d29e-d9ef-4d7c-8f18-97e59fe37caf', '25e37d54-b861-4fbc-aa55-790556765c95'),
	('78addf31-911c-43c6-89e4-07aff2e12bf3', 'f110aa5c-9e26-45ce-aadb-877e55c5c150', 'f7067fb4-71f7-4f8c-adca-131898e03bd8'),
	('108664d0-9ed1-4c02-a7cc-956d3d10d55f', '8492049d-dbde-4bfe-9062-018bf7c42783', 'f7067fb4-71f7-4f8c-adca-131898e03bd8'),
	('df20cc2c-587d-4b0e-8b62-7b45fd2a787f', '4b33ebbe-a096-414e-b897-25220fdc0878', 'd7cdc002-9d68-4fdb-9187-61b44b7f7fad'),
	('2da178c1-fb6d-4023-b9ad-6a74b16578a6', '85db65a6-2f02-41bb-b43e-1419975fa005', '25e37d54-b861-4fbc-aa55-790556765c95');
INSERT INTO public.""Locations""(
	id, name)
	VALUES ('f685d29e-d9ef-4d7c-8f18-97e59fe37caf', 'Los Angeles'),
	('f110aa5c-9e26-45ce-aadb-877e55c5c150', 'Paris'),
	('8492049d-dbde-4bfe-9062-018bf7c42783', 'Tokyo'),
	('4b33ebbe-a096-414e-b897-25220fdc0878', 'Orlando'),
	('85db65a6-2f02-41bb-b43e-1419975fa005', 'Dallas');
INSERT INTO public.""ThemeParks""(
	""Id"", ""Name"")
	VALUES ('25e37d54-b861-4fbc-aa55-790556765c95', 'Six Flags'),
	('f7067fb4-71f7-4f8c-adca-131898e03bd8', 'DisneyLand'),
	('d7cdc002-9d68-4fdb-9187-61b44b7f7fad', 'Disney World');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
