using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Date);
                }
            );

            migrationBuilder.CreateTable(
                name: "TrainingStatuses",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    CodeName = table.Column<string>(
                        type: "varchar(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    Name = table.Column<string>(
                        type: "varchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingStatuses", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "TrainingInfos",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Title = table.Column<string>(
                        type: "varchar(200)",
                        maxLength: 200,
                        nullable: false
                    ),
                    DurationTimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(
                        type: "varchar(1000)",
                        maxLength: 1000,
                        nullable: false
                    ),
                    TrainingDayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingStatusId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingInfos_TrainingDays_TrainingDayDate",
                        column: x => x.TrainingDayDate,
                        principalTable: "TrainingDays",
                        principalColumn: "Date",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TrainingInfos_TrainingStatuses_TrainingStatusId",
                        column: x => x.TrainingStatusId,
                        principalTable: "TrainingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInfos_TrainingDayDate",
                table: "TrainingInfos",
                column: "TrainingDayDate"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInfos_TrainingStatusId",
                table: "TrainingInfos",
                column: "TrainingStatusId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TrainingStatuses_CodeName",
                table: "TrainingStatuses",
                column: "CodeName",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TrainingInfos");

            migrationBuilder.DropTable(name: "TrainingDays");

            migrationBuilder.DropTable(name: "TrainingStatuses");
        }
    }
}
