using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainTWdata.Migrations
{
    /// <inheritdoc />
    public partial class addTest3Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tblGrainReceipts",
                newName: "TblGrainReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblGrainReceipts",
                table: "TblGrainReceipts",
                column: "SysID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblGrainReceipts",
                table: "TblGrainReceipts");

            migrationBuilder.RenameTable(
                name: "TblGrainReceipts",
                newName: "tblGrainReceipts");
        }
    }
}
