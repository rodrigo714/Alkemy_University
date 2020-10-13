using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expedientes_Goya.Data.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_TInscription",
                columns: table => new
                {
                    InscriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CareerID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TInscription", x => x.InscriptionID);
                    table.ForeignKey(
                        name: "FK__TInscription__TCourse_CourseID",
                        column: x => x.CourseID,
                        principalTable: "_TCourse",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX__TInscription_CourseID",
                table: "_TInscription",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_TInscription");
        }
    }
}
