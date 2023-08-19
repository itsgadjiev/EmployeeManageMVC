using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagemant.Migrations
{
    public partial class delete_prop_name_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Employees",
                newName: "isDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Employees",
                newName: "Deleted");
        }
    }
}
