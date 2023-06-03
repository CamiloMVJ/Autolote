using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class Actualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosCredito");

            migrationBuilder.AddColumn<int>(
                name: "AñosDelContrato",
                table: "RegistrosContado",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Capitalizacion",
                table: "RegistrosContado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cuota",
                table: "RegistrosContado",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RegistrosContado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TasaInteres",
                table: "RegistrosContado",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AñosDelContrato",
                table: "RegistrosContado");

            migrationBuilder.DropColumn(
                name: "Capitalizacion",
                table: "RegistrosContado");

            migrationBuilder.DropColumn(
                name: "Cuota",
                table: "RegistrosContado");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RegistrosContado");

            migrationBuilder.DropColumn(
                name: "TasaInteres",
                table: "RegistrosContado");

            migrationBuilder.CreateTable(
                name: "RegistrosCredito",
                columns: table => new
                {
                    RegistroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chasis = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AñosDelContrato = table.Column<int>(type: "int", nullable: false),
                    Capitalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CedulaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuota = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosCredito", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_RegistrosCredito_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "CedulaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrosCredito_Vehiculos_Chasis",
                        column: x => x.Chasis,
                        principalTable: "Vehiculos",
                        principalColumn: "Chasis");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosCredito_Chasis",
                table: "RegistrosCredito",
                column: "Chasis");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosCredito_ClienteId",
                table: "RegistrosCredito",
                column: "ClienteId");
        }
    }
}
