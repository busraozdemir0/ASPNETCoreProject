using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreProject.Migrations
{
    public partial class mig_column_gorsel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GorselYol",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorselYol",
                table: "Personels");
        }
    }
}
