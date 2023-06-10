using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaaV.Clean.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dummy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dummy", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dummy");
        }
    }
}
