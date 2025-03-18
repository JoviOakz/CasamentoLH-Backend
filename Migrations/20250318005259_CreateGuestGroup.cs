using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasamentoLH_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateGuestGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "guest_group_id",
                table: "tb_guest",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_guest_group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK____GuestGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_guest_guest_group_id",
                table: "tb_guest",
                column: "guest_group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_guest_tb_guest_group_guest_group_id",
                table: "tb_guest",
                column: "guest_group_id",
                principalTable: "tb_guest_group",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_guest_tb_guest_group_guest_group_id",
                table: "tb_guest");

            migrationBuilder.DropTable(
                name: "tb_guest_group");

            migrationBuilder.DropIndex(
                name: "IX_tb_guest_guest_group_id",
                table: "tb_guest");

            migrationBuilder.DropColumn(
                name: "guest_group_id",
                table: "tb_guest");
        }
    }
}
