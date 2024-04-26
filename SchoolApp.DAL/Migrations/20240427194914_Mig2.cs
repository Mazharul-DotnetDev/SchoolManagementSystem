using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                table: "StaffSalary",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "([BasicSalary] + [FestivalBonus] + [Allowance] + [MedicalAllowance] + [HousingAllowance] + [TransportationAllowance] - [SavingFund] - [Taxes])",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5992));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                table: "StaffSalary",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComputedColumnSql: "([BasicSalary] + [FestivalBonus] + [Allowance] + [MedicalAllowance] + [HousingAllowance] + [TransportationAllowance] - [SavingFund] - [Taxes])");

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 26, 19, 47, 57, 787, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 26, 19, 47, 57, 787, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 26, 19, 47, 57, 787, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 1,
                column: "NetSalary",
                value: null);

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 2,
                column: "NetSalary",
                value: null);

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 3,
                column: "NetSalary",
                value: null);
        }
    }
}
