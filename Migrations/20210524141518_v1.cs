using Microsoft.EntityFrameworkCore.Migrations;

namespace employeeattendancesystem.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_attendance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendanceDate = table.Column<string>(nullable: true),
                    attendanceTime = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    employeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_attendance", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_attendance_tbl_employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "tbl_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_attendance_employeeId",
                table: "tbl_attendance",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_attendance");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_employee");
        }
    }
}
