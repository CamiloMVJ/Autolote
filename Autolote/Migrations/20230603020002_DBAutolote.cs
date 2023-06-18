using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class DBAutolote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CedulaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelfono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CedulaId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Chasis = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AñoFab = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Chasis);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosContado",
                columns: table => new
                {
                    RegistroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chasis = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosContado", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_RegistrosContado_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "CedulaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrosContado_Vehiculos_Chasis",
                        column: x => x.Chasis,
                        principalTable: "Vehiculos",
                        principalColumn: "Chasis");
                });

            migrationBuilder.CreateTable(
                name: "RegistrosCredito",
                columns: table => new
                {
                    RegistroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chasis = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cuota = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Capitalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasaInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AñosDelContrato = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_RegistrosContado_Chasis",
                table: "RegistrosContado",
                column: "Chasis");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosContado_ClienteId",
                table: "RegistrosContado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosCredito_Chasis",
                table: "RegistrosCredito",
                column: "Chasis");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosCredito_ClienteId",
                table: "RegistrosCredito",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosContado");

            migrationBuilder.DropTable(
                name: "RegistrosCredito");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
