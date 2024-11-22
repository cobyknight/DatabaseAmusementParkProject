using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAmusementParkProject.Migrations
{
    /// <inheritdoc />
    public partial class DML_FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeParkId",
                table: "ThemeParks_Review",
                newName: "ThemeParkLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeParkLocationId",
                table: "ThemeParks_Review",
                newName: "ThemeParkId");
        }
    }
}
