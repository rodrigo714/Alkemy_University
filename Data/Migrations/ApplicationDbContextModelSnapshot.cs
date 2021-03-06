﻿// <auto-generated />
using System;
using Expedientes_Goya.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expedientes_Goya.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Expedientes_Goya.Areas.Career.Models.TCareer", b =>
                {
                    b.Property<int>("CareerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CareerID");

                    b.ToTable("_TCareer");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Course.Models.TCourse", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CareerID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Hours")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CourseID");

                    b.HasIndex("CareerID");

                    b.ToTable("_TCourse");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Documentos", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RutaDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocumento");

                    b.ToTable("_TDocumentos");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Estados", b =>
                {
                    b.Property<short>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescEstado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstado");

                    b.ToTable("_TEstados");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Eventos", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdDocumento")
                        .HasColumnType("int");

                    b.Property<int?>("IdDocumentoNavigationIdDocumento")
                        .HasColumnType("int");

                    b.Property<int>("IdExpdt")
                        .HasColumnType("int");

                    b.Property<int?>("IdExpdtNavigationIdExpdt")
                        .HasColumnType("int");

                    b.Property<short>("IdNuevaDep")
                        .HasColumnType("smallint");

                    b.Property<string>("IdOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("TipoEvento")
                        .HasColumnType("smallint");

                    b.Property<short?>("TipoEventoNavigationIdTipoEvento")
                        .HasColumnType("smallint");

                    b.HasKey("IdEvento");

                    b.HasIndex("IdDocumentoNavigationIdDocumento");

                    b.HasIndex("IdExpdtNavigationIdExpdt");

                    b.HasIndex("TipoEventoNavigationIdTipoEvento");

                    b.ToTable("_TEventos");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Expedientes", b =>
                {
                    b.Property<int>("IdExpdt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("Estado")
                        .HasColumnType("smallint");

                    b.Property<short?>("EstadosIdEstado")
                        .HasColumnType("smallint");

                    b.Property<string>("Extracto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAltaExpte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalExpte")
                        .HasColumnType("datetime2");

                    b.Property<short>("IdDepInicio")
                        .HasColumnType("smallint");

                    b.Property<string>("IdOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumExpdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdExpdt");

                    b.HasIndex("EstadosIdEstado");

                    b.ToTable("_TExpedientes");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.TipoEventos", b =>
                {
                    b.Property<short>("IdTipoEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescTipoEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoEvento");

                    b.ToTable("_TTipoEventos");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Inscriptions.Models.Inscription", b =>
                {
                    b.Property<int>("InscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InscriptionID");

                    b.HasIndex("CourseID");

                    b.ToTable("_TInscription");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Organizaciones.Models.Dependencias", b =>
                {
                    b.Property<short>("IdDependencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescDependencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirDependencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("IdSecretaria")
                        .HasColumnType("smallint");

                    b.Property<short?>("IdSecretariaNavigationIdSecretaria")
                        .HasColumnType("smallint");

                    b.Property<string>("MailDependencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelDependencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDependencia");

                    b.HasIndex("IdSecretariaNavigationIdSecretaria");

                    b.ToTable("_TDependencias");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Organizaciones.Models.Organizaciones", b =>
                {
                    b.Property<int>("IdOrganizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescOrganizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirOrganizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailOrganizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelOrganizacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrganizacion");

                    b.ToTable("_TOrganizaciones");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Organizaciones.Models.Secretarias", b =>
                {
                    b.Property<short>("IdSecretaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescSecretaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirSecretaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailSecretaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelSecretaria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSecretaria");

                    b.ToTable("_TSecretarias");
                });

            modelBuilder.Entity("Expedientes_Goya.Models.IdentityExtends", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("DependenciasIdDependencia")
                        .HasColumnType("smallint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha_Alta")
                        .HasColumnType("datetime2");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("IdDependencia")
                        .HasColumnType("smallint");

                    b.Property<int?>("IdOrganizacion")
                        .HasColumnType("int");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("OrganizacionesIdOrganizacion")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DependenciasIdDependencia");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OrganizacionesIdOrganizacion");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Course.Models.TCourse", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Career.Models.TCareer", "Career")
                        .WithMany("Courses")
                        .HasForeignKey("CareerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Eventos", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Expedientes.Models.Documentos", "IdDocumentoNavigation")
                        .WithMany("Eventos")
                        .HasForeignKey("IdDocumentoNavigationIdDocumento");

                    b.HasOne("Expedientes_Goya.Areas.Expedientes.Models.Expedientes", "IdExpdtNavigation")
                        .WithMany()
                        .HasForeignKey("IdExpdtNavigationIdExpdt");

                    b.HasOne("Expedientes_Goya.Areas.Expedientes.Models.TipoEventos", "TipoEventoNavigation")
                        .WithMany("Eventos")
                        .HasForeignKey("TipoEventoNavigationIdTipoEvento");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Expedientes.Models.Expedientes", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Expedientes.Models.Estados", null)
                        .WithMany("Expediente")
                        .HasForeignKey("EstadosIdEstado");
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Inscriptions.Models.Inscription", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Course.Models.TCourse", "Course")
                        .WithMany("Inscription")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expedientes_Goya.Areas.Organizaciones.Models.Dependencias", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Organizaciones.Models.Secretarias", "IdSecretariaNavigation")
                        .WithMany("Dependencia")
                        .HasForeignKey("IdSecretariaNavigationIdSecretaria");
                });

            modelBuilder.Entity("Expedientes_Goya.Models.IdentityExtends", b =>
                {
                    b.HasOne("Expedientes_Goya.Areas.Organizaciones.Models.Dependencias", null)
                        .WithMany("AspNetUsers")
                        .HasForeignKey("DependenciasIdDependencia");

                    b.HasOne("Expedientes_Goya.Areas.Organizaciones.Models.Organizaciones", null)
                        .WithMany("AspNetUsers")
                        .HasForeignKey("OrganizacionesIdOrganizacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Expedientes_Goya.Models.IdentityExtends", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Expedientes_Goya.Models.IdentityExtends", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expedientes_Goya.Models.IdentityExtends", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Expedientes_Goya.Models.IdentityExtends", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
