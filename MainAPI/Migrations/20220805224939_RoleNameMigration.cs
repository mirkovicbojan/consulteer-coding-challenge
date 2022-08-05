using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAPI.Migrations
{
    public partial class RoleNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleName",
                table: "roles",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleName",
                table: "roles");
        }
    }
}
