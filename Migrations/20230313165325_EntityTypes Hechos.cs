using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAirsoft.Migrations
{
    public partial class EntityTypesHechos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Armas",
                newName: "Tipo Arma");

            migrationBuilder.CreateTable(
                name: "AccesorioArma",
                columns: table => new
                {
                    AccesoriosCod_Accesorio = table.Column<int>(type: "int", nullable: false),
                    ArmasCod_Referencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesorioArma", x => new { x.AccesoriosCod_Accesorio, x.ArmasCod_Referencia });
                    table.ForeignKey(
                        name: "FK_AccesorioArma_Accesorio_AccesoriosCod_Accesorio",
                        column: x => x.AccesoriosCod_Accesorio,
                        principalTable: "Accesorio",
                        principalColumn: "Cod_Accesorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccesorioArma_Armas_ArmasCod_Referencia",
                        column: x => x.ArmasCod_Referencia,
                        principalTable: "Armas",
                        principalColumn: "Cod_Referencia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccesorioColor",
                columns: table => new
                {
                    AccesoriosCod_Accesorio = table.Column<int>(type: "int", nullable: false),
                    ColoresCod_Color = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesorioColor", x => new { x.AccesoriosCod_Accesorio, x.ColoresCod_Color });
                    table.ForeignKey(
                        name: "FK_AccesorioColor_Accesorio_AccesoriosCod_Accesorio",
                        column: x => x.AccesoriosCod_Accesorio,
                        principalTable: "Accesorio",
                        principalColumn: "Cod_Accesorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccesorioColor_Colores_ColoresCod_Color",
                        column: x => x.ColoresCod_Color,
                        principalTable: "Colores",
                        principalColumn: "Cod_Color",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionArma",
                columns: table => new
                {
                    AccionesCod_Accion = table.Column<int>(type: "int", nullable: false),
                    ArmasCod_Referencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionArma", x => new { x.AccionesCod_Accion, x.ArmasCod_Referencia });
                    table.ForeignKey(
                        name: "FK_AccionArma_Accion_AccionesCod_Accion",
                        column: x => x.AccionesCod_Accion,
                        principalTable: "Accion",
                        principalColumn: "Cod_Accion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionArma_Armas_ArmasCod_Referencia",
                        column: x => x.ArmasCod_Referencia,
                        principalTable: "Armas",
                        principalColumn: "Cod_Referencia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmaDisparo",
                columns: table => new
                {
                    ArmasCod_Referencia = table.Column<int>(type: "int", nullable: false),
                    DisparosCod_Disparo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmaDisparo", x => new { x.ArmasCod_Referencia, x.DisparosCod_Disparo });
                    table.ForeignKey(
                        name: "FK_ArmaDisparo_Armas_ArmasCod_Referencia",
                        column: x => x.ArmasCod_Referencia,
                        principalTable: "Armas",
                        principalColumn: "Cod_Referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmaDisparo_Disparo_DisparosCod_Disparo",
                        column: x => x.DisparosCod_Disparo,
                        principalTable: "Disparo",
                        principalColumn: "Cod_Disparo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lentes",
                columns: table => new
                {
                    Cod_Lentes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lentes", x => x.Cod_Lentes);
                });

            migrationBuilder.CreateTable(
                name: "Ropa",
                columns: table => new
                {
                    Cod_Ropa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRopa = table.Column<string>(name: "Tipo Ropa", type: "nvarchar(max)", nullable: false),
                    Revestimiento_Metalico = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Manga_Larga = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Casco_Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rieles_Laterales = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Acolchado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Riel_Frontal = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Num_Portacargadores = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Mitones = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FullFace = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Num_Bolsillos = table.Column<int>(type: "int", nullable: true, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ropa", x => x.Cod_Ropa);
                });

            migrationBuilder.CreateTable(
                name: "Talla",
                columns: table => new
                {
                    Cod_Talla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Talla_Europea = table.Column<int>(type: "int", nullable: false),
                    Talla_Americana = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talla", x => x.Cod_Talla);
                });

            migrationBuilder.CreateTable(
                name: "ColorRopa",
                columns: table => new
                {
                    ColoresCod_Color = table.Column<int>(type: "int", nullable: false),
                    RopasCod_Ropa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorRopa", x => new { x.ColoresCod_Color, x.RopasCod_Ropa });
                    table.ForeignKey(
                        name: "FK_ColorRopa_Colores_ColoresCod_Color",
                        column: x => x.ColoresCod_Color,
                        principalTable: "Colores",
                        principalColumn: "Cod_Color",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorRopa_Ropa_RopasCod_Ropa",
                        column: x => x.RopasCod_Ropa,
                        principalTable: "Ropa",
                        principalColumn: "Cod_Ropa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GafasLentes",
                columns: table => new
                {
                    GafasCod_Ropa = table.Column<int>(type: "int", nullable: false),
                    LentesCod_Lentes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GafasLentes", x => new { x.GafasCod_Ropa, x.LentesCod_Lentes });
                    table.ForeignKey(
                        name: "FK_GafasLentes_Lentes_LentesCod_Lentes",
                        column: x => x.LentesCod_Lentes,
                        principalTable: "Lentes",
                        principalColumn: "Cod_Lentes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GafasLentes_Ropa_GafasCod_Ropa",
                        column: x => x.GafasCod_Ropa,
                        principalTable: "Ropa",
                        principalColumn: "Cod_Ropa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RopaTalla",
                columns: table => new
                {
                    RopasCod_Ropa = table.Column<int>(type: "int", nullable: false),
                    TallasCod_Talla = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RopaTalla", x => new { x.RopasCod_Ropa, x.TallasCod_Talla });
                    table.ForeignKey(
                        name: "FK_RopaTalla_Ropa_RopasCod_Ropa",
                        column: x => x.RopasCod_Ropa,
                        principalTable: "Ropa",
                        principalColumn: "Cod_Ropa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RopaTalla_Talla_TallasCod_Talla",
                        column: x => x.TallasCod_Talla,
                        principalTable: "Talla",
                        principalColumn: "Cod_Talla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccesorioArma_ArmasCod_Referencia",
                table: "AccesorioArma",
                column: "ArmasCod_Referencia");

            migrationBuilder.CreateIndex(
                name: "IX_AccesorioColor_ColoresCod_Color",
                table: "AccesorioColor",
                column: "ColoresCod_Color");

            migrationBuilder.CreateIndex(
                name: "IX_AccionArma_ArmasCod_Referencia",
                table: "AccionArma",
                column: "ArmasCod_Referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ArmaDisparo_DisparosCod_Disparo",
                table: "ArmaDisparo",
                column: "DisparosCod_Disparo");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRopa_RopasCod_Ropa",
                table: "ColorRopa",
                column: "RopasCod_Ropa");

            migrationBuilder.CreateIndex(
                name: "IX_GafasLentes_LentesCod_Lentes",
                table: "GafasLentes",
                column: "LentesCod_Lentes");

            migrationBuilder.CreateIndex(
                name: "IX_RopaTalla_TallasCod_Talla",
                table: "RopaTalla",
                column: "TallasCod_Talla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccesorioArma");

            migrationBuilder.DropTable(
                name: "AccesorioColor");

            migrationBuilder.DropTable(
                name: "AccionArma");

            migrationBuilder.DropTable(
                name: "ArmaDisparo");

            migrationBuilder.DropTable(
                name: "ColorRopa");

            migrationBuilder.DropTable(
                name: "GafasLentes");

            migrationBuilder.DropTable(
                name: "RopaTalla");

            migrationBuilder.DropTable(
                name: "Lentes");

            migrationBuilder.DropTable(
                name: "Ropa");

            migrationBuilder.DropTable(
                name: "Talla");

            migrationBuilder.RenameColumn(
                name: "Tipo Arma",
                table: "Armas",
                newName: "Discriminator");
        }
    }
}
