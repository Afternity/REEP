using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REEP.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentPassports_Warranties_WarrantyId",
                table: "EquipmentPassports");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentPassports_WarrantyId",
                table: "EquipmentPassports");

            migrationBuilder.DropColumn(
                name: "WarrantyId",
                table: "EquipmentPassports");

            migrationBuilder.AddColumn<string>(
                name: "OtherPrice",
                table: "Payments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WarrantyId",
                table: "Equipment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_WarrantyId",
                table: "Equipment",
                column: "WarrantyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Warranties_WarrantyId",
                table: "Equipment",
                column: "WarrantyId",
                principalTable: "Warranties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Warranties_WarrantyId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_WarrantyId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "OtherPrice",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "WarrantyId",
                table: "Equipment");

            migrationBuilder.AddColumn<Guid>(
                name: "WarrantyId",
                table: "EquipmentPassports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_WarrantyId",
                table: "EquipmentPassports",
                column: "WarrantyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentPassports_Warranties_WarrantyId",
                table: "EquipmentPassports",
                column: "WarrantyId",
                principalTable: "Warranties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
