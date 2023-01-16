using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreDepartment.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departments_DepartmentId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Personels",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Personels_DepartmentId",
                table: "Personels",
                newName: "IX_Personels_DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departments_DepartmentID",
                table: "Personels",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departments_DepartmentID",
                table: "Personels");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Personels",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Personels_DepartmentID",
                table: "Personels",
                newName: "IX_Personels_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departments_DepartmentId",
                table: "Personels",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
