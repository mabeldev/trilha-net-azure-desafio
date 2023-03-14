using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trilha_net_azure_desafio.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Logs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TipoAcao",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "FuncionarioLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ramal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailProfissional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TipoAcao = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioLogs");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Timestamp",
                table: "Funcionarios",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoAcao",
                table: "Funcionarios",
                type: "int",
                nullable: true);
        }
    }
}
