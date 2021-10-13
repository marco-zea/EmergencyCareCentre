using Microsoft.EntityFrameworkCore.Migrations;

namespace ECC.WebApi.Migrations
{
    public partial class CommentIsAdmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmission",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmission",
                table: "Comments");
        }
    }
}
