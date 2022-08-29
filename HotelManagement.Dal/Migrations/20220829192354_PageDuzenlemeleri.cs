using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Dal.Migrations
{
    public partial class PageDuzenlemeleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AllName", "AllRouterLink", "Icon", "Name", "RouterLink" },
                values: new object[] { "Yönetim Paneli / İdari İşler / Organizasyon Kadro İşlemleri", "/yonetim/idari-isler/organizasyon-kadro-islemleri", "fa fa-sitemap", "Organizasyon Kadro İşlemleri", "/organizasyon-kadro-islemleri" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[,]
                {
                    { 12, "Yönetim Paneli / İdari İşler/ Organizasyon Kadro İşlemleri / Yeni Birim", "/yonetim/idari-isler/organizasyon-kadro-islemleri/yeni-birim", null, null, false, null, true, "Yeni Birim", (short)1, 10, "/yeni-birim", null },
                    { 11, "Yönetim Paneli / İdari İşler/ Organizasyon Kadro İşlemleri / Organizasyon Şeması", "/yonetim/idari-isler/organizasyon-kadro-islemleri/organizasyon-semasi", null, null, false, null, true, "Organizasyon Şeması", (short)1, 10, "/organizasyon-semasi", null }
                });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 11, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 11, 1, null },
                    { 12, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 12, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AllName", "AllRouterLink", "Icon", "Name", "RouterLink" },
                values: new object[] { "Yönetim Paneli / İdari İşler/ Organizasyon Şeması", "/yonetim/idari-isler/organizasyon-semasi", null, "Organizasyon Şeması", "/organizasyon-semasi" });
        }
    }
}
