using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestaoTCC.Core.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdImagem",
                table: "Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdImagem",
                table: "Curso",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditadoEm",
                table: "Arquivo",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "Arquivo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivationTokens_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IdImagem",
                table: "Projeto",
                column: "IdImagem");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdImagem",
                table: "Curso",
                column: "IdImagem");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "PasswordResetTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivationTokens_UserId",
                table: "UserActivationTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__Curso__IdImage__0C85DE4D",
                table: "Curso",
                column: "IdImagem",
                principalTable: "Arquivo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Projeto__IdImage__0C85DE4D",
                table: "Projeto",
                column: "IdImagem",
                principalTable: "Arquivo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Curso__IdImage__0C85DE4D",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK__Projeto__IdImage__0C85DE4D",
                table: "Projeto");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DropTable(
                name: "UserActivationTokens");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_IdImagem",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Curso_IdImagem",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdImagem",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IdImagem",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "Arquivo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditadoEm",
                table: "Arquivo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
