using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainTWdata.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblGrainReceipts",
                columns: table => new
                {
                    SysID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CropYear = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    CounterpartyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Wetness = table.Column<double>(type: "float", nullable: true),
                    Garbage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Infection = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblGrainReceipts");
        }
    }
}
