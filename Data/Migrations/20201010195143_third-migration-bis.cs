using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_University.Data.Migrations
{
    public partial class thirdmigrationbis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerID",
                table: "_TInscription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareerID",
                table: "_TInscription",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
