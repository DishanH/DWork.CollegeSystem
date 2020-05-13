using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DWork.CollegeSystem.Infrastructure.Persistence.Migrations
{
    public partial class CheckAggregateRoot3KeyChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                columns: new[] { "Id", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
