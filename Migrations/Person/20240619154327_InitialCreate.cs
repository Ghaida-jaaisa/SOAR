using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourse_FinalProject.Migrations.Person
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Admin", "Email", "FirstName", "LastName", "Location", "Password" },
                values: new object[] { 1, true, "admin1@gmail.com", "yara", "rabaya", "jenin", "202110451" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Admin", "Email", "FirstName", "LastName", "Location", "Password" },
                values: new object[] { 2, true, "admin2@gmail.com", "ghaida", "Admin", "jenin", "202110568" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
