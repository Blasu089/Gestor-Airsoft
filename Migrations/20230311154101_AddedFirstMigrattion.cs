using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAirsoft.Migrations
{
    public partial class AddedFirstMigrattion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesorio",
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
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorio", x => x.Cod_Accesorio);
                });

            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    Cod_Accion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.Cod_Accion);
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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad_Cartucho = table.Column<int>(type: "int", nullable: true),
                    Cartuchos_Incluidos = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Bipode_Incluido = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Mira_Incluida = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Cod_Referencia);
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
                name: "Disparo",
                columns: table => new
                {
                    Cod_Disparo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disparo", x => x.Cod_Disparo);
                });

            migrationBuilder.CreateTable(
                name: "ArmaColor",
                columns: table => new
                {
                    ArmasCod_Referencia = table.Column<int>(type: "int", nullable: false),
                    ColoresCod_Color = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmaColor", x => new { x.ArmasCod_Referencia, x.ColoresCod_Color });
                    table.ForeignKey(
                        name: "FK_ArmaColor_Armas_ArmasCod_Referencia",
                        column: x => x.ArmasCod_Referencia,
                        principalTable: "Armas",
                        principalColumn: "Cod_Referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmaColor_Colores_ColoresCod_Color",
                        column: x => x.ColoresCod_Color,
                        principalTable: "Colores",
                        principalColumn: "Cod_Color",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmaColor_ColoresCod_Color",
                table: "ArmaColor",
                column: "ColoresCod_Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorio");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "ArmaColor");

            migrationBuilder.DropTable(
                name: "Disparo");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Colores");
        }
    }
}
