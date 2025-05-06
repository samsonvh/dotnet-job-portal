using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.account_id);
                    table.ForeignKey(
                        name: "fk_account_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "working_skill",
                columns: table => new
                {
                    working_skill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_working_skill", x => x.working_skill_id);
                });

            migrationBuilder.CreateTable(
                name: "applicant",
                columns: table => new
                {
                    applicant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant", x => x.applicant_id);
                    table.ForeignKey(
                        name: "fk_applicant_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_id);
                    table.ForeignKey(
                        name: "fk_company_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applicant_resume",
                columns: table => new
                {
                    resume_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    applicant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant_resume", x => x.resume_id);
                    table.ForeignKey(
                        name: "fk_applicant_resume_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "applicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applicant_skill",
                columns: table => new
                {
                    applicant_skill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    working_skill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    applicant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant_skill", x => x.applicant_skill_id);
                    table.ForeignKey(
                        name: "FK_applicant_skill_applicant_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "applicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicant_skill_working_skill_working_skill_id",
                        column: x => x.working_skill_id,
                        principalTable: "working_skill",
                        principalColumn: "working_skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company_location",
                columns: table => new
                {
                    company_location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_headquarter = table.Column<bool>(type: "bit", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_location", x => x.company_location_id);
                    table.ForeignKey(
                        name: "fk_company_location_company_id",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recruiter",
                columns: table => new
                {
                    recruiter_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recruiter", x => x.recruiter_id);
                    table.ForeignKey(
                        name: "fk_recruiter_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recruiter_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_posting",
                columns: table => new
                {
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number_of_hires = table.Column<int>(type: "int", nullable: false),
                    min_salary = table.Column<int>(type: "int", nullable: false),
                    max_salary = table.Column<int>(type: "int", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    expiry_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    salary_type = table.Column<int>(type: "int", nullable: false),
                    job_type = table.Column<int>(type: "int", nullable: false),
                    job_level = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_posting", x => x.job_posting_id);
                    table.ForeignKey(
                        name: "FK_job_posting_recruiter_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "recruiter",
                        principalColumn: "recruiter_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_application",
                columns: table => new
                {
                    job_application_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cover_letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    applicant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    applicant_resume_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_application", x => x.job_application_id);
                    table.ForeignKey(
                        name: "FK_job_application_applicant_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "applicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_application_applicant_resume_applicant_resume_id",
                        column: x => x.applicant_resume_id,
                        principalTable: "applicant_resume",
                        principalColumn: "resume_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_application_job_posting_job_posting_id",
                        column: x => x.job_posting_id,
                        principalTable: "job_posting",
                        principalColumn: "job_posting_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_benefit",
                columns: table => new
                {
                    job_benefit_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    benefit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_benefit", x => x.job_benefit_id);
                    table.ForeignKey(
                        name: "FK_job_benefit_job_posting_job_posting_id",
                        column: x => x.job_posting_id,
                        principalTable: "job_posting",
                        principalColumn: "job_posting_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_location",
                columns: table => new
                {
                    job_location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_location_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_location", x => x.job_location_id);
                    table.ForeignKey(
                        name: "FK_job_location_company_location_company_location_id",
                        column: x => x.company_location_id,
                        principalTable: "company_location",
                        principalColumn: "company_location_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_location_job_posting_job_posting_id",
                        column: x => x.job_posting_id,
                        principalTable: "job_posting",
                        principalColumn: "job_posting_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_requirement",
                columns: table => new
                {
                    job_requirement_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_requirement", x => x.job_requirement_id);
                    table.ForeignKey(
                        name: "FK_job_requirement_job_posting_job_posting_id",
                        column: x => x.job_posting_id,
                        principalTable: "job_posting",
                        principalColumn: "job_posting_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_skill",
                columns: table => new
                {
                    job_skill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    working_skill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_posting_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_skill", x => x.job_skill_id);
                    table.ForeignKey(
                        name: "FK_job_skill_job_posting_job_posting_id",
                        column: x => x.job_posting_id,
                        principalTable: "job_posting",
                        principalColumn: "job_posting_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_skill_working_skill_working_skill_id",
                        column: x => x.working_skill_id,
                        principalTable: "working_skill",
                        principalColumn: "working_skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_created_by_id",
                table: "account",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_applicant_account_id",
                table: "applicant",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_applicant_resume_applicant_id",
                table: "applicant_resume",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_applicant_skill_applicant_id",
                table: "applicant_skill",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_applicant_skill_working_skill_id",
                table: "applicant_skill",
                column: "working_skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_account_id",
                table: "company",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_location_CompanyId",
                table: "company_location",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_applicant_id",
                table: "job_application",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_applicant_resume_id",
                table: "job_application",
                column: "applicant_resume_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_application_job_posting_id",
                table: "job_application",
                column: "job_posting_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_benefit_job_posting_id",
                table: "job_benefit",
                column: "job_posting_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_location_company_location_id",
                table: "job_location",
                column: "company_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_location_job_posting_id",
                table: "job_location",
                column: "job_posting_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_posting_created_by_id",
                table: "job_posting",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_requirement_job_posting_id",
                table: "job_requirement",
                column: "job_posting_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_skill_job_posting_id",
                table: "job_skill",
                column: "job_posting_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_skill_working_skill_id",
                table: "job_skill",
                column: "working_skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_recruiter_account_id",
                table: "recruiter",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recruiter_company_id",
                table: "recruiter",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicant_skill");

            migrationBuilder.DropTable(
                name: "job_application");

            migrationBuilder.DropTable(
                name: "job_benefit");

            migrationBuilder.DropTable(
                name: "job_location");

            migrationBuilder.DropTable(
                name: "job_requirement");

            migrationBuilder.DropTable(
                name: "job_skill");

            migrationBuilder.DropTable(
                name: "applicant_resume");

            migrationBuilder.DropTable(
                name: "company_location");

            migrationBuilder.DropTable(
                name: "job_posting");

            migrationBuilder.DropTable(
                name: "working_skill");

            migrationBuilder.DropTable(
                name: "applicant");

            migrationBuilder.DropTable(
                name: "recruiter");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
