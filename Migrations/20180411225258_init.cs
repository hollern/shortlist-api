using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Shortlist.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AdditionalDetails = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    MidIn = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RelatedCompanyCompanyId = table.Column<int>(nullable: true),
                    Ssn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Company_RelatedCompanyCompanyId",
                        column: x => x.RelatedCompanyCompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateJoined = table.Column<DateTime>(nullable: false),
                    DateLeft = table.Column<DateTime>(nullable: false),
                    EmployeeRoleRoleId = table.Column<int>(nullable: true),
                    RelatedPersonPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Role_EmployeeRoleRoleId",
                        column: x => x.EmployeeRoleRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Person_RelatedPersonPersonId",
                        column: x => x.RelatedPersonPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeRoleRoleId",
                table: "Employees",
                column: "EmployeeRoleRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RelatedPersonPersonId",
                table: "Employees",
                column: "RelatedPersonPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RelatedCompanyCompanyId",
                table: "Person",
                column: "RelatedCompanyCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
