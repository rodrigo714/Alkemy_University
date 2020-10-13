using Microsoft.EntityFrameworkCore.Migrations;

namespace Expedientes_Goya.Data.Migrations
{
    public partial class Professorcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfessorID",
                table: "_TCourse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfessorID",
                table: "_TCourse");
        }
    }
}
