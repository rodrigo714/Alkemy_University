using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_University.Data.Migrations
{
    public partial class fourthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TInscription__TCourse_CourseID",
                table: "_TInscription");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "_TInscription",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__TInscription__TCourse_CourseID",
                table: "_TInscription",
                column: "CourseID",
                principalTable: "_TCourse",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TInscription__TCourse_CourseID",
                table: "_TInscription");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "_TInscription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK__TInscription__TCourse_CourseID",
                table: "_TInscription",
                column: "CourseID",
                principalTable: "_TCourse",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
