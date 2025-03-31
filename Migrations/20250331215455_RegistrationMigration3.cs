using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_WorkAndTravel.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "RegistrationForms");

            migrationBuilder.DropColumn(
                name: "EnglishLevel",
                table: "RegistrationForms");

            migrationBuilder.DropColumn(
                name: "WorkExperience",
                table: "RegistrationForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "RegistrationForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishLevel",
                table: "RegistrationForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkExperience",
                table: "RegistrationForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
