using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Shortlist.Api.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answers",
                table: "AssessmentQuestions",
                newName: "PossibleAnswers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedDepartmentDepartmentId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedEmployeeEmployeeId",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentName",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RelatedCompanyCompanyId",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssessmentAnswers",
                columns: table => new
                {
                    AssessmentAnswerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AssessmentAnswerText = table.Column<string>(nullable: true),
                    RelatedAssessmentQuestionAssessmentQuestionId = table.Column<int>(nullable: true),
                    RelatedEmployeeEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentAnswers", x => x.AssessmentAnswerId);
                    table.ForeignKey(
                        name: "FK_AssessmentAnswers_AssessmentQuestions_RelatedAssessmentQuestionAssessmentQuestionId",
                        column: x => x.RelatedAssessmentQuestionAssessmentQuestionId,
                        principalTable: "AssessmentQuestions",
                        principalColumn: "AssessmentQuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentAnswers_Employees_RelatedEmployeeEmployeeId",
                        column: x => x.RelatedEmployeeEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_RoleId",
                table: "Skills",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RelatedDepartmentDepartmentId",
                table: "Roles",
                column: "RelatedDepartmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_RelatedEmployeeEmployeeId",
                table: "EmployeeSkills",
                column: "RelatedEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_RelatedCompanyCompanyId",
                table: "Assessments",
                column: "RelatedCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestions_RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions",
                column: "RelatedAssessmentAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAnswers_RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers",
                column: "RelatedApplicationQuestionApplicationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentAnswers_RelatedAssessmentQuestionAssessmentQuestionId",
                table: "AssessmentAnswers",
                column: "RelatedAssessmentQuestionAssessmentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentAnswers_RelatedEmployeeEmployeeId",
                table: "AssessmentAnswers",
                column: "RelatedEmployeeEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationAnswers_ApplicationQuestions_RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers",
                column: "RelatedApplicationQuestionApplicationQuestionId",
                principalTable: "ApplicationQuestions",
                principalColumn: "ApplicationQuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentQuestions_Assessments_RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions",
                column: "RelatedAssessmentAssessmentId",
                principalTable: "Assessments",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Companys_RelatedCompanyCompanyId",
                table: "Assessments",
                column: "RelatedCompanyCompanyId",
                principalTable: "Companys",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Employees_RelatedEmployeeEmployeeId",
                table: "EmployeeSkills",
                column: "RelatedEmployeeEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Departments_RelatedDepartmentDepartmentId",
                table: "Roles",
                column: "RelatedDepartmentDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Roles_RoleId",
                table: "Skills",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationAnswers_ApplicationQuestions_RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentQuestions_Assessments_RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Companys_RelatedCompanyCompanyId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Employees_RelatedEmployeeEmployeeId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Departments_RelatedDepartmentDepartmentId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Roles_RoleId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "AssessmentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Skills_RoleId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RelatedDepartmentDepartmentId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_RelatedEmployeeEmployeeId",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_RelatedCompanyCompanyId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_AssessmentQuestions_RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationAnswers_RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "RelatedDepartmentDepartmentId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RelatedEmployeeEmployeeId",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "RelatedCompanyCompanyId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "RelatedAssessmentAssessmentId",
                table: "AssessmentQuestions");

            migrationBuilder.DropColumn(
                name: "RelatedApplicationQuestionApplicationQuestionId",
                table: "ApplicationAnswers");

            migrationBuilder.RenameColumn(
                name: "PossibleAnswers",
                table: "AssessmentQuestions",
                newName: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentName",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
