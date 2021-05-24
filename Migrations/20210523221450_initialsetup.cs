using Microsoft.EntityFrameworkCore.Migrations;

namespace Rema1000.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Leverandør",
                columns: table => new
                {
                    LeverandørId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakperson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverandør", x => x.LeverandørId);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enhed = table.Column<float>(type: "real", nullable: false),
                    Mængde = table.Column<int>(type: "int", nullable: false),
                    Pris = table.Column<float>(type: "real", nullable: false),
                    KategoriId1 = table.Column<int>(type: "int", nullable: true),
                    Lager = table.Column<int>(type: "int", nullable: false),
                    LeverandørId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategori_KategoriId1",
                        column: x => x.KategoriId1,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produkt_Leverandør_LeverandørId1",
                        column: x => x.LeverandørId1,
                        principalTable: "Leverandør",
                        principalColumn: "LeverandørId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_KategoriId1",
                table: "Produkt",
                column: "KategoriId1");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_LeverandørId1",
                table: "Produkt",
                column: "LeverandørId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Leverandør");
        }
    }
}
