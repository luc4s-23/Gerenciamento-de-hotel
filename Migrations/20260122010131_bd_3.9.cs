using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoteis.Migrations
{
    /// <inheritdoc />
    public partial class bd_39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quartos",
                columns: table => new
                {
                    Id_quarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_quarto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Preco_diaria = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Preco_total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    QuantidadeDiarias = table.Column<int>(type: "int", nullable: false),
                    Quantidade_hospedes = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.Id_reserva);
                    table.ForeignKey(
                        name: "FK_reservas_quartos_Quarto_ID_FK",
                        column: x => x.Quarto_ID_FK,
                        principalTable: "quartos",
                        principalColumn: "Id_quarto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservas_Quarto_ID_FK",
                table: "reservas",
                column: "Quarto_ID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "quartos");
        }
    }
}
