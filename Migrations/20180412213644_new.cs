using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Shortlist.Api.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Role_EmployeeRoleRoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Person_RelatedPersonPersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Company_RelatedCompanyCompanyId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companys");

            migrationBuilder.RenameIndex(
                name: "IX_Person_RelatedCompanyCompanyId",
                table: "Persons",
                newName: "IX_Persons_RelatedCompanyCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "CompanyId");

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    AssessmentQuestionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Answers = table.Column<List<string>>(nullable: true),
                    QuestionNumber = table.Column<int>(nullable: false),
                    QuestionTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => x.AssessmentQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AssessmentName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DepartmentManagerEmployeeId = table.Column<int>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    ParentDepartmentDepartmentId = table.Column<int>(nullable: true),
                    RelatedCompanyCompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Employees_DepartmentManagerEmployeeId",
                        column: x => x.DepartmentManagerEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentDepartmentId",
                        column: x => x.ParentDepartmentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Companys_RelatedCompanyCompanyId",
                        column: x => x.RelatedCompanyCompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Openings",
                columns: table => new
                {
                    OpeningId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JobDescription = table.Column<string>(nullable: true),
                    OpeningForRoleId = table.Column<int>(nullable: true),
                    RelatedCompanyCompanyId = table.Column<int>(nullable: true),
                    Responsibilities = table.Column<List<string>>(nullable: true),
                    SkillLevel = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openings", x => x.OpeningId);
                    table.ForeignKey(
                        name: "FK_Openings_Roles_OpeningForRoleId",
                        column: x => x.OpeningForRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Openings_Companys_RelatedCompanyCompanyId",
                        column: x => x.RelatedCompanyCompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AdditionalDetails = table.Column<string>(nullable: true),
                    Attachments = table.Column<List<string>>(nullable: true),
                    DateApplied = table.Column<DateTime>(nullable: false),
                    GithubLink = table.Column<string>(nullable: true),
                    LinkedinLink = table.Column<string>(nullable: true),
                    OpeningId = table.Column<int>(nullable: true),
                    OtherLink = table.Column<string>(nullable: true),
                    PortfolioLink = table.Column<string>(nullable: true),
                    RelatedPersonPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicants_Openings_OpeningId",
                        column: x => x.OpeningId,
                        principalTable: "Openings",
                        principalColumn: "OpeningId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicants_Persons_RelatedPersonPersonId",
                        column: x => x.RelatedPersonPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationQuestions",
                columns: table => new
                {
                    ApplicationQuestionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApplicationQuestionName = table.Column<string>(nullable: true),
                    RelatedOpeningOpeningId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationQuestions", x => x.ApplicationQuestionId);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestions_Openings_RelatedOpeningOpeningId",
                        column: x => x.RelatedOpeningOpeningId,
                        principalTable: "Openings",
                        principalColumn: "OpeningId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OpeningId = table.Column<int>(nullable: true),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Openings_OpeningId",
                        column: x => x.OpeningId,
                        principalTable: "Openings",
                        principalColumn: "OpeningId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationAnswers",
                columns: table => new
                {
                    ApplicationAnswerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApplicationAnswerText = table.Column<string>(nullable: true),
                    RelatedApplicantApplicantId = table.Column<int>(nullable: true),
                    RelatedOpeningOpeningId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAnswers", x => x.ApplicationAnswerId);
                    table.ForeignKey(
                        name: "FK_ApplicationAnswers_Applicants_RelatedApplicantApplicantId",
                        column: x => x.RelatedApplicantApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationAnswers_Openings_RelatedOpeningOpeningId",
                        column: x => x.RelatedOpeningOpeningId,
                        principalTable: "Openings",
                        principalColumn: "OpeningId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeSkillId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RelatedSkillSkillId = table.Column<int>(nullable: true),
                    SkillLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.EmployeeSkillId);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_RelatedSkillSkillId",
                        column: x => x.RelatedSkillSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_OpeningId",
                table: "Applicants",
                column: "OpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_RelatedPersonPersonId",
                table: "Applicants",
                column: "RelatedPersonPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAnswers_RelatedApplicantApplicantId",
                table: "ApplicationAnswers",
                column: "RelatedApplicantApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAnswers_RelatedOpeningOpeningId",
                table: "ApplicationAnswers",
                column: "RelatedOpeningOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestions_RelatedOpeningOpeningId",
                table: "ApplicationQuestions",
                column: "RelatedOpeningOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentManagerEmployeeId",
                table: "Departments",
                column: "DepartmentManagerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RelatedCompanyCompanyId",
                table: "Departments",
                column: "RelatedCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_RelatedSkillSkillId",
                table: "EmployeeSkills",
                column: "RelatedSkillSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Openings_OpeningForRoleId",
                table: "Openings",
                column: "OpeningForRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Openings_RelatedCompanyCompanyId",
                table: "Openings",
                column: "RelatedCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_OpeningId",
                table: "Skills",
                column: "OpeningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_EmployeeRoleRoleId",
                table: "Employees",
                column: "EmployeeRoleRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Persons_RelatedPersonPersonId",
                table: "Employees",
                column: "RelatedPersonPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Companys_RelatedCompanyCompanyId",
                table: "Persons",
                column: "RelatedCompanyCompanyId",
                principalTable: "Companys",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_EmployeeRoleRoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Persons_RelatedPersonPersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Companys_RelatedCompanyCompanyId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "ApplicationAnswers");

            migrationBuilder.DropTable(
                name: "ApplicationQuestions");

            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Openings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_RelatedCompanyCompanyId",
                table: "Person",
                newName: "IX_Person_RelatedCompanyCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Role_EmployeeRoleRoleId",
                table: "Employees",
                column: "EmployeeRoleRoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Person_RelatedPersonPersonId",
                table: "Employees",
                column: "RelatedPersonPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Company_RelatedCompanyCompanyId",
                table: "Person",
                column: "RelatedCompanyCompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
