using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DWork.CollegeSystem.Infrastructure.Persistence.Migrations
{
    public partial class CheckAggregateRoot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Authors");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfDeath",
                table: "Authors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
