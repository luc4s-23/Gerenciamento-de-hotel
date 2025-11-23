using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoteis.Migrations
{
    /// <inheritdoc />
    public partial class novoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospedes",
                columns: table => new
                {
                    Id_hospede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF_hospede = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menor_idade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospedes", x => x.Id_hospede);
                });

            migrationBuilder.CreateTable(
                name: "quartos",
                columns: table => new
                {
                    Id_quarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_quarto = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Preco_quarto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quartos", x => x.Id_quarto);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha_Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    Id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarto_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Nome_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento_hospede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_saida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco_total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Quantidade_hospedes = table.Column<int>(type: "int", nullable: false),
                    HospedeId_hospede = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.Id_reserva);
                    table.ForeignKey(
                        name: "FK_reservas_hospedes_HospedeId_hospede",
                        column: x => x.HospedeId_hospede,
                        principalTable: "hospedes",
                        principalColumn: "Id_hospede");
                });

            migrationBuilder.CreateIndex(
                name: "IX_hospedes_CPF_hospede",
                table: "hospedes",
                column: "CPF_hospede",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservas_HospedeId_hospede",
                table: "reservas",
                column: "HospedeId_hospede");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quartos");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "hospedes");
        }
    }
}
