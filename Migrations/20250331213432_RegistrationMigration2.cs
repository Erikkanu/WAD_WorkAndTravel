using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_WorkAndTravel.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationFormID",
                table: "RegistrationForms",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "RegistrationForms",
                newName: "RegistrationFormID");
        }
    }
}
