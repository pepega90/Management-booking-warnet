using Microsoft.EntityFrameworkCore.Migrations;

namespace BokingWarnet.Migrations
{
    public partial class addDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "7ec6f367-4f05-4789-a2e4-1c7b59cae33e", "admin@gmail.com", false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGpzDgfaCF0CoyPj1KCbpV8JFKAmMpRYfXJgnkQTNaxQp2uHNY6bJu3G8wC+3U0a4Q==", null, false, "8bebf950-358a-48f4-b118-2356cbbb45cb", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
