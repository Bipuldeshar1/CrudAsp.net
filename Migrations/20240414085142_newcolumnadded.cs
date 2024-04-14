using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAsp.net.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "products");
        }
    }
}
