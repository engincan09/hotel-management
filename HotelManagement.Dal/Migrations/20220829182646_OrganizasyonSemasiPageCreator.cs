using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Dal.Migrations
{
    public partial class OrganizasyonSemasiPageCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9,
                column: "AllRouterLink",
                value: "/yonetim/idari-isler/personel-islemleri/yeni-personel");

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[] { 10, "Yönetim Paneli / İdari İşler/ Organizasyon Şeması", "/yonetim/idari-isler/organizasyon-semasi", null, null, false, null, true, "Organizasyon Şeması", (short)1, 3, "/organizasyon-semasi", null });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[] { 10, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 10, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9,
                column: "AllRouterLink",
                value: "/yonetim/idari-isler/personel-islemleri/tum-kullanicilar/yeni-personel");
        }
    }
}
