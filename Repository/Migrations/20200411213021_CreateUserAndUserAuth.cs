using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class CreateUserAndUserAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAtUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ExibitionName = table.Column<string>(maxLength: 30, nullable: true),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAtUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuths_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuths_UserId",
                table: "UserAuths",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAuths");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
