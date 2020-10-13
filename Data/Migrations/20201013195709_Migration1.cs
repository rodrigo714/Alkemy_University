using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expedientes_Goya.Data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "DependenciasIdDependencia",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Alta",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdDependencia",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOrganizacion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizacionesIdOrganizacion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "_TDocumentos",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescDocumento = table.Column<string>(nullable: true),
                    RutaDocumento = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    FechaAlta = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TDocumentos", x => x.IdDocumento);
                });

            migrationBuilder.CreateTable(
                name: "_TEstados",
                columns: table => new
                {
                    IdEstado = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescEstado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TEstados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "_TOrganizaciones",
                columns: table => new
                {
                    IdOrganizacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescOrganizacion = table.Column<string>(nullable: true),
                    DirOrganizacion = table.Column<string>(nullable: true),
                    TelOrganizacion = table.Column<string>(nullable: true),
                    MailOrganizacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TOrganizaciones", x => x.IdOrganizacion);
                });

            migrationBuilder.CreateTable(
                name: "_TSecretarias",
                columns: table => new
                {
                    IdSecretaria = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescSecretaria = table.Column<string>(nullable: true),
                    DirSecretaria = table.Column<string>(nullable: true),
                    TelSecretaria = table.Column<string>(nullable: true),
                    MailSecretaria = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TSecretarias", x => x.IdSecretaria);
                });

            migrationBuilder.CreateTable(
                name: "_TTipoEventos",
                columns: table => new
                {
                    IdTipoEvento = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoEvento = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TTipoEventos", x => x.IdTipoEvento);
                });

            migrationBuilder.CreateTable(
                name: "_TExpedientes",
                columns: table => new
                {
                    IdExpdt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumExpdt = table.Column<string>(nullable: true),
                    IdDepInicio = table.Column<short>(nullable: false),
                    IdOperador = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<string>(nullable: true),
                    Extracto = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    FechaAltaExpte = table.Column<DateTime>(nullable: false),
                    FechaFinalExpte = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<short>(nullable: true),
                    EstadosIdEstado = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TExpedientes", x => x.IdExpdt);
                    table.ForeignKey(
                        name: "FK__TExpedientes__TEstados_EstadosIdEstado",
                        column: x => x.EstadosIdEstado,
                        principalTable: "_TEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_TDependencias",
                columns: table => new
                {
                    IdDependencia = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescDependencia = table.Column<string>(nullable: true),
                    IdSecretaria = table.Column<short>(nullable: true),
                    DirDependencia = table.Column<string>(nullable: true),
                    TelDependencia = table.Column<string>(nullable: true),
                    MailDependencia = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    IdSecretariaNavigationIdSecretaria = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TDependencias", x => x.IdDependencia);
                    table.ForeignKey(
                        name: "FK__TDependencias__TSecretarias_IdSecretariaNavigationIdSecretaria",
                        column: x => x.IdSecretariaNavigationIdSecretaria,
                        principalTable: "_TSecretarias",
                        principalColumn: "IdSecretaria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_TEventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExpdt = table.Column<int>(nullable: false),
                    IdNuevaDep = table.Column<short>(nullable: false),
                    IdOperador = table.Column<string>(nullable: true),
                    IdDocumento = table.Column<int>(nullable: true),
                    FechaEvento = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    TipoEvento = table.Column<short>(nullable: false),
                    IdDocumentoNavigationIdDocumento = table.Column<int>(nullable: true),
                    IdExpdtNavigationIdExpdt = table.Column<int>(nullable: true),
                    TipoEventoNavigationIdTipoEvento = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TEventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK__TEventos__TDocumentos_IdDocumentoNavigationIdDocumento",
                        column: x => x.IdDocumentoNavigationIdDocumento,
                        principalTable: "_TDocumentos",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TEventos__TExpedientes_IdExpdtNavigationIdExpdt",
                        column: x => x.IdExpdtNavigationIdExpdt,
                        principalTable: "_TExpedientes",
                        principalColumn: "IdExpdt",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TEventos__TTipoEventos_TipoEventoNavigationIdTipoEvento",
                        column: x => x.TipoEventoNavigationIdTipoEvento,
                        principalTable: "_TTipoEventos",
                        principalColumn: "IdTipoEvento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DependenciasIdDependencia",
                table: "AspNetUsers",
                column: "DependenciasIdDependencia");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizacionesIdOrganizacion",
                table: "AspNetUsers",
                column: "OrganizacionesIdOrganizacion");

            migrationBuilder.CreateIndex(
                name: "IX__TDependencias_IdSecretariaNavigationIdSecretaria",
                table: "_TDependencias",
                column: "IdSecretariaNavigationIdSecretaria");

            migrationBuilder.CreateIndex(
                name: "IX__TEventos_IdDocumentoNavigationIdDocumento",
                table: "_TEventos",
                column: "IdDocumentoNavigationIdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX__TEventos_IdExpdtNavigationIdExpdt",
                table: "_TEventos",
                column: "IdExpdtNavigationIdExpdt");

            migrationBuilder.CreateIndex(
                name: "IX__TEventos_TipoEventoNavigationIdTipoEvento",
                table: "_TEventos",
                column: "TipoEventoNavigationIdTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX__TExpedientes_EstadosIdEstado",
                table: "_TExpedientes",
                column: "EstadosIdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers__TDependencias_DependenciasIdDependencia",
                table: "AspNetUsers",
                column: "DependenciasIdDependencia",
                principalTable: "_TDependencias",
                principalColumn: "IdDependencia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers__TOrganizaciones_OrganizacionesIdOrganizacion",
                table: "AspNetUsers",
                column: "OrganizacionesIdOrganizacion",
                principalTable: "_TOrganizaciones",
                principalColumn: "IdOrganizacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers__TDependencias_DependenciasIdDependencia",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers__TOrganizaciones_OrganizacionesIdOrganizacion",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "_TDependencias");

            migrationBuilder.DropTable(
                name: "_TEventos");

            migrationBuilder.DropTable(
                name: "_TOrganizaciones");

            migrationBuilder.DropTable(
                name: "_TSecretarias");

            migrationBuilder.DropTable(
                name: "_TDocumentos");

            migrationBuilder.DropTable(
                name: "_TExpedientes");

            migrationBuilder.DropTable(
                name: "_TTipoEventos");

            migrationBuilder.DropTable(
                name: "_TEstados");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DependenciasIdDependencia",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizacionesIdOrganizacion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DependenciasIdDependencia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fecha_Alta",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDependencia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdOrganizacion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizacionesIdOrganizacion",
                table: "AspNetUsers");
        }
    }
}
