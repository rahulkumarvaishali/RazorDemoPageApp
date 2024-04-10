using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorDemoPageApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeMAthLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Employees");
        }
    }
}
