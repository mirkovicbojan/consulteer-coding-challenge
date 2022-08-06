﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainAPI.Migrations
{
    public partial class NullableForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roleID",
                table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "roleID",
                table: "users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roleID",
                table: "users",
                column: "roleID",
                principalTable: "roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roleID",
                table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "roleID",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roleID",
                table: "users",
                column: "roleID",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
