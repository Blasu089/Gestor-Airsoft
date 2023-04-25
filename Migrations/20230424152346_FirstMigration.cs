using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAirsoft.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    Cod_Accion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Cod_Accion);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cod_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cod_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    Cod_Color = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hexadecimal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.Cod_Color);
                });

            migrationBuilder.CreateTable(
                name: "Disparos",
                columns: table => new
                {
                    Cod_Disparo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disparos", x => x.Cod_Disparo);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Cod_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Cliente = table.Column<int>(type: "int", nullable: false),
                    Precio_Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Cod_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_Cod_Cliente",
                        column: x => x.Cod_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Cod_Cliente");
                });

            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    Cod_Accesorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color_Id = table.Column<int>(type: "int", nullable: true),
                    Cod_Pedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.Cod_Accesorio);
                    table.ForeignKey(
                        name: "FK_Accesorios_Colores_Color_Id",
                        column: x => x.Color_Id,
                        principalTable: "Colores",
                        principalColumn: "Cod_Color",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accesorios_Pedidos_Cod_Pedido",
                        column: x => x.Cod_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Cod_Pedido",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Cod_Referencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HopUp = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Longitud = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Potencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Velocidad = table.Column<int>(type: "int", nullable: false),
                    Capacidad_Cargador = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoArma = table.Column<int>(type: "int", nullable: false),
                    Color_Id = table.Column<int>(type: "int", nullable: true),
                    Accion_Id = table.Column<int>(type: "int", nullable: true),
                    Disparo_Id = table.Column<int>(type: "int", nullable: true),
                    Capacidad_Cartucho = table.Column<int>(type: "int", nullable: true),
                    Cartuchos_Incluidos = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Bipode_Incluido = table.Column<bool>(type: "bit", nullable: true),
                    Mira_Incluida = table.Column<bool>(type: "bit", nullable: true),
                    Cod_Pedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Cod_Referencia);
                    table.ForeignKey(
                        name: "FK_Armas_Acciones_Accion_Id",
                        column: x => x.Accion_Id,
                        principalTable: "Acciones",
                        principalColumn: "Cod_Accion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armas_Colores_Color_Id",
                        column: x => x.Color_Id,
                        principalTable: "Colores",
                        principalColumn: "Cod_Color",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armas_Disparos_Disparo_Id",
                        column: x => x.Disparo_Id,
                        principalTable: "Disparos",
                        principalColumn: "Cod_Disparo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armas_Pedidos_Cod_Pedido",
                        column: x => x.Cod_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Cod_Pedido",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_Cod_Pedido",
                table: "Accesorios",
                column: "Cod_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_Color_Id",
                table: "Accesorios",
                column: "Color_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_Accion_Id",
                table: "Armas",
                column: "Accion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_Cod_Pedido",
                table: "Armas",
                column: "Cod_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_Color_Id",
                table: "Armas",
                column: "Color_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_Disparo_Id",
                table: "Armas",
                column: "Disparo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Cod_Cliente",
                table: "Pedidos",
                column: "Cod_Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Disparos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
