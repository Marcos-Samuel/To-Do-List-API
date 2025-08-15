using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaToTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tasks");
        }
    }
}
