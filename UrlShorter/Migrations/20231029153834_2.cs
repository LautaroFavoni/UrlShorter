using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShorter.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contador",
                table: "URLs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "URLs",
                keyColumn: "Id",
                keyValue: 1,
                column: "contador",
                value: 0);

            migrationBuilder.UpdateData(
                table: "URLs",
                keyColumn: "Id",
                keyValue: 2,
                column: "contador",
                value: 1);

            migrationBuilder.UpdateData(
                table: "URLs",
                keyColumn: "Id",
                keyValue: 3,
                column: "contador",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contador",
                table: "URLs");
        }
    }
}
