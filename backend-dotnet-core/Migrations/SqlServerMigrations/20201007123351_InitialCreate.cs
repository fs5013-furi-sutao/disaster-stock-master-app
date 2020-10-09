using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstBranches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cd = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PrefCd = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstDisasterStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCd = table.Column<string>(nullable: false),
                    SavingStockKbn = table.Column<string>(nullable: false),
                    PrefCd = table.Column<string>(nullable: true),
                    BranchCd = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    StockStartDate = table.Column<DateTime>(nullable: false),
                    StockEndDate = table.Column<DateTime>(nullable: false),
                    ReserveBranchCd = table.Column<string>(nullable: false),
                    StockConditionKbn = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstDisasterStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstKbns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kbn = table.Column<string>(nullable: true),
                    Cd = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstKbns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstManufactures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cd = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstManufactures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPrefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cd = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstPrefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cd = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    ManufactureCd = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstBranches");

            migrationBuilder.DropTable(
                name: "MstDisasterStocks");

            migrationBuilder.DropTable(
                name: "MstKbns");

            migrationBuilder.DropTable(
                name: "MstManufactures");

            migrationBuilder.DropTable(
                name: "MstPrefs");

            migrationBuilder.DropTable(
                name: "MstProducts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
