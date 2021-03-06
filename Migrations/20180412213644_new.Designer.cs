﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Shortlist.Api.Data;
using System;
using System.Collections.Generic;

namespace Shortlist.Api.Migrations
{
    [DbContext(typeof(OrganizationContext))]
    [Migration("20180412213644_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Shortlist.Api.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalDetails");

                    b.Property<List<string>>("Attachments");

                    b.Property<DateTime>("DateApplied");

                    b.Property<string>("GithubLink");

                    b.Property<string>("LinkedinLink");

                    b.Property<int?>("OpeningId");

                    b.Property<string>("OtherLink");

                    b.Property<string>("PortfolioLink");

                    b.Property<int?>("RelatedPersonPersonId");

                    b.HasKey("ApplicantId");

                    b.HasIndex("OpeningId");

                    b.HasIndex("RelatedPersonPersonId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("Shortlist.Api.Models.ApplicationAnswer", b =>
                {
                    b.Property<int>("ApplicationAnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationAnswerText");

                    b.Property<int?>("RelatedApplicantApplicantId");

                    b.Property<int?>("RelatedOpeningOpeningId");

                    b.HasKey("ApplicationAnswerId");

                    b.HasIndex("RelatedApplicantApplicantId");

                    b.HasIndex("RelatedOpeningOpeningId");

                    b.ToTable("ApplicationAnswers");
                });

            modelBuilder.Entity("Shortlist.Api.Models.ApplicationQuestion", b =>
                {
                    b.Property<int>("ApplicationQuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationQuestionName");

                    b.Property<int?>("RelatedOpeningOpeningId");

                    b.HasKey("ApplicationQuestionId");

                    b.HasIndex("RelatedOpeningOpeningId");

                    b.ToTable("ApplicationQuestions");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Assessment", b =>
                {
                    b.Property<int>("AssessmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssessmentName");

                    b.HasKey("AssessmentId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Shortlist.Api.Models.AssessmentQuestion", b =>
                {
                    b.Property<int>("AssessmentQuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<List<string>>("Answers");

                    b.Property<int>("QuestionNumber");

                    b.Property<string>("QuestionTitle");

                    b.HasKey("AssessmentQuestionId");

                    b.ToTable("AssessmentQuestions");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartmentManagerEmployeeId");

                    b.Property<string>("DepartmentName");

                    b.Property<int?>("ParentDepartmentDepartmentId");

                    b.Property<int?>("RelatedCompanyCompanyId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepartmentManagerEmployeeId");

                    b.HasIndex("ParentDepartmentDepartmentId");

                    b.HasIndex("RelatedCompanyCompanyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateJoined");

                    b.Property<DateTime>("DateLeft");

                    b.Property<int?>("EmployeeRoleRoleId");

                    b.Property<int?>("RelatedPersonPersonId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeRoleRoleId");

                    b.HasIndex("RelatedPersonPersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Shortlist.Api.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeSkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RelatedSkillSkillId");

                    b.Property<int>("SkillLevel");

                    b.HasKey("EmployeeSkillId");

                    b.HasIndex("RelatedSkillSkillId");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Opening", b =>
                {
                    b.Property<int>("OpeningId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JobDescription");

                    b.Property<int?>("OpeningForRoleId");

                    b.Property<int?>("RelatedCompanyCompanyId");

                    b.Property<List<string>>("Responsibilities");

                    b.Property<List<int>>("SkillLevel");

                    b.HasKey("OpeningId");

                    b.HasIndex("OpeningForRoleId");

                    b.HasIndex("RelatedCompanyCompanyId");

                    b.ToTable("Openings");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalDetails");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BDate");

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("Gender");

                    b.Property<string>("LName");

                    b.Property<string>("MidIn");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("RelatedCompanyCompanyId");

                    b.Property<string>("Ssn");

                    b.HasKey("PersonId");

                    b.HasIndex("RelatedCompanyCompanyId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OpeningId");

                    b.Property<string>("SkillName");

                    b.HasKey("SkillId");

                    b.HasIndex("OpeningId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Applicant", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Opening")
                        .WithMany("Applicants")
                        .HasForeignKey("OpeningId");

                    b.HasOne("Shortlist.Api.Models.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonPersonId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.ApplicationAnswer", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Applicant", "RelatedApplicant")
                        .WithMany()
                        .HasForeignKey("RelatedApplicantApplicantId");

                    b.HasOne("Shortlist.Api.Models.Opening", "RelatedOpening")
                        .WithMany()
                        .HasForeignKey("RelatedOpeningOpeningId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.ApplicationQuestion", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Opening", "RelatedOpening")
                        .WithMany()
                        .HasForeignKey("RelatedOpeningOpeningId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Department", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Employee", "DepartmentManager")
                        .WithMany()
                        .HasForeignKey("DepartmentManagerEmployeeId");

                    b.HasOne("Shortlist.Api.Models.Department", "ParentDepartment")
                        .WithMany()
                        .HasForeignKey("ParentDepartmentDepartmentId");

                    b.HasOne("Shortlist.Api.Models.Company", "RelatedCompany")
                        .WithMany()
                        .HasForeignKey("RelatedCompanyCompanyId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Employee", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Role", "EmployeeRole")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleRoleId");

                    b.HasOne("Shortlist.Api.Models.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonPersonId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.EmployeeSkill", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Skill", "RelatedSkill")
                        .WithMany()
                        .HasForeignKey("RelatedSkillSkillId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Opening", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Role", "OpeningFor")
                        .WithMany()
                        .HasForeignKey("OpeningForRoleId");

                    b.HasOne("Shortlist.Api.Models.Company", "RelatedCompany")
                        .WithMany()
                        .HasForeignKey("RelatedCompanyCompanyId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Person", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Company", "RelatedCompany")
                        .WithMany()
                        .HasForeignKey("RelatedCompanyCompanyId");
                });

            modelBuilder.Entity("Shortlist.Api.Models.Skill", b =>
                {
                    b.HasOne("Shortlist.Api.Models.Opening")
                        .WithMany("JobSkills")
                        .HasForeignKey("OpeningId");
                });
#pragma warning restore 612, 618
        }
    }
}
