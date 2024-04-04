﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construction.API.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Specialties = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MembersList = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectConstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectConstructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetConstructionTeam = table.Column<double>(type: "float", nullable: false),
                    BudgetDutie = table.Column<double>(type: "float", nullable: false),
                    BudgetEquipment = table.Column<double>(type: "float", nullable: false),
                    BudgetProyectConstruction = table.Column<double>(type: "float", nullable: false),
                    BudgetTotal = table.Column<double>(type: "float", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectConstructionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_ProjectConstructions_ProjectConstructionsId",
                        column: x => x.ProjectConstructionsId,
                        principalTable: "ProjectConstructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectConstructionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duties_ProjectConstructions_ProjectConstructionsId",
                        column: x => x.ProjectConstructionsId,
                        principalTable: "ProjectConstructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionTeamsId = table.Column<int>(type: "int", nullable: true),
                    ProjectConstructionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAssignment_ConstructionTeams_ConstructionTeamsId",
                        column: x => x.ConstructionTeamsId,
                        principalTable: "ConstructionTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentAssignment_ProjectConstructions_ProjectConstructionsId",
                        column: x => x.ProjectConstructionsId,
                        principalTable: "ProjectConstructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaintenanceState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectConstructionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_ProjectConstructions_ProjectConstructionsId",
                        column: x => x.ProjectConstructionsId,
                        principalTable: "ProjectConstructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequiredQuantity = table.Column<double>(type: "float", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstimatedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectConstructionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_ProjectConstructions_ProjectConstructionsId",
                        column: x => x.ProjectConstructionsId,
                        principalTable: "ProjectConstructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialAssigment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialsId = table.Column<int>(type: "int", nullable: true),
                    DutiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAssigment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialAssigment_Duties_DutiesId",
                        column: x => x.DutiesId,
                        principalTable: "Duties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialAssigment_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ProjectConstructionsId",
                table: "Budgets",
                column: "ProjectConstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_ProjectConstructionsId",
                table: "Duties",
                column: "ProjectConstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAssignment_ConstructionTeamsId",
                table: "EquipmentAssignment",
                column: "ConstructionTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAssignment_ProjectConstructionsId",
                table: "EquipmentAssignment",
                column: "ProjectConstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ProjectConstructionsId",
                table: "Equipments",
                column: "ProjectConstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAssigment_DutiesId",
                table: "MaterialAssigment",
                column: "DutiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAssigment_MaterialsId",
                table: "MaterialAssigment",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ProjectConstructionsId",
                table: "Materials",
                column: "ProjectConstructionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "EquipmentAssignment");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "MaterialAssigment");

            migrationBuilder.DropTable(
                name: "ConstructionTeams");

            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ProjectConstructions");
        }
    }
}
