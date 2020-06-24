using Microsoft.EntityFrameworkCore.Migrations;

namespace gtbweb.mvc.Migrations.BlogDb
{
    public partial class Blogdbigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Profiles");
        }
    }
}
