using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BisnesManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inittt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Statuses_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "nextval('\"UserRoles_Id_seq\"'::regclass)"),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsEditWorkersRoles = table.Column<bool>(type: "boolean", nullable: false),
                    IsEditWorkTimeTable = table.Column<bool>(type: "boolean", nullable: false),
                    Post = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserRoles_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Family = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Patronymic = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CheckPhrase = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdRole = table.Column<short>(type: "smallint", nullable: false),
                    PhotoImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    StartWorkTime = table.Column<DateOnly>(type: "date", nullable: false),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndWorkTime = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Users_IdRole_fkey",
                        column: x => x.IdRole,
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BisnesTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<short>(type: "smallint", nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Indentation = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AssignmentsContent = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdStatus = table.Column<short>(type: "smallint", nullable: false),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BisnesTask_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Tasks_IdStatus_fkey",
                        column: x => x.IdStatus,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Tasks_IdUser_fkey",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HolidayPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<short>(type: "smallint", nullable: false),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false),
                    StartWeekends = table.Column<DateOnly>(type: "date", nullable: false),
                    EndWeekends = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HolidayPlan_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "HolidayPlan_IdUser_fkey",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<short>(type: "smallint", nullable: false),
                    QualityWork = table.Column<int>(type: "integer", nullable: false),
                    LevelResponibility = table.Column<int>(type: "integer", nullable: false),
                    EffectivCommunication = table.Column<int>(type: "integer", nullable: false),
                    HardSkils = table.Column<int>(type: "integer", nullable: false),
                    SoftSkils = table.Column<int>(type: "integer", nullable: false),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Statistic_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Statistic_IdUser_fkey",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BisnesTask_IdStatus",
                table: "BisnesTask",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_BisnesTask_IdUser",
                table: "BisnesTask",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPlan_IdUser",
                table: "HolidayPlan",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_IdUser",
                table: "Statistic",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BisnesTask");

            migrationBuilder.DropTable(
                name: "HolidayPlan");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
