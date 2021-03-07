using Microsoft.EntityFrameworkCore.Migrations;

namespace Serwer.Migrations
{
    public partial class initialcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projekt",
                columns: table => new
                {
                    ProjektID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    numer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt", x => x.ProjektID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjektID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Projekt_ProjektID",
                        column: x => x.ProjektID,
                        principalTable: "Projekt",
                        principalColumn: "ProjektID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonProjekty",
                columns: table => new
                {
                    PersonProjektyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<long>(type: "bigint", nullable: false),
                    ProjektID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProjekty", x => x.PersonProjektyID);
                    table.ForeignKey(
                        name: "FK_PersonProjekty_Projekt_ProjektID",
                        column: x => x.ProjektID,
                        principalTable: "Projekt",
                        principalColumn: "ProjektID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjektDetails",
                columns: table => new
                {
                    ProjektDetailsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjektID = table.Column<long>(type: "bigint", nullable: false),
                    DataDodania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjektDetails", x => x.ProjektDetailsID);
                    table.ForeignKey(
                        name: "FK_ProjektDetails_Projekt_ProjektID",
                        column: x => x.ProjektID,
                        principalTable: "Projekt",
                        principalColumn: "ProjektID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ProjektID",
                table: "Person",
                column: "ProjektID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjekty_ProjektID",
                table: "PersonProjekty",
                column: "ProjektID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjektDetails_ProjektID",
                table: "ProjektDetails",
                column: "ProjektID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PersonProjekty");

            migrationBuilder.DropTable(
                name: "ProjektDetails");

            migrationBuilder.DropTable(
                name: "Projekt");
        }
    }
}
