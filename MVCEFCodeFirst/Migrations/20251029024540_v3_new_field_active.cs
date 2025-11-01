using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class v3_new_field_active : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Courses");
        }
    }
}
