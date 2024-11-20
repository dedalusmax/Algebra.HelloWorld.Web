using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Algebra.HelloWorld.Web.MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class sql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // script-migration

            migrationBuilder.Sql("SELECT 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
