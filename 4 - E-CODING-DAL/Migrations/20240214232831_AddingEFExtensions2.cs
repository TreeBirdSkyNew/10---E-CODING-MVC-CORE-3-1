using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4___E_CODING_DAL.Migrations
{
    public partial class AddingEFExtensions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateProjectId",
                table: "TemplateSolution");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateProjectId",
                table: "TemplateSolution",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
