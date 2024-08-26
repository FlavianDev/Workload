using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkloadApp.Migrations
{
    public partial class serviceactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ServiceActive",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServiceUM",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceActive",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceUM",
                table: "Services");
        }
    }
}
