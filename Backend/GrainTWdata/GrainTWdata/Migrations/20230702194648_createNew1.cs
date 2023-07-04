using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainTWdata.Migrations
{
    /// <inheritdoc />
    public partial class createNew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblGrainReceiptMerged",
                columns: table => new
                {
                    SysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CropYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    CounterpartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wetness = table.Column<float>(type: "real", nullable: true),
                    Garbage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Infection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGrainReceiptMerged", x => x.SysId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblGrainReceiptMerged");
        }
    }
}
