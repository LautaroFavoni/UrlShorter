using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShorter.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URLShort = table.Column<string>(type: "TEXT", nullable: true),
                    URLLong = table.Column<string>(type: "TEXT", nullable: true),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLs_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trabajo" },
                    { 2, "Diversion" }
                });

            migrationBuilder.InsertData(
                table: "URLs",
                columns: new[] { "Id", "IdCategoria", "URLLong", "URLShort" },
                values: new object[,]
                {
                    { 1, 1, "Lasoadsat", "jef" },
                    { 2, 2, "Lasotsdasdsa", "Karenaaa" },
                    { 3, 2, "Ldsadsadasdasot", "asddsadsa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLs_IdCategoria",
                table: "URLs",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLs");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
