using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErakGiyim.Migrations
{
    /// <inheritdoc />
    public partial class CapitalLetter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "paid",
                table: "Orders",
                newName: "Paid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "Orders",
                newName: "paid");
        }
    }
}
