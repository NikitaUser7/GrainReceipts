using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainTWdata.Migrations
{
    /// <inheritdoc />
    public partial class addTest2Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infection1",
                table: "tblGrainReceipts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Infection1",
                table: "tblGrainReceipts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
