using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasamentoLH_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateBaseMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_guest_tb_guest_group_guest_group_id",
                table: "tb_guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK____GuestGroup",
                table: "tb_guest_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK____Guest",
                table: "tb_guest");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_guest_group",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tb_guest_group",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "tb_guest_group",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_guest",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tb_guest",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "tb_guest",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "guest_group_id",
                table: "tb_guest",
                newName: "id_guest_group");

            migrationBuilder.RenameIndex(
                name: "IX_tb_guest_guest_group_id",
                table: "tb_guest",
                newName: "IX_tb_guest_id_guest_group");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "tb_guest_group",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "tb_guest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestGroup",
                table: "tb_guest_group",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "tb_guest",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_guest_tb_guest_group_id_guest_group",
                table: "tb_guest",
                column: "id_guest_group",
                principalTable: "tb_guest_group",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_guest_tb_guest_group_id_guest_group",
                table: "tb_guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestGroup",
                table: "tb_guest_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "tb_guest");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tb_guest_group");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tb_guest");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_guest_group",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tb_guest_group",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "tb_guest_group",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_guest",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tb_guest",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "tb_guest",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "id_guest_group",
                table: "tb_guest",
                newName: "guest_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_guest_id_guest_group",
                table: "tb_guest",
                newName: "IX_tb_guest_guest_group_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK____GuestGroup",
                table: "tb_guest_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK____Guest",
                table: "tb_guest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_guest_tb_guest_group_guest_group_id",
                table: "tb_guest",
                column: "guest_group_id",
                principalTable: "tb_guest_group",
                principalColumn: "Id");
        }
    }
}
