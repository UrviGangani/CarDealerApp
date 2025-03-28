using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerApp.Migrations
{
    public partial class AddInquiryTableANDAddupdateCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inquiries");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Inquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "Inquiries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Inquiries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Inquiries",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CarId",
                table: "Inquiries",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CarId1",
                table: "Inquiries",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_UserId",
                table: "Inquiries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_AspNetUsers_UserId",
                table: "Inquiries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarId",
                table: "Inquiries",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarId1",
                table: "Inquiries",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_AspNetUsers_UserId",
                table: "Inquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarId",
                table: "Inquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarId1",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_CarId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_CarId1",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_UserId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Inquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
