using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantMicroservice.Migrations
{
    public partial class plant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    DemandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandCount = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    DemandRaisedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.DemandId);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartDescription = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PartSpecification = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    StockInHand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "PlantReoDetail",
                columns: table => new
                {
                    PlantReorderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    PartDetails = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ReorderStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ReorderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantReoDetail", x => x.PlantReorderId);
                });

            migrationBuilder.CreateTable(
                name: "ReoRule",
                columns: table => new
                {
                    ReorderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    DemandId = table.Column<int>(type: "int", nullable: false),
                    MinQuantity = table.Column<int>(type: "int", nullable: false),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false),
                    ReorderFrequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReoRule", x => x.ReorderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demands");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PlantReoDetail");

            migrationBuilder.DropTable(
                name: "ReoRule");
        }
    }
}
