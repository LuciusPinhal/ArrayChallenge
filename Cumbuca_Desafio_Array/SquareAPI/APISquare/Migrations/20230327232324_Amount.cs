using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISquare.Migrations
{
    /// <inheritdoc />
    public partial class Amount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Amounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Amounts");
        }
    }
}
