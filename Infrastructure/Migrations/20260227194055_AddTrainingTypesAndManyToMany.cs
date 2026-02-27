using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingTypesAndManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInfos_TrainingDays_TrainingDayDate",
                table: "TrainingInfos"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInfos_TrainingStatuses_TrainingStatusId",
                table: "TrainingInfos"
            );

            migrationBuilder.DropIndex(
                name: "IX_TrainingInfos_TrainingDayDate",
                table: "TrainingInfos"
            );

            migrationBuilder.DropIndex(
                name: "IX_TrainingInfos_TrainingStatusId",
                table: "TrainingInfos"
            );

            migrationBuilder.DropColumn(name: "TrainingDayDate", table: "TrainingInfos");

            migrationBuilder.DropColumn(name: "TrainingStatusId", table: "TrainingInfos");

            migrationBuilder.CreateTable(
                name: "TrainingDayTrainingInfos",
                columns: table => new
                {
                    TrainingDayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingInfoId = table.Column<int>(type: "integer", nullable: false),
                    TrainingStatusId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_TrainingDayTrainingInfos",
                        x => new { x.TrainingDayDate, x.TrainingInfoId }
                    );
                    table.ForeignKey(
                        name: "FK_TrainingDayTrainingInfos_TrainingDays_TrainingDayDate",
                        column: x => x.TrainingDayDate,
                        principalTable: "TrainingDays",
                        principalColumn: "Date",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TrainingDayTrainingInfos_TrainingInfos_TrainingInfoId",
                        column: x => x.TrainingInfoId,
                        principalTable: "TrainingInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TrainingDayTrainingInfos_TrainingStatuses_TrainingStatusId",
                        column: x => x.TrainingStatusId,
                        principalTable: "TrainingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDayTrainingInfos_TrainingInfoId",
                table: "TrainingDayTrainingInfos",
                column: "TrainingInfoId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDayTrainingInfos_TrainingStatusId",
                table: "TrainingDayTrainingInfos",
                column: "TrainingStatusId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TrainingDayTrainingInfos");

            migrationBuilder.AddColumn<DateOnly>(
                name: "TrainingDayDate",
                table: "TrainingInfos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1)
            );

            migrationBuilder.AddColumn<int>(
                name: "TrainingStatusId",
                table: "TrainingInfos",
                type: "int",
                nullable: false,
                defaultValue: 0
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

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInfos_TrainingDays_TrainingDayDate",
                table: "TrainingInfos",
                column: "TrainingDayDate",
                principalTable: "TrainingDays",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInfos_TrainingStatuses_TrainingStatusId",
                table: "TrainingInfos",
                column: "TrainingStatusId",
                principalTable: "TrainingStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
