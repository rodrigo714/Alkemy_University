using Microsoft.EntityFrameworkCore.Migrations;

namespace Expedientes_Goya.Data.Migrations
{
    public partial class secondmigrationbis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_TCareer",
                columns: table => new
                {
                    CareerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TCareer", x => x.CareerID);
                });

            migrationBuilder.CreateTable(
                name: "_TCourse",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Hours = table.Column<byte>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CareerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TCourse", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK__TCourse__TCareer_CareerID",
                        column: x => x.CareerID,
                        principalTable: "_TCareer",
                        principalColumn: "CareerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__TCourse_CareerID",
                table: "_TCourse",
                column: "CareerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_TCourse");

            migrationBuilder.DropTable(
                name: "_TCareer");
        }
    }
}
