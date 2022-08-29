using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelManagement.Dal.Migrations
{
    public partial class OrganizasyonVeriModeliAcildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "OrganizasyonId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizasyon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedUserId = table.Column<int>(nullable: true),
                    LastUpdatedUserId = table.Column<int>(nullable: true),
                    DataStatus = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    NumberOfStaff = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 64, nullable: true),
                    IsBirimMudur = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizasyon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizasyon_Organizasyon_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organizasyon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OrganizasyonId",
                table: "Employee",
                column: "OrganizasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizasyon_ParentId",
                table: "Organizasyon",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Organizasyon_OrganizasyonId",
                table: "Employee",
                column: "OrganizasyonId",
                principalTable: "Organizasyon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Organizasyon_OrganizasyonId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Organizasyon");

            migrationBuilder.DropIndex(
                name: "IX_Employee_OrganizasyonId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OrganizasyonId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeType",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
