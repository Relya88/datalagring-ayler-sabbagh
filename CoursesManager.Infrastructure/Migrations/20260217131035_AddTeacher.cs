using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherEntityId",
                table: "CourseSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_TeacherEntityId",
                table: "CourseSessions",
                column: "TeacherEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessions_Teachers_TeacherEntityId",
                table: "CourseSessions",
                column: "TeacherEntityId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSessions_Teachers_TeacherEntityId",
                table: "CourseSessions");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_CourseSessions_TeacherEntityId",
                table: "CourseSessions");

            migrationBuilder.DropColumn(
                name: "TeacherEntityId",
                table: "CourseSessions");
        }
    }
}
