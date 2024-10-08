﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostInCredits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HyperdriveRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGLT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarshipClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pilots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
