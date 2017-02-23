using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class changedTimeFieldsToTimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "FitnessClass",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "FitnessClass",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "FitnessClass",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "FitnessClass",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
