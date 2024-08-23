﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChilliStorage.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_ConsignmentDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppApp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ConsignmentNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Document = table.Column<byte[]>(type: "longblob", nullable: false),
                    CapturedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SupplierId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppApp", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppApp");
        }
    }
}
