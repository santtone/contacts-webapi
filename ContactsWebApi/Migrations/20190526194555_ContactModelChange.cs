using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsWebApi.Migrations
{
    public partial class ContactModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Contacts",
                nullable: true);
        }
    }
}
