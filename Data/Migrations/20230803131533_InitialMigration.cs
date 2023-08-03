using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Address", "DateOfBirth", "FirstName", "IBAN", "Phone", "Surname" },
                values: new object[,]
                {
                    { new Guid("61d6f3a9-4f1a-4148-8dd2-d82d2372f627"), "Bulgaria", new DateTime(1978, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "BG89UNCR70008359568951", "+359 88 9123456", "Petrov" },
                    { new Guid("cb0c7e8e-419f-4f18-b482-d19eb5e79408"), "UK", new DateTime(1988, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "GB77BARC20037884596399", "+44 7911 123456", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
