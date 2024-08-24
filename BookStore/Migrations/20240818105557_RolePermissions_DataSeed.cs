using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class RolePermissions_DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("12ed8bc4-2c20-444e-9044-35697544a14c"), null, "Student", null },
                    { new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d"), null, "Librarian", null },
                    { new Guid("960c7252-a2d6-4690-9592-850b3bffbaae"), null, "Teacher", null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("45e3795b-8054-4505-b841-e8d6e943ccae"), "DeleteBook" },
                    { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), "GetBooks" },
                    { new Guid("e5f08c24-7d95-485f-a30e-1ee803ad1552"), "AddBook" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("12ed8bc4-2c20-444e-9044-35697544a14c") },
                    { new Guid("45e3795b-8054-4505-b841-e8d6e943ccae"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") },
                    { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") },
                    { new Guid("e5f08c24-7d95-485f-a30e-1ee803ad1552"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") },
                    { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("960c7252-a2d6-4690-9592-850b3bffbaae") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("12ed8bc4-2c20-444e-9044-35697544a14c") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("45e3795b-8054-4505-b841-e8d6e943ccae"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("e5f08c24-7d95-485f-a30e-1ee803ad1552"), new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"), new Guid("960c7252-a2d6-4690-9592-850b3bffbaae") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12ed8bc4-2c20-444e-9044-35697544a14c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("49c28e7d-ff6b-4968-b329-70e4ddd8736d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("960c7252-a2d6-4690-9592-850b3bffbaae"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("45e3795b-8054-4505-b841-e8d6e943ccae"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("aaa532a0-098d-4b4a-90a2-46be21d37f38"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e5f08c24-7d95-485f-a30e-1ee803ad1552"));
        }
    }
}
