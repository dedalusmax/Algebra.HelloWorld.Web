using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Algebra.HelloWorld.Web.MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class pettypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetTypeId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetShops_Name_Address",
                table: "PetShops",
                columns: new[] { "Name", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Name",
                table: "Pets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropIndex(
                name: "IX_PetShops_Name_Address",
                table: "PetShops");

            migrationBuilder.DropIndex(
                name: "IX_Pets_Name",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "Pets");

            migrationBuilder.AddColumn<byte>(
                name: "PetType",
                table: "Pets",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
