using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Dal.Migrations
{
    public partial class PersonelEklemeSayfalariEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[] { 7, "Yönetim Paneli / İdari İşler/ Personel İşlemleri", "/yonetim/idari-isler/personel-islemleri", null, null, false, "fa fa-users", true, "Personel İşlemleri", (short)1, 3, "/personel-islemleri", null });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[] { 7, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 7, 1, null });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[,]
                {
                    { 9, "Yönetim Paneli / İdari İşler/ Personel İşlemleri / Yeni Personel", "/yonetim/idari-isler/personel-islemleri/tum-kullanicilar/yeni-personel", null, null, false, null, true, "Yeni Kullanıcı", (short)1, 7, "/yeni-personel", null },
                    { 8, "Yönetim Paneli / İdari İşler/ Personel İşlemleri / Tüm Personeller", "/yonetim/idari-isler/personel-islemleri/tum-personeller", null, null, false, null, true, "Tüm Kullanıcılar", (short)0, 7, "/tum-personeller", null }
                });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 8, 1, null },
                    { 9, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 9, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
