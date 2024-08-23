using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChilliStorage.Migrations
{
    /// <inheritdoc />
    public partial class Alter_ConsignmentDocument_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppApp_SupplierId",
                table: "AppApp",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppApp_AbpTenants_SupplierId",
                table: "AppApp",
                column: "SupplierId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppApp_AbpTenants_SupplierId",
                table: "AppApp");

            migrationBuilder.DropIndex(
                name: "IX_AppApp_SupplierId",
                table: "AppApp");
        }
    }
}
