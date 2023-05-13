using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Admin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Buyer",
                newName: "Buyers");

            migrationBuilder.RenameTable(
                name: "AdminUser",
                newName: "AdminUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "LogisticsStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LogisticsStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LogisticsStaff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "LogisticsStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "LogisticsStaff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LogisticsStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LogisticsStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sellers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Sellers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Buyers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Buyers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AdminUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AdminUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AdminUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "AdminUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AdminUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AdminUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUsers",
                table: "AdminUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUsers",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LogisticsStaff");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AdminUsers");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyer");

            migrationBuilder.RenameTable(
                name: "AdminUsers",
                newName: "AdminUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser",
                column: "Id");
        }
    }
}
