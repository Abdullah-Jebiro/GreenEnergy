using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenEnergy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    StationSourceId = table.Column<int>(type: "int", nullable: false),
                    StationDestinationId = table.Column<int>(type: "int", nullable: false),
                    LineTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationRelations_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LossOfElectricities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    StationRelationsId = table.Column<int>(type: "int", nullable: false),
                    FirstDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LossResult = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossOfElectricities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LossOfElectricities_StationRelations_StationRelationsId",
                        column: x => x.StationRelationsId,
                        principalTable: "StationRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LossOfElectricities_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    StationRelationsId = table.Column<int>(type: "int", nullable: false),
                    FirstDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observers_StationRelations_StationRelationsId",
                        column: x => x.StationRelationsId,
                        principalTable: "StationRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observers_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LossOfElectricities_StationId",
                table: "LossOfElectricities",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_LossOfElectricities_StationRelationsId",
                table: "LossOfElectricities",
                column: "StationRelationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_StationId",
                table: "Observers",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_StationRelationsId",
                table: "Observers",
                column: "StationRelationsId");

            migrationBuilder.CreateIndex(
                name: "IX_StationRelations_StationId",
                table: "StationRelations",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LossOfElectricities");

            migrationBuilder.DropTable(
                name: "Observers");

            migrationBuilder.DropTable(
                name: "StationRelations");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
