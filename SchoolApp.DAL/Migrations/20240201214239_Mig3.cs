using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Fee",
                table: "FeeStructures",
                newName: "AmountOfFee");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Admissions",
                newName: "AdmissionUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Admissions",
                newName: "AdmissionUpdatedBy");

            migrationBuilder.RenameColumn(
                name: "StatusDate",
                table: "Admissions",
                newName: "AdmissionStatusDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Admissions",
                newName: "AdmissionStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountOfFee",
                table: "FeeStructures",
                newName: "Fee");

            migrationBuilder.RenameColumn(
                name: "AdmissionUpdatedOn",
                table: "Admissions",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "AdmissionUpdatedBy",
                table: "Admissions",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "AdmissionStatusDate",
                table: "Admissions",
                newName: "StatusDate");

            migrationBuilder.RenameColumn(
                name: "AdmissionStatus",
                table: "Admissions",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "ParentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
