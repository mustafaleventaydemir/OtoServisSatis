using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklenmeTarihi", "Email" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 2, 18, 551, DateTimeKind.Local).AddTicks(6546), "admin@otoservissatis.tc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklenmeTarihi", "Email" },
                values: new object[] { new DateTime(2024, 9, 19, 14, 14, 49, 950, DateTimeKind.Local).AddTicks(1277), "admin.otoservissatis.tc" });
        }
    }
}
