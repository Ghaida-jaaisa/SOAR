using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourse_FinalProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ComapnyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Art" },
                    { 2, "Computer" },
                    { 3, "Cooking" },
                    { 4, "Language" },
                    { 5, "Self-Development" },
                    { 6, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "CategoryId", "ComapnyName", "CourseName", "Duration", "Location", "Price" },
                values: new object[] { 1, 2, "ASAL", "HTML & CSS", 16, "Nablus", 2500 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "CategoryId", "ComapnyName", "CourseName", "Duration", "Location", "Price" },
                values: new object[] { 2, 1, "AAUP", "Engineering Drawing", 16, "Nablus", 2500 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "CategoryId", "ComapnyName", "CourseName", "Duration", "Location", "Price" },
                values: new object[] { 3, 6, "Fitness", "BasketBall", 16, "Nablus", 2500 });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
