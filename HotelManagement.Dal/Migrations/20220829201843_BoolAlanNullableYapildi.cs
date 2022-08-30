using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Dal.Migrations
{
    public partial class BoolAlanNullableYapildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsBirimMudur",
                table: "Organizasyon",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsBirimMudur",
                table: "Organizasyon",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
