using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspcoreLAB2.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Courses_CourseId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Departments_DepartmentId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_instructors_CourseId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_DepartmentId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Trainees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trainee_id",
                table: "Trainees",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dept_id",
                table: "instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ins_id",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trainee_id",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dept_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ins_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_crs_id",
                table: "Trainees",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_crs_id",
                table: "instructors",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_dept_id",
                table: "instructors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_dept_id",
                table: "Courses",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_dept_id",
                table: "Courses",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Courses_crs_id",
                table: "instructors",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Courses_crs_id",
                table: "Trainees",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_dept_id",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Courses_crs_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_Departments_dept_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Courses_crs_id",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_crs_id",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_instructors_crs_id",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_dept_id",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_dept_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "trainee_id",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "dept_id",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ins_id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "trainee_id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "dept_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ins_id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_instructors_CourseId",
                table: "instructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_DepartmentId",
                table: "instructors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Courses_CourseId",
                table: "instructors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_Departments_DepartmentId",
                table: "instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
