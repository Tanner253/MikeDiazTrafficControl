using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MkAffiliationManagement.Migrations.BlogDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "ID", "Body", "Date", "Image", "Title" },
                values: new object[] { 1, "This is the Body", new DateTime(2021, 11, 2, 12, 20, 34, 881, DateTimeKind.Local).AddTicks(1084), "", "This is the Title." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
