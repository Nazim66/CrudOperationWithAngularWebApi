using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Roll = table.Column<int>(nullable: false),
                    Section = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: false),
                    FathersName = table.Column<string>(nullable: false),
                    MothersName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdcuationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    PSCGPA = table.Column<double>(nullable: false),
                    PSCPassingYear = table.Column<int>(nullable: false),
                    SSCGPA = table.Column<double>(nullable: false),
                    SSCPassingYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdcuationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdcuationDetails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdcuationDetails_StudentId",
                table: "EdcuationDetails",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdcuationDetails");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
