using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class createDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "Dersid",
                table: "tblOgrenciler");

            migrationBuilder.RenameTable(
                name: "Dersler",
                newName: "tblDersler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDersler",
                table: "tblDersler",
                column: "Dersid");

            migrationBuilder.CreateTable(
                name: "tblOgrenciDersler",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciDersler", x => new { x.OgrenciId, x.DersId });
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblDersler_DersId",
                        column: x => x.DersId,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblOgrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrenciDersler_DersId",
                table: "tblOgrenciDersler",
                column: "DersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDersler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDersler",
                table: "tblDersler");

            migrationBuilder.RenameTable(
                name: "tblDersler",
                newName: "Dersler");

            migrationBuilder.AddColumn<int>(
                name: "Dersid",
                table: "tblOgrenciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler",
                column: "Dersid");
        }
    }
}
