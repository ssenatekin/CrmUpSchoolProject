using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmUpSchool.DataAccessLayer.Migrations
{
    public partial class mig_change_employeetask_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeID",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_EmployeeTasks_EmployeeTaskID1",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_EmployeeID",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_EmployeeTaskID1",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "EmployeeTaskID1",
                table: "EmployeeTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTaskID1",
                table: "EmployeeTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeID",
                table: "EmployeeTasks",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeTaskID1",
                table: "EmployeeTasks",
                column: "EmployeeTaskID1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeID",
                table: "EmployeeTasks",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_EmployeeTasks_EmployeeTaskID1",
                table: "EmployeeTasks",
                column: "EmployeeTaskID1",
                principalTable: "EmployeeTasks",
                principalColumn: "EmployeeTaskID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
